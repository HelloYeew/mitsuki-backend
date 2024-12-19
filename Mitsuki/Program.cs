using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mitsuki;
using Mitsuki.Controllers;
using Mitsuki.Extensions;
using Mitsuki.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var frontendCorsPolicy = "FrontEnd";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MitsukiDatabaseContext>(
    options => options.UseSqlite("Data Source=app.db"));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<MitsukiDatabaseContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: frontendCorsPolicy,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4321")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.MapCustomIdentityApi<User>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(frontendCorsPolicy);

app.Run();