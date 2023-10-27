using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;
using PRN221_LeNam_BookStore.Pages.Books;

namespace PRN221_LeNam_BookStore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Prj301Se1650Context _context;
        private readonly IConfiguration Configuration;

        public IndexModel(Prj301Se1650Context context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public PaginatedList<BookHe161914> BookHe161914s { get; set; }

        public IList<BookHe161914> BookHe161914 { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {

            if (HttpContext.Session.GetString("account") != null)
            {
                return Redirect("~/");
            }
            else if (HttpContext.Session.GetString("account2") == null)
            {
                return Redirect("~/Login");
            }
            else
            {
                CurrentSort = sortOrder;
                NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                PriceSort = sortOrder == "price" ? "price_desc" : "";

                if (searchString != null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                CurrentFilter = searchString;

                IQueryable<BookHe161914> bookIQ = from b in _context.BookHe161914s
                                                  select b;
                if (!String.IsNullOrEmpty(searchString))
                {
                    bookIQ = bookIQ.Include(b => b.CategoryHe161914).Include(b => b.PublisherHe161914).Where(s => s.Bname.Contains(searchString));
                }
                else
                {
                    bookIQ = bookIQ.Include(b => b.CategoryHe161914).Include(b => b.PublisherHe161914);
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        bookIQ = bookIQ.OrderByDescending(s => s.Bname);
                        break;

                    case "price_desc":
                        bookIQ = bookIQ.OrderByDescending(s => s.Price);
                        break;
                    default:
                        bookIQ = bookIQ.OrderBy(s => s.Bname);
                        break;
                }

                var pageSize = Configuration.GetValue("PageSize", 4);
                BookHe161914s = await PaginatedList<BookHe161914>.CreateAsync(bookIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

                return Page();
            }



        }
    }
}
