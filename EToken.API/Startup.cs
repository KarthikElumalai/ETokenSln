using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EToken.Infrustructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EToken.API.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EToken.Core.Services;
using Microsoft.IdentityModel.Tokens;
using EToken.Infrustructure.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using EToken.Infrustructure.Persistence.Repositories;
using EToken.Core.Repositories;
using Serilog;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using EToken.API.Filters;
using Newtonsoft.Json.Serialization;

namespace EToken.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Init Serilog Configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // cache in memory
            services.AddMemoryCache();
            // caching response for middlewares
            services.AddResponseCaching();
            services.AddSession(opts => {
                opts.Cookie.IsEssential = true;
                opts.IdleTimeout = TimeSpan.FromMinutes(1);
                opts.Cookie.HttpOnly = true;
            });
            services.AddDbContext<ETokenDBContext>(x => x.UseInMemoryDatabase("TestDb"));
            services
                .AddMvc(options=> 
                {
                    options.Filters.Add<JsonExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                }); 
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);

            });
            

            services.AddSwaggerGen(options =>
            {
                //The generated Swagger JSON file will have these properties.
               options.SwaggerDoc("v1",
               new Info()
               {
                   Version = "v1",
                   Title = "v1 API",
                   Description = "v1 API Description",
                   TermsOfService = "Terms of usage v1"
               });
               options.SwaggerDoc("v2",
               new Info()
               {
                   Version = "v2",
                   Title = "v2 API",
                   Description = "v2 API Description",
                   TermsOfService = "Terms of usage v2"
               });
               // This call remove version from parameter, without it we will have version as parameter 
               // for all endpoints in swagger UI
                options.OperationFilter<RemoveVersionFromParameter>();

                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                // This on used to exclude endpoint mapped to not specified in swagger version.
                // In this particular example we exclude 'GET /api/v2/Values/otherget/three' endpoint,
                // because it was mapped to v3 with attribute: MapToApiVersion("3")
                options.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                            .GetCustomAttributes(true)
                            .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);
                    return versions.Any(v => $"v{v.ToString()}" == version);
                });
                //Locate the XML file being generated by ASP.NET...
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                options.IncludeXmlComments(xmlPath);
            });
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddHttpClient();
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepositories, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthy, Authy>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            //logging
            loggerFactory.AddSerilog();
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            
            //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
            });
        }
    }
}
