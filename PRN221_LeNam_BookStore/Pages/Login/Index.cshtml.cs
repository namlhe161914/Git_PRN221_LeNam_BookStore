using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using PRN221_LeNam_BookStore.Models;
using System.Configuration;
using System.Text.Json;

namespace PRN221_LeNam_BookStore.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly Prj301Se1650Context _context;

        [BindProperty]
        public Person Person { get; set; } = default!;
        public IndexModel(Prj301Se1650Context context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Person pn)
        {
            string result = "";
            if (HttpContext.Session.GetString("account") != null)
            {
                return RedirectToPage("/Index");
            }
            else if (HttpContext.Session.GetString("account2") != null)
            {
                return RedirectToPage("/Index");
            }

            string err = "";

            if (Person.Email.IsNullOrEmpty() && Person.Password.IsNullOrEmpty())
            {
                ViewData["Error1"] = "Email không để trống";
                ViewData["Error2"] = "Mật khẩu không để trống";
                return Page();
            }
            else
            {
                var person = _context.Persons.SingleOrDefault(p => p.Email == Person.Email
                && p.Password == Person.Password);
                if (person == null)
                {
                    err = "Email hoặc mật khẩu không đúng";
                    ViewData["Error"] = err;
                    return Page();

                }
                else
                {
                    if (person.IsActive == false)
                    {
                        err = "Tài khoản không hoạt động";
                        ViewData["Error"] = "Tài khoản không hoạt động";
                        return Page(); ;
                    }
                    else
                    {
                        if (person.Type == 1)
                        {
                            HttpContext.Session.SetString("account2", JsonSerializer.Serialize(person));
                            result = "/Index";
                        }
                        else
                        {
                            HttpContext.Session.SetString("account", JsonSerializer.Serialize(person));
                            result = "./Index";
                        }
                    }

                }
            }

            return Redirect(result);

        }

    }
}
