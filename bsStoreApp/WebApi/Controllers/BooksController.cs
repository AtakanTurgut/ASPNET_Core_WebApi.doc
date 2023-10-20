﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Resolve
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();

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
                var book = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

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

                _context.Books.Add(book);
                _context.SaveChanges();

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
                // check book ?
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null)
                    return NotFound();  // 404

                // check id
                if (id != book.Id)
                    return BadRequest();  // 400

                entity.Title = book.Title;
                entity.Price = book.Price;

                _context.SaveChanges();

                return Ok(book);
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
                var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

                if (entity is null)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with id:{id} could not found."
                    });  // 404

                _context.Books.Remove(entity);
                _context.SaveChanges();

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
            // check book ?
            var entity = _context
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (entity is null)
                return NotFound();  // 404

            bookPatch.ApplyTo(entity);
            _context.SaveChanges();

            return NoContent();  // 204
        }

    }
}
