using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using VirtualPetAdoptionCenter.Core;
using VirtualPetAdoptionCenter.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Google;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllersWithViews(options =>
{
});

builder.Services.AddRazorPages().AddMicrosoftIdentityUI();

builder.Services.RegisterCoreConfiguration(builder.Configuration);
builder.Services.RegisterCoreDependencies();

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("VirtualPetAdoptionCenterDb");
builder.Services.AddDbContext<VirtualPetAdoptionCenterDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEncryption, Encryption>();
builder.Services.AddScoped<IGroomService, GroomService>();
builder.Services.AddScoped<IAchievementService,AchievementService>();

/*builder.Services.AddScoped<INotificationService, EmailNotificationService() >;
*/
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        googleOptions.ClientId = "626765526510-8r5dmafp616hbsjr47ui2hrj102o4ste.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
        googleOptions.CallbackPath = "/account/GoogleLoginCallback";
    });

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".VirtualPetAdoptionCenter.Session";
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
