using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.DataLayer.Models;
using RazorPagesTest.Web.Models;

namespace RazorPagesTest.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        public IList<MovieModel> MovieModels { get;set; }
        
        public SelectList Genres { get; set; }

        public string MovieGenre { get; set; }

        public async Task OnGetAsync(string searchString, string movieGenre)
        {
            var movies =  _context
                .Movies
                .Select(x => x);

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(x => x.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre.Contains(movieGenre));
            }

            MovieModels = await movies
                .Select(x => MovieModel.FromMovie(x))
                .ToListAsync();

            Genres = new SelectList(await _context
                .Movies
                .Select(x => x.Genre)
                .Distinct()
                .ToListAsync());
        }
    }
}
