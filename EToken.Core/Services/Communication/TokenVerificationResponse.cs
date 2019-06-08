using System;
using System.Collections.Generic;
using System.Text;

namespace EToken.Core.Services.Communication
{
    public class TokenVerificationResponse
    {
        public TokenVerificationResponse(string message, bool succeeded = true)
        {
            this.Message = message;
            this.Succeeded = succeeded;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
