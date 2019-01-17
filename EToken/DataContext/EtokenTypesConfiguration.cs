using EToken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.DataContext
{
    

        //Created this class , to verify how fluent Api configuration works in Asp.net core.
        //Later we can add all the classes and properties here
        public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
        {


            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(cust => cust.CustomerID);
            }
        }
    
}
