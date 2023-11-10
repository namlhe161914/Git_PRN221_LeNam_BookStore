using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;
using System.Net;
using System.Net.Mail;
using PRN221_LeNam_BookStore.Pages;
using Humanizer;

namespace PRN221_LeNam_BookStore.Pages.Register
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

        public async Task<IActionResult> OnPostAsync()
        {
            string inputCode = Request.Form["Code"];

            string result = "";

            string code = SendMailModel.getRandomCode();

            string err = "";

            if (Person.Email == null && Person.Password == null)
            {
                ViewData["Error2"] = "Mật khẩu không để trống";
                return Page();
            }
            else if (Person.Fullname == null)
            {
                ViewData["Error4"] = "Tên không được trống";
                return Page();
            }
            else if (Person.Gender == null)
            {
                ViewData["Error3"] = "Vui lòng chọn giới tính";
                return Page();
            }
            else if (Person.Gender == null)
            {
                ViewData["Error3"] = "Vui lòng chọn giới tính";
                return Page();
            }
            else if (inputCode != code)
            {
                ViewData["Error5"] = "Invalid Code";
                return Page();
            }
            else
            {
                var person = _context.Persons.SingleOrDefault(p => p.Email == Person.Email);

                if (person != null)
                {
                    err = "Email đã tồn tại";
                    ViewData["Error"] = err;
                    return Page();

                }
                else
                {
                    Person.Type = 2;
                    Person.IsActive = true;
                    _context.Persons.Add(Person);
                    await _context.SaveChangesAsync();
                    if (_context.SaveChanges() > 0)
                    {
                        TempData["sc"] = "Đăng kí thành công";
                    }

                    result = "./Login";

                }

            }

            return Redirect(result);
        }

    }
}
