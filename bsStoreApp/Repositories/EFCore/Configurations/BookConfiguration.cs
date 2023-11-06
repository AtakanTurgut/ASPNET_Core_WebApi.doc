using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                    new Book { Id = 1, Title = "ASP.NET Framework", Price = 120 },
                    new Book { Id = 2, Title = "MVC Pattern", Price = 150 },
                    new Book { Id = 3, Title = "Javascript", Price = 65 }
                );
        }
    }
}
