using StudentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ENROLLMENT_SYSTEMContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors(policy => policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials()
                    );

app.UseAuthorization();

app.MapControllers();

app.Run();
