using EToken.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EToken.Infrustructure.Persistence.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ETokenDBContext _context;
        public UnitOfWork(ETokenDBContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
