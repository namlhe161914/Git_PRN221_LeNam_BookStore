using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

namespace PRN221_LeNam_BookStore.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Prj301Se1650Context _context;

        public EditModel(Prj301Se1650Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BookHe161914 BookHe161914 { get; set; } = default!;
                
        [BindProperty]
        public IFormFile file { get; set; } = default!;

        [BindProperty]
        public string oldPath { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookHe161914s == null)
            {
                return NotFound();
            }

            var bookhe161914 =  await _context.BookHe161914s.FirstOrDefaultAsync(m => m.Bid == id);
            if (bookhe161914 == null)
            {
                return NotFound();
            }

           BookHe161914 = bookhe161914;
           ViewData["Cid"] = new SelectList(_context.CategoryHe161914s, "Cid", "Cname");
           ViewData["Pid"] = new SelectList(_context.PublisherHe161914s, "Pid", "Pname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}


            // Lấy tên file và đường dẫn file tới thư mục upload
            if (file != null)
            {
                 var fileName = file.FileName;
                 var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                // Lưu file vào đường dẫn đã chọn
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                BookHe161914.Image = "images\\" + file.FileName;
            }
            else
            {   
                BookHe161914.Image = oldPath;
            }


            _context.Attach(BookHe161914).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookHe161914Exists(BookHe161914.Bid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookHe161914Exists(int id)
        {
          return (_context.BookHe161914s?.Any(e => e.Bid == id)).GetValueOrDefault();
        }
    }
}
