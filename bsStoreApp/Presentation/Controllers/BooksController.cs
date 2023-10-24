using Entities.Exceptions;
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
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            //throw new Exception("!!!!");

            // LINQ
            var book = _manager.BookService.GetOneBookById(id, false);

            /*
            if (book is null)
                //return NotFound();  // 404
                throw new BookNotFoundException(id);
            */

            return Ok(book);
        }

        // POST
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            if (book is null)
                return BadRequest();  // 400

            _manager.BookService.CreateOneBook(book);

            return StatusCode(201, book);   // Created
        }

        // PUT
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            if (book is null)
                return BadRequest();  // 400

            _manager.BookService.UpdateOneBook(id, book, true);

            return NoContent();   // 204
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id, false);

            return NoContent();  // 204
        }

        // PATCH
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check book ?
            var entity = _manager
                .BookService
                .GetOneBookById(id, true);

            /*
            if (entity is null)
                return NotFound();  // 404
            */

            bookPatch.ApplyTo(entity);

            _manager.BookService.UpdateOneBook(id, entity, true);

            return NoContent();  // 204
        }

    }
}
