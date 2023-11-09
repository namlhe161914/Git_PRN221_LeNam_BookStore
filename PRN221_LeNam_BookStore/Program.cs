using Microsoft.EntityFrameworkCore;
using PRN221_LeNam_BookStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddScoped<SessionFilterAttribute>();

builder.Services.AddDbContext<Prj301Se1650Context>(options =>
     options.UseSqlServer("name=ConnectionStrings:MyConStr"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    var dbContext = context.RequestServices.GetRequiredService<Prj301Se1650Context>();
//    var books = await dbContext.BookHe161914s.ToListAsync();
//    context.Items["Books"] = books;
//    await next();
//});

app.UseSession();

app.MapRazorPages();

app.Run();
