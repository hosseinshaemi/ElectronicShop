using System.Security.Claims;
using MyEshop.Data;
using MyEshop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<MyEshopContext, MyEshopContext>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAntiforgery(opt => opt.Cookie.Name = "forgery");
builder.Services.AddAuthentication(CookieAuthenticationDefaults.
AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.LogoutPath = "/Account/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(10);
    option.Cookie.Name = "MyAuth.Cookie";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        if (!context.User.Identity!.IsAuthenticated)
            context.Response.Redirect("/Account/Login");
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin") ?? "False"))
            context.Response.Redirect("/Account/Login");
    }
    await next.Invoke();
});

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();