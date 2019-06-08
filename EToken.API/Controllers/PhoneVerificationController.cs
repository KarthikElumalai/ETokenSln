using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EToken.API.Extensions;
using EToken.API.Model;
using EToken.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EToken.API.Controllers
{
    [
        Route("api/v{version:apiVersion}/verification"),
        Produces("application/json")
    ]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    public class PhoneVerificationController : ControllerBase
    {
        public ILogger<PhoneVerificationController> logger;
        public IAuthy authy;
        public PhoneVerificationController(
           ILoggerFactory loggerFactory,
           IAuthy authy)
        {
            this.logger = loggerFactory.CreateLogger<PhoneVerificationController>();
            this.authy = authy;
        }
        [HttpPost("start")]
        public async Task<IActionResult> start([FromBody]PhoneVerificationRequestModel verificationRequest)
        {
            HttpContext.Session.Set<PhoneVerificationRequestModel>("phone_verification_request", verificationRequest);

            if (ModelState.IsValid)
            {
                string result;
                if (verificationRequest.via == Verification.SMS)
                {
                    result = await authy.phoneVerificationRequestAsync(
                        verificationRequest.CountryCode,
                        verificationRequest.PhoneNumber
                    );
                }
                else
                {
                    result = await authy.phoneVerificationCallRequestAsync(
                        verificationRequest.CountryCode,
                        verificationRequest.PhoneNumber
                    );
                }
                return Ok(result);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> verify([FromBody]TokenVerficationModel tokenVerification)
        {
            var verificationRequest = HttpContext.Session.Get<PhoneVerificationRequestModel>("phone_verification_request");

            if (ModelState.IsValid)
            {
                var validationResult = await authy.verifyPhoneTokenAsync(
                    verificationRequest.PhoneNumber,
                    verificationRequest.CountryCode,
                    tokenVerification.Token
                );

                return Ok(validationResult);

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
   
}