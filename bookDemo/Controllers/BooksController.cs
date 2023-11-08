using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books.ToList();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            // LINQ
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (book is null)
                return NotFound();  // 404

            return Ok(book);
        }

        // POST
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                ApplicationContext.Books.Add(book);

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
            // check book ?
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound();  // 404

            // check id
            if (id != book.Id)
                return BadRequest();  // 400

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;

            ApplicationContext.Books.Add(book);

            return Ok(book);
        }

        // DELETE
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();

            return NoContent();  // 204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Book with id:{id} could not found."
                });  // 404

            ApplicationContext.Books.Remove(entity);

            return NoContent();  // 204
        }

        // PATCH
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check book ?
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound();  // 404

            bookPatch.ApplyTo(entity);

            return NoContent();  // 204
        }
    }
}
