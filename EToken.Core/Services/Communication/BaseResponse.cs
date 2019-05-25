using System;
using System.Collections.Generic;
using System.Text;

namespace EToken.Core.Services.Communication
{
    public class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
