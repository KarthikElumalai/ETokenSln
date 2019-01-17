using EToken.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace EToken.ApplicationFacede
{
    public class ApplicationFacade
    {
        ////Will Recieve the customer phone number from controller and out the otp to the controller
        //public string SendOTP(Login login,string apiKey,out int otpValue)
        //{
        //    otpValue = new Random().Next(100000, 999999);
        //    string APIKey = apiKey;
        //    try
        //    {
        //        string recipient = login.CustomerPhoneNumber;
        //        string message = "Your OTP number is " + otpValue + "(Sent by  Etoken Corp)";
        //        string encodedMessage = HttpUtility.UrlEncode(message);
        //        var status = "";
        //        using (var webClient = new WebClient())
        //        {
        //            byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
        //        {
        //            {"apikey",APIKey},
        //            {"numbers",recipient},
        //            {"message",encodedMessage},
        //            {"sender","TXTLCL"}});
        //            string result = System.Text.Encoding.UTF8.GetString(response);
        //            var jsonObject = JObject.Parse(result);
        //            status = jsonObject["status"].ToString();
        //        }
        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ////This will get the sessionOtp and the otp entered by the user and send the result
        //public bool VerifyOTP(string otp,string sessionOtp)
        //{
        //    bool result = false;
        //    if (otp == sessionOtp)
        //    {
        //        result = true;
        //    }
        //    else
        //        result = false;
        //    return result;
        //}
    }
}
