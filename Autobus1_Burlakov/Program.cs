using Autobus1_Burlakov.Data;
using Autobus1_Burlakov.Data.Repositories;
using Autobus1_Burlakov.Models;
using Autobus1_Burlakov.Models.DTOs;
using Autobus1_Burlakov.Utilities.Extensions;
using Autobus1_Burlakov.Utilities.Services;
using Autobus1_Burlakov.Utilities.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<Autobus1dbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("autobus1Db"),
        ServerVersion.Parse(builder.Configuration.GetSection("serverVersion").Value));
});
builder.Services.AddScoped<IUrlDataRepository, UrlDataRepository>();
builder.Services.AddScoped<IValidator<UrlsDataDto>, UrlDataDtoValidator>();
builder.Services.AddScoped<IValidator<Urlsdatum>, UrlDataValidator>();
builder.Services.AddSingleton<IUrlProcessor,UrlProcessor>();
var app = builder.Build();

app.InitMigration();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapGet("/{shortUrl}", async (string shortUrl, IUrlDataRepository repository) =>
{
    if (string.IsNullOrEmpty(shortUrl)) Results.Redirect("/");
    var urlDatum = await repository.GetUrlDatumByShortUrl(shortUrl);
    if (urlDatum != null && urlDatum.PassageCounter != 0)
    {
        urlDatum.PassageCounter--;
        await repository.Update(urlDatum);
        return Results.Redirect(urlDatum.FullUrl ?? $"/?Error=NotFound");
    }
    else 
        return Results.Redirect($"/?Error=ForbiddenUrl");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
