using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
            // name + Async -> Task<T> -> (implementation) public async Task<T> ... -> await - ...Async();
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        //Book GetOneBookById(int id, bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);

        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
        // Tracking
    }
}
