using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        // Resolve
        /*
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }
            -------------------------------
        private readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }
        */

        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                //var books = _context.Books.ToList();
                //var books = _manager.Book.GetAllBooks(false);

                var books = _manager.BookService.GetAllBooks(false);

                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                // LINQ
                /*
                var book = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                
                var book = _manager
                    .Book
                    .GetOneBookById(id, false);
                */

                var book = _manager.BookService.GetOneBookById(id, false);

                if (book is null)
                    return NotFound();  // 404

                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();  // 400

                /*
                _context.Books.Add(book);
                _context.SaveChanges();
                
                _manager.Book.CreateOneBook(book);
                _manager.Save();
                */

                _manager.BookService.CreateOneBook(book);

                return StatusCode(201, book);   // Created
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();  // 400

                // check book ?
                /*
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                    -------------------------------
                var entity = _manager
                    .Book
                    .GetOneBookById(id, true);

                if (entity is null)
                    return NotFound();  // 404

                // check id
                if (id != book.Id)
                    return BadRequest();  // 400

                entity.Title = book.Title;
                entity.Price = book.Price;

                //_context.SaveChanges();

                _manager.Save();
                */

                _manager.BookService.UpdateOneBook(id, book, false);

                //return Ok(book);
                return NoContent();   // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                /*
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                var entity = _manager
                    .Book
                    .GetOneBookById(id, false);

                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with id:{id} could not found."
                    });  // 404
                */
                /*
                _context.Books.Remove(entity);
                _context.SaveChanges();

                _manager.Book.Delete(entity);
                _manager.Save();
                */

                _manager.BookService.DeleteOneBook(id, false);

                return NoContent();  // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PATCH
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                // check book ?
                /*
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                var entity = _manager
                    .Book
                    .GetOneBookById(id, true);
                */

                var entity = _manager
                    .BookService
                    .GetOneBookById(id, true);

                if (entity is null)
                    return NotFound();  // 404

                bookPatch.ApplyTo(entity);
                //_context.SaveChanges();
                //_manager.Book.Update(entity);

                _manager.BookService.UpdateOneBook(id, entity, true);

                return NoContent();  // 204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
