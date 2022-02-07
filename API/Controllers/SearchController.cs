using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchQueries _searchQueries;
        public SearchController(ISearchQueries searchQueries)
        {
            _searchQueries = searchQueries;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedView<Player>>> GetSearchResults([FromQuery] string searchString,
                                                                                [FromQuery] int pageIndex = 0,
                                                                                [FromQuery] int pageSize = 10)
        {
            var results = await _searchQueries.GetSearchResults(pageIndex, pageSize, searchString);
            return Ok(results);
        }
    }
}