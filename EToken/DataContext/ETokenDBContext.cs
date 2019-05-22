using EToken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.DataContext
{
    public class ETokenDBContext : DbContext
    {

        public ETokenDBContext()
        {

        }
        public ETokenDBContext(DbContextOptions<ETokenDBContext> options)
     : base(options)
        {


        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address{ get; set; }
        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Provider> Provider { get; set; }  
        public DbSet<OrganisationServiceProvider> OrganisationServiceProvider { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<TokenStatus> TokenStatus { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());



        } // End of override void OnModelCreating(ModelBuilde)


    } //End of E-TokenDbContext class





}
