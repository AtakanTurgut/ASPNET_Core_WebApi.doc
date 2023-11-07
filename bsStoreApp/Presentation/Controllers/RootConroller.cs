using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "v1")] // Swagger  -  Documenting
    public class RootConroller : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public RootConroller(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        // GET
        [HttpGet(Name = "GetRoot")]
        public async Task<IActionResult> GetRoot([FromHeader(Name = "Accept")] string mediaType)  // - Route - Query String - Header -
        {
            if (mediaType.Contains("application/vnd.atakanturgut.apiroot"))
            {
                var list = new List<Link>()
                {
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new { }),
                        Rel = "_self",
                        Method = "GET"
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.GetAllBooksAsync), new { }),
                        Rel = "books",
                        Method = "GET"
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.CreateOneBookAsync), new { }),
                        Rel = "books",
                        Method = "POST"
                    }
                };

                return Ok(list);
            }

            return NoContent();     // 204
        }

    }
}
