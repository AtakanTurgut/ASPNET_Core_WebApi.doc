using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0", Deprecated = true)]      //  Deprecated   -   Conventions
    //[ApiVersion("2.0")]
    [ApiController]
    [Route("api/books")]
    //[Route("api/{v:apiversion}/books")]
    [ApiExplorerSettings(GroupName = "v2")] // Swagger  -  Documenting
    public class BooksV2Controller : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);

            var booksV2 = books.Select(b => new
            {
                Title = b.Title,
                Id = b.Id,
            });

            return Ok(booksV2);
        }
    }
}
