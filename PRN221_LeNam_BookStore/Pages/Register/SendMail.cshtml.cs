using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Register
{
    public class SendMailModel : PageModel
    {

        public static string RandomCode { get; set; }

        public static string MailReceive { get; set; }

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
            //gen code 

            MailReceive = to;

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
                Subject = "Get code",
                Body = "Your secrete code: " + body
            })
            {
                smtp.Send(message);
            }

            return RedirectToPage("./Index");
        }
    }
}
