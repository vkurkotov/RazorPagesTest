using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.DataLayer.Models;
using RazorPagesTest.Web.Models;

namespace RazorPagesTest.Web.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTest.DataLayer.Models.MovieContext _context;

        public DeleteModel(RazorPagesTest.DataLayer.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieModel = MovieModel.FromMovie(await _context.Movies.FindAsync(id));

            if (MovieModel != null)
            {
                _context.Movies.Remove(MovieModel.ToMovie());
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
