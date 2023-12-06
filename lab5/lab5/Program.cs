using Auth0.AspNetCore.Authentication;
using lab5.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = "dev-scsneb7gbc2lrzrb.us.auth0.com";
    options.ClientId = "iszkIPtXsb9JHBytoXFtYpWzE1wwNEvM";
});
builder.Services.ConfigureSameSiteExtension();
builder.Services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options => {
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run("http://localhost:3000");