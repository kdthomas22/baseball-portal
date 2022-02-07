using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public interface ISearchQueries
    {
        Task<PaginatedView<Player>> GetSearchResults(int pageIndex, int pageSize, string searchString);
    }
    public class SearchQueries : ISearchQueries
    {
        private readonly DataContext _context;
        public SearchQueries(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginatedView<Player>> GetSearchResults(int pageIndex, int pageSize, string searchString)
        {
            var query = _context.Players.Where(p => p.Firstname.Contains(searchString.ToLower().Trim())
                                                || p.Lastname.Contains(searchString.ToLower().Trim()));

            var totalCount = await query.CountAsync();
            var results = await query.OrderBy(p => p.Firstname)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new PaginatedView<Player>(pageIndex, pageSize, totalCount, results);
        }
    }
}