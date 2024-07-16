using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//Adicione suporte .
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1"});
});

var app = builder.Build();
//Reconhça todos os arquivos que são controllers na minha aplicação.
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "Minha API V1");
});

app.MapGet("/", () => "Hello World!");

app.Run();
