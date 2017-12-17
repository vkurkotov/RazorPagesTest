using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.DataLayer.Models;
using RazorPagesTest.Web.Models;

namespace RazorPagesTest.Web.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContext _context;

        public DetailsModel(MovieContext context)
        {
            _context = context;
        }

        public MovieModel MovieModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieModel = MovieModel.FromMovie(await _context.Movies.SingleOrDefaultAsync(m => m.Id == id));

            if (MovieModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
