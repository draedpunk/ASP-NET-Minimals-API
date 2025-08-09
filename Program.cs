using MINIMAL_API.Infraestrutura.Db;
using MINIMAL_API.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options =>{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (MINIMAL_API.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "696969")
        return Results.Ok("Login feito com sucesso");
    else
        return Results.Unauthorized();
});

app.Run();