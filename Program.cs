using Microsoft.EntityFrameworkCore;
using TimeTableProject.Data;
using TimeTableProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<TimeTableService>();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin()
                               .AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();