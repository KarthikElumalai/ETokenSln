using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EToken.ApplicationFacede;
using EToken.Models;
using Microsoft.AspNetCore.Http;

namespace EToken.Controllers
{
    public class LoginController : Controller
    {
        ApplicationFacade appFacade = new ApplicationFacade();
        Login login = new Login();
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SendOtp(string phoneNumber = null)
        {
            int otpValue = 0;
            string status = null;
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                login.CustomerPhoneNumber = phoneNumber;
                status = appFacade.SendOTP(login, out otpValue);
                HttpContext.Session.SetString("sessionotp", otpValue.ToString());
                return Json(status);
            }
            else
            {
                return Json(false);
            }    
        }
        public ActionResult EnterOTP()
        {
            return View();
        }
        public JsonResult VerifyOtp(string otp)
        {
            string sessionOTP = HttpContext.Session.GetString("sessionotp");
            bool result = appFacade.VerifyOTP(otp, sessionOTP);
            return Json(result);
        }

    }
}