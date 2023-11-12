using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_LeNam_BookStore.Models;
using PRN221_LeNam_BookStore.Pages.Register;
using System.Net.Mail;
using System.Net;

namespace PRN221_LeNam_BookStore.Pages.Login
{
    public class ForgetPasswordModel : PageModel
    {
        private readonly Prj301Se1650Context _context;

        [BindProperty]
        public Person Person { get; set; } = default!;
        public static string RandomPass { get; set; }


        public ForgetPasswordModel(Prj301Se1650Context context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        private string getRandomPass()
        {
            
            if (RandomPass == null)
            {
                Random rd = new Random();
                string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                string numbers = "0123456789";
                string chars = alphabets + numbers;

                RandomPass = "";
                for (int i = 0; i < 10; i++)
                {
                    RandomPass += chars[rd.Next(chars.Length)];
                }
            }

            return RandomPass;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string inputCode = Request.Form["Code"];
            string mail = Request.Form["emailCopy"];


            string code = SendMailForgetModel.getRandomCode();


            if (inputCode != code)
            {
                ViewData["Error5"] = "Invalid Code";
                return Page();
            }
            else
            {
                var person = _context.Persons.SingleOrDefault(p => p.Email == mail);
                if (person == null)
                {
                    ViewData["Error6"] = "Co loi xay ra";
                }
                else
                {
                    person.Password = getRandomPass();
                    _context.Persons.Update(person);
                    await _context.SaveChangesAsync();

                    //send mail
                    var fromAddress = new MailAddress("longvuto13579@gmail.com", "PRN221 - Le Nam");
                    var toAddress = new MailAddress(mail);
                    const string fromPassword = "rwyk gqak itnw riqi";


                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                        Timeout = 20000
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = "Get your new password",
                        Body = "Your new password: " + RandomPass + " \nPlease not share this password to others"
                    })
                    {
                        smtp.Send(message);
                    }
                }

                ViewData["Error6"] = "success check your mail to get new Password";
            }

            return Page();
        }

    }
}
