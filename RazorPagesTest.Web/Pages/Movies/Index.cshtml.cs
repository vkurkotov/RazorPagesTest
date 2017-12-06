using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.DataLayer.Models;

namespace RazorPagesTest.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTest.DataLayer.Models.MovieContext _context;

        public IndexModel(RazorPagesTest.DataLayer.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
