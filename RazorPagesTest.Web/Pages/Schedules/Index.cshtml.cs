using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.Web.Models;
using RazorPagesTest.Web.Utilities;

namespace RazorPagesTest.Web.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Models.MovieContext _context;

        public IndexModel(DataLayer.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<ScheduleModel> Schedule { get; private set; }

        public async Task OnGetAsync()
        {
            Schedule = await _context
                .Schedules
                .AsNoTracking()
                .Select(x => ScheduleModel.FromSchedule(x))
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                Schedule = await _context
                    .Schedules
                    .AsNoTracking()
                    .Select(x => ScheduleModel.FromSchedule(x))
                    .ToListAsync();
                return Page();
            }

            var publicScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPublicSchedule, ModelState);

            var privateScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPrivateSchedule, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                Schedule = await _context
                    .Schedules
                    .AsNoTracking()
                    .Select(x => ScheduleModel.FromSchedule(x))
                    .ToListAsync();
                return Page();
            }

            var scheduleModel = new ScheduleModel()
            {
                PublicSchedule = publicScheduleData,
                PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
                PrivateSchedule = privateScheduleData,
                PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length,
                Title = FileUpload.Title,
                UploadDt = DateTime.UtcNow
            };

            _context.Schedules.Add(scheduleModel.ToSchedule());
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}