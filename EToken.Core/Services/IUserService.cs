using EToken.Core.Model;
using EToken.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EToken.Core.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetById(int id);
        Task<UserResponse> CreateAsync(User user, string password);
        Task<UserResponse> UpdateAsync(User user, string password = null);
        Task<UserResponse> DeleteAsync(int id);
    }
}

