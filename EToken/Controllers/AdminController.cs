using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EToken.Controllers
{
    /// <summary>
    /// This is admin page controller
    /// </summary>
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}