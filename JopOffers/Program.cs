using JopOffers.Models.Data;
using JopOffers.Models.Repository;
using JopOffers.Models.Repository.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );

builder.Services.AddTransient<IUnitOfWork , UnitOfWork>();
builder.Services.AddScoped<IUserRepository , UserRepository>();
builder.Services.AddScoped<IJobsRepository , JobsRepository>();
builder.Services.AddScoped<IApplies , Applies>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();


var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
