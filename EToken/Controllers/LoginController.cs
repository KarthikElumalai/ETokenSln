using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EToken.ApplicationFacede;
using EToken.Models;

namespace EToken.Controllers
{
    public class LoginController : Controller
    {

        //this test branch
        ApplicationFacade appFacade = new ApplicationFacade();
        Login login = new Login();
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SendOtp(Login login)
        {
            int otpValue = 0;
            string status = appFacade.SendOTP(login,out otpValue);
            TempData["OtpValue"] = otpValue;
            return Json(status);
        }
        public ActionResult EnterOTP()
        {
            return View();
        }
        public JsonResult VerifyOtp(string otp)
        {
            string tempDataOtp = TempData["OtpValue"].ToString();
            bool result = appFacade.VerifyOTP(otp, tempDataOtp);
            return Json(result);
        }

    }
}