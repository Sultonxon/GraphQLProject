using GraphQLServer.Data;
using GraphQLServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyHotelDbContext>(o => o.UseInMemoryDatabase("hotel"));
builder.Services.AddTransient<ReservationRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseCors(b =>
{
b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
var scope = app.Services.CreateScope();
using (var db = scope.ServiceProvider.GetRequiredService<MyHotelDbContext>())
{
    db.Database.EnsureCreated();
}

    app.Run();
