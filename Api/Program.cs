using Microsoft.OpenApi.Models;
using Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<LojaDbContext>(configuracao => configuracao.UseInMemoryDatabase("db_loja-virtual"));
// Sugestão: Substitua Loja Virtual pelo nome do projeto de vocês. Isso vai trazer um senço de indentidade.
builder.Services.AddSwaggerGen(configuracao => configuracao.SwaggerDoc("v1", new OpenApiInfo { Title = "Loja Virtual", Version = "v1"}));

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(configuracao =>  configuracao.SwaggerEndpoint("v1/swagger.json", "Loja Virtual"));

app.Run();