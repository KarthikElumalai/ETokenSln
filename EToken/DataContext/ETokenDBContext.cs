using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.DataContext
{
    public class ETokenDBContext : DbContext
    {
        public ETokenDBContext(DbContextOptions<ETokenDBContext> options)
     : base(options)
        {


        }

        public DbSet<EToken.Models.Customer> Customer { get; set; }

    }
}
