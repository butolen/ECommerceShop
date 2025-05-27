using ECommerceShop.Configurations;
using ECommerceShop.DLL;

using Microsoft.EntityFrameworkCore;
using View.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ Service-Registrierung VOR builder.Build()
builder.Services.AddDbContextFactory<ShopContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    )
);

builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<LocalStorageService>();

builder.Services.AddScoped<SessionState>();
builder.Services.AddSingleton<CartService>();

var app = builder.Build();

// Middleware & Routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();