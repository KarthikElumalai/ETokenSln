using EToken.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EToken.Core.Services.Communication
{
    public class UserResponse:BaseResponse
    {
        public User user { get; private set; }
        public UserResponse(bool success, string message, User User) : base(success, message)
        {
            user = User;
        }
        /// <summary>
        /// Create a success response
        /// </summary>
        /// <param name="User">Saved User</param>
        /// <returns>Response</returns>
        public UserResponse(User User) : this(true, string.Empty, User)
        {

        }
        /// <summary>
        /// Creates an error message
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, message, null)
        {

        }
    }
}
