using EToken.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EToken.Core.Repositories
{
    public interface IUserRepositories
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUserName(string userName);
        void Update(User user);
        void Remove(User user);
    }
}
