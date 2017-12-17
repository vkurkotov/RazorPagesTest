using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTest.DataLayer.Models;
using RazorPagesTest.Web.Models;

namespace RazorPagesTest.Web.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTest.DataLayer.Models.MovieContext _context;

        public CreateModel(RazorPagesTest.DataLayer.Models.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieModel MovieModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(MovieModel.ToMovie());
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}