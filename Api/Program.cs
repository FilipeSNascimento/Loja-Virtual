var builder = WebApplication.CreateBuilder(args);

//Adicione suporte .
builder.Services.AddControllers();

var app = builder.Build();


//Reconhça todos os arquivos que são controllers na minha aplicação.
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
