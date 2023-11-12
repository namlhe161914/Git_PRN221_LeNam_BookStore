using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using PRN221_LeNam_BookStore.Models;
using System.Configuration;

namespace PRN221_LeNam_BookStore.Pages.Carts
{
    public class AddToCartModel : PageModel
    {
        private readonly Prj301Se1650Context _context;

        public AddToCartModel(Prj301Se1650Context context)
        {
            _context = context;
        }

        public class CartItem
        {
            public int quantity { set; get; }
            public BookHe161914 BookHe161914 { get; set; } = default!;
        }

        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string bookId)
        {
            var book = _context.BookHe161914s.Where(b => b.Pid == bookId).FirstOrDefault();
            //if(book == null)
            //{
            //    return Page();
            //}

            var cart = GetCartItems();
            var cartitem = cart.Find(b => b.BookHe161914.Pid == bookId);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, BookHe161914 = book });
            }
            SaveCartSession(cart);

            //return Redirect("./Index");
            return Redirect("./Index");

        }
    }
}
