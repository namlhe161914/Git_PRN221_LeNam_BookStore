using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public DeleteModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
        {
            _context = context;
        }

        [BindProperty]
      public BookHe161914 BookHe161914 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookHe161914s == null)
            {
                return NotFound();
            }

            var bookhe161914 = await _context.BookHe161914s.Include(m => m.CategoryHe161914).Include(n => n.PublisherHe161914).FirstOrDefaultAsync(m => m.Bid == id);

            if (bookhe161914 == null)
            {
                return NotFound();
            }
            else 
            {
                BookHe161914 = bookhe161914;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookHe161914s == null)
            {
                return NotFound();
            }
            var bookhe161914 = await _context.BookHe161914s.FindAsync(id);

            if (bookhe161914 != null)
            {
                BookHe161914 = bookhe161914;
                _context.BookHe161914s.Remove(BookHe161914);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
