using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Publisher
{
    public class EditModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public EditModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
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

            var publisherhe161914 =  await _context.PublisherHe161914s.FirstOrDefaultAsync(m => m.Pid == id);
            if (publisherhe161914 == null)
            {
                return NotFound();
            }
            PublisherHe161914 = publisherhe161914;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PublisherHe161914).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherHe161914Exists(PublisherHe161914.Pid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PublisherHe161914Exists(string id)
        {
          return (_context.PublisherHe161914s?.Any(e => e.Pid == id)).GetValueOrDefault();
        }
    }
}
