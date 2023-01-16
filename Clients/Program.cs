using Clients.Core.Interfaces.Repositories;
using Clients.DataAccess;
using Clients.DataAccess.Repositories;
using Clients.Helpers;
using Clients.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//EF Context configuration
builder.Services.AddDbContext<ClientsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection"), b => b.MigrationsAssembly("Clients"));
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//repositories
builder.Services.AddScoped<IBillRepository, BillRepository>();

//services
builder.Services.AddTransient(typeof(BillsService));


builder.Services.AddCors(op =>
{
    op.AddPolicy("Cors", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("Cors");
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
