using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
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

        public async Task OnGetAsync(string cid, string txt)
        {

            if (!cid.IsNullOrEmpty())
            {
                BookHe161914 = await _context.BookHe161914s
                .Include(b => b.CategoryHe161914)
                .Where(c => c.Cid == cid).ToListAsync();
            }
            else if (txt != null)
            {
                List<BookHe161914> search = new List<BookHe161914>();
                List<BookHe161914> Books = new List<BookHe161914>();
                Books = _context.BookHe161914s.ToList();
                if (txt != null)
                {
                    foreach (BookHe161914 book in Books)
                    {
                        string title = ConvertToUnsignString(book.Bname);
                        txt = ConvertToUnsignString(txt);
                        if (title.ToLower().Contains(txt.ToLower(), StringComparison.OrdinalIgnoreCase))
                        {
                            search.Add(book);
                        }

                    }
                    BookHe161914 = search;

                }
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

        private string ConvertToUnsignString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            string[] signs = new string[] {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    str = str.Replace(signs[i][j], signs[0][i - 1]);
                }
            }

            return str;
        }

    }
}