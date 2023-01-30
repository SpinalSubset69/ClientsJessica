using Clients.Core.Interfaces;
using Clients.Core.Interfaces.Repositories;
using Clients.DataAccess;
using Clients.DataAccess.Repositories;
using Clients.Helpers;
using Clients.Quartz;
using Clients.Services;
using Clients.Utils;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//EF Context configuration
builder.Services.AddDbContext<ClientsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("prodConnection"), b => b.MigrationsAssembly("Clients"));
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//repositories
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IMailRepository, MailRepository>();
builder.Services.AddScoped<IEmail, Emails>();
builder.Services.AddScoped<IExcel, Excel>();

//services
builder.Services.AddTransient(typeof(BillsService));


//quarts
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    var jobKey = new JobKey("excel-job");

    q.AddJob<ExcelJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
    .ForJob(jobKey)
    .WithIdentity("Excel Job -- Trigger")
    .WithCronSchedule("0 25 14 1/1 * ? *"));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

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
