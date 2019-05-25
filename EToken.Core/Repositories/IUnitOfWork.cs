using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EToken.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
