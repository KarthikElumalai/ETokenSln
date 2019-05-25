using EToken.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EToken.Infrustructure
{
    public class ETokenDBContext:DbContext
    {
        public ETokenDBContext(DbContextOptions<ETokenDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }   
    }
}
