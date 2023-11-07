using API.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


string ConnectionString = @"Server=AEADLT19726;Initial Catalog=mauidb;MultipleActiveResultSets=true;User ID=sa;Password=Maqta@7788;Encrypt=False";


// Add Db Context
builder.Services.AddDbContextFactory<ApplicationDbContext>(opt => opt.UseSqlServer(ConnectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/test", () => "test");



app.MapGet("/departments", async (ApplicationDbContext db) =>
{
    try
    {
        return await db.Department.ToListAsync();
    }
    catch (Exception)
    {
        throw;
    }
});

app.MapPost("/add-department", async (Department department, ApplicationDbContext db) =>
{
    await db.Department.AddAsync(department);
    db.SaveChanges();
    return Results.Created($"/Departments/{department.Id}", department);

});


app.Run();
