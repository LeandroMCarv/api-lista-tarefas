using ApiTarefas.Data;
using Microsoft.EntityFrameworkCore;
//Scalar � a ferramenta��o que utilizaremos para documenta��o da API com interface gr�fica no lugar do SWAGGER que era muito utilizado no dotnet 8
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Controladores s�o respons�veis por lidar com as requisi��es http e retornar as respostas para o cliente
builder.Services.AddControllers();
//Adiciona o Scalar para a documenta��o da API
builder.Services.AddOpenApi();

//Defini que o SQLServer vai ser o provedor de banco de dados utilizado e a string de conex�o que est� no appsettings.json
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //Adiciona o Scalar na pipeline de requisi��es e permite testar endpoints
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
