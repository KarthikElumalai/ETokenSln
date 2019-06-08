using EToken.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EToken.Core.Services
{
    public interface IAuthy
    {
        Task<string> phoneVerificationCallRequestAsync(string countryCode, string phoneNumber);
        Task<string> phoneVerificationRequestAsync(string countryCode, string phoneNumber);
        Task<TokenVerificationResponse> verifyPhoneTokenAsync(string phoneNumber, string countryCode, string token);
    }
}
