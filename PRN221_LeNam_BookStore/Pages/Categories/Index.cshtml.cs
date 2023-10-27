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
    public class IndexModel : PageModel
    {
        private readonly PRN221_LeNam_BookStore.Models.Prj301Se1650Context _context;

        public IndexModel(PRN221_LeNam_BookStore.Models.Prj301Se1650Context context)
        {
            _context = context;
        }

        public IList<CategoryHe161914> CategoryHe161914 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CategoryHe161914s != null)
            {
                CategoryHe161914 = await _context.CategoryHe161914s.ToListAsync();
            }
        }
    }
}
