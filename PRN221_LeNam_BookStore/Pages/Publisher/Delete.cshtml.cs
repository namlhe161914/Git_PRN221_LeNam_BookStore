using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Publisher
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public DeleteModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
        {
            _context = context;
        }

        [BindProperty]
      public PublisherHe161914 PublisherHe161914 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.PublisherHe161914s == null)
            {
                return NotFound();
            }

            var publisherhe161914 = await _context.PublisherHe161914s.FirstOrDefaultAsync(m => m.Pid == id);

            if (publisherhe161914 == null)
            {
                return NotFound();
            }
            else 
            {
                PublisherHe161914 = publisherhe161914;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.PublisherHe161914s == null)
            {
                return NotFound();
            }
            var publisherhe161914 = await _context.PublisherHe161914s.FindAsync(id);

            if (publisherhe161914 != null)
            {
                PublisherHe161914 = publisherhe161914;
                _context.PublisherHe161914s.Remove(PublisherHe161914);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
