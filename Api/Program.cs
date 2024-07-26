using Microsoft.OpenApi.Models;
using Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adicione suporte a controllers
builder.Services.AddControllers();
builder.Services.AddDbContext<LojaDbContext>(configuracao => configuracao.UseInMemoryDatabase("db_loja-virtual"));
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Loja Virtual", Version = "v1"}));

var app = builder.Build();

//Reconhça todos os arquivos que são controllers na minha aplicação.
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Minha API V1"));

app.Run();