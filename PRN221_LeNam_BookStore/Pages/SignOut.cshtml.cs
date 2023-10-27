using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_LeNam_BookStore.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("account") != null || HttpContext.Session.GetString("account2") != null)
            {
                HttpContext.Session.Remove("account");
                HttpContext.Session.Remove("account2");
            }

            return Redirect("/Index");
        }
    }
}
