using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Publisher
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public CreateModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PublisherHe161914 PublisherHe161914 { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PublisherHe161914s == null || PublisherHe161914 == null)
            {
                return Page();
            }

            _context.PublisherHe161914s.Add(PublisherHe161914);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
