using ECommerceShop.Configurations;
using ECommerceShop.DLL;
using Microsoft.EntityFrameworkCore;
using View.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

builder.Services.AddDbContextFactory<ShopContext>(
    options => options.UseMySql(
        builder.Configuration
            .GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8,0,27))
    )
);

builder.Services.AddScoped<IStoreService, StoreService>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();