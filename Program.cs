var builder = WebApplication.CreateBuilder(args);
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