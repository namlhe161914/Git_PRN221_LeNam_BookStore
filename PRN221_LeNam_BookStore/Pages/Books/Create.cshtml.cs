using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Books
{
    [TypeFilter(typeof(SessionFilterAttribute))]

    public class CreateModel : PageModel 
    {
        private readonly Prj301Se1650Context _context;
        public CreateModel(Prj301Se1650Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Cid"] = new SelectList(_context.CategoryHe161914s, "Cid", "Cname");
        ViewData["Pid"] = new SelectList(_context.PublisherHe161914s, "Pid", "Pname");
            return Page();
        }

        [BindProperty]
        public BookHe161914 BookHe161914 { get; set; } = default!;

        [BindProperty]
        public IFormFile file { get; set; } = default!;
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

          if ( _context.BookHe161914s == null || BookHe161914 == null)
            {
                return Page();
            }

            if (file == null || file.Length == 0)
            {
                return Content("No file selected.");
            }

            // Lấy tên file và đường dẫn file tới thư mục upload
            var fileName = file.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);


            // Lưu file vào đường dẫn đã chọn
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if(file != null)
            {
                BookHe161914.Image = "images\\" + file.FileName; 
            }

            _context.BookHe161914s.Add(BookHe161914);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
