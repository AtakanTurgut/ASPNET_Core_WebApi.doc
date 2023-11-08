using Entities.Models;
using Entities.RequestFeatures;
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
        //Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<List<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);

        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
        // Tracking

        Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges);
    }
}
