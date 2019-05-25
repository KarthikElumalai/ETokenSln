using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EToken.Core.Model;
using EToken.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EToken.Infrustructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository,IUserRepositories
    {
        public UserRepository(ETokenDBContext context) : base(context)
        {
           
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == userName);
        }
    }
}
