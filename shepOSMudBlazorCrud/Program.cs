using FastReport.DataVisualization.Charting;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor.Services;
using shepOS;
using shepOSMudBlazorCrud.Repository;
using shepOSMudBlazorCrud.Services;
using System.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddFastReport();

builder.Services.AddScoped<IUserDataSchemaService, UserDataSchemaService>();
builder.Services.AddScoped<IComboboxItemService, ComboboxItemService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<shepOSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("shepOSConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DataSetService>();

builder.Services.AddLocalization(); 

builder.Services.AddScoped<Navigation>();

shepOSLibrary.sAppWebPath = builder.Environment.ContentRootPath;

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

string[] supportedCultures = new[] { "pt", "en", "es" };
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
                                                    .SetDefaultCulture(supportedCultures[0])
                                                    .AddSupportedCultures(supportedCultures)
                                                    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseFastReport();

app.Run();
