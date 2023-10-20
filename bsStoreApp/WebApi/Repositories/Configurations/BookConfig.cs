using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
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
