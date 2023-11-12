using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public DeleteModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
        {
            _context = context;
        }

        [BindProperty]
      public CategoryHe161914 CategoryHe161914 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CategoryHe161914s == null)
            {
                return NotFound();
            }

            var categoryhe161914 = await _context.CategoryHe161914s.FirstOrDefaultAsync(m => m.Cid == id);

            if (categoryhe161914 == null)
            {
                return NotFound();
            }
            else 
            {
                CategoryHe161914 = categoryhe161914;
            }
            return Page();
        }

            public async Task<IActionResult> OnPostAsync(string id)
            {
                if (id == null || _context.CategoryHe161914s == null)
                {
                    return NotFound();
                }
                var categoryhe161914 = await _context.CategoryHe161914s.FindAsync(id);

                var bookhe161914 = await _context.BookHe161914s.Where(x => x.Cid == id).ToListAsync();

                if (categoryhe161914 != null)
                {
                    _context.BookHe161914s.RemoveRange(bookhe161914);
                    _context.CategoryHe161914s.Remove(categoryhe161914);
                    await _context.SaveChangesAsync();
                }

                    return RedirectToPage("./Index");
            }
    }
}
