using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EToken.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EToken.Controllers
{

    //This is a home page controller
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ValidateUser()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Login/sachn"); //API controller name
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<string>();
                    if (result != null)
                        return Content(result);
                  
                }
            }

            return View("Return your model here");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
