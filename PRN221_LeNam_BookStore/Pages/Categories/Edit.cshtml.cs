using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public EditModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
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

            var categoryhe161914 =  await _context.CategoryHe161914s.FirstOrDefaultAsync(m => m.Cid == id);
            if (categoryhe161914 == null)
            {
                return NotFound();
            }
            CategoryHe161914 = categoryhe161914;
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

            _context.Attach(CategoryHe161914).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryHe161914Exists(CategoryHe161914.Cid))
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

        private bool CategoryHe161914Exists(string id)
        {
          return (_context.CategoryHe161914s?.Any(e => e.Cid == id)).GetValueOrDefault();
        }
    }
}
