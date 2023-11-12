using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using PRN221_LeNam_BookStore.Models;
using Newtonsoft.Json;

namespace PRN221_LeNam_BookStore.Pages.Login
{
    public class SendMailForgetModel : PageModel
    {
        private readonly Prj301Se1650Context _context;

        [BindProperty]
        public Person Person { get; set; } = default!;
        public static string RandomCode { get; set; }

        public static string MailReceive { get; set; }
        public static string MailNotExist { get; set; }

        public SendMailForgetModel(Prj301Se1650Context context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public static string getRandomCode()
        {
            if (RandomCode == null)
            {
                Random rd = new Random();
                RandomCode = rd.Next(10) + "" + rd.Next(10) + "" + rd.Next(10) + "" + rd.Next(10) + "" + rd.Next(10) + "" + rd.Next(10);
            }

            return RandomCode;
        }
        public IActionResult OnPost(string to)
        {
            MailReceive = to;
            MailNotExist = null;
            //check mail co trong db khong
            var person = _context.Persons.SingleOrDefault(p => p.Email == to);
            if (person == null)
            {
                MailNotExist = "Mail not exist in database";
                return Content(JsonConvert.SerializeObject(new { error = "Mail not exist in database" }), contentType: "application/json");

            }
            else
            {
                //gen code 


                RandomCode = null;

                string body = getRandomCode();

                //send mail
                var fromAddress = new MailAddress("longvuto13579@gmail.com", "PRN221 - Le Nam");
                var toAddress = new MailAddress(to);
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
                    Subject = "Get code get new password",
                    Body = "Your secrete code to when forget password: " + body
                })
                {
                    smtp.Send(message);
                }


            }
            return RedirectToPage("./Login/ForgetPassword");
        }
    }
}
