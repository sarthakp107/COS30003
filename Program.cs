using AWEElectronicsBlazorApp.Core.Implementations;
using AWEElectronicsBlazorApp.Core.Interfaces;
using AWEElectronicsBlazorApp.Core.Services;
using AWEElectronicsBlazorApp.Data;
using AWEElectronicsBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<StoreCatalogue>();
builder.Services.AddSingleton<Inventory>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddScoped<UserSessionService>();

builder.Services.AddTransient<IPaymentMethod, CreditCardPayment>();
builder.Services.AddTransient<IPaymentMethod, PayPalPayment>();

var app = builder.Build();

DataStore.InitializeData();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();