using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRN221_LeNam_BookStore.Models;
using System.Security.Cryptography;

namespace PRN221_LeNam_BookStore.Pages
{
    public class IndexModel : PageModel
    {

        private readonly Prj301Se1650Context _context;

        public IList<BookHe161914> BookHe161914 { get; set; } = default!;
        public IList<CategoryHe161914> CategoryHe161914 { get; set; } = default!;

        public IndexModel(Prj301Se1650Context context)
        {
            _context = context;

        }

        public async Task OnGetAsync(string cid)
        {

            
            if (!cid.IsNullOrEmpty())
            {
                BookHe161914 = await _context.BookHe161914s
                .Include(b => b.CategoryHe161914)
                .Where(c => c.Cid == cid).ToListAsync();
            }
            else
            {
                if (_context.BookHe161914s != null)
                {
                    BookHe161914 = await _context.BookHe161914s
                    .Include(b => b.CategoryHe161914)
                    .Include(b => b.PublisherHe161914).ToListAsync();
                }
            }



            if (_context.CategoryHe161914s != null)
            {
                CategoryHe161914 = await _context.CategoryHe161914s.ToListAsync();
            }
        }
    }
}