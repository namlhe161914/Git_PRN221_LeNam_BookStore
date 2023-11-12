using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Carts
{
    public class IndexModel : PageModel
    {
        public class CartItem
        {
            public int quantity { set; get; }
            public BookHe161914 BookHe161914 { get; set; } = default!;
        }
        public void OnGet()
        {
        }
    }
}
