using ApiTarefas.Data;
using Microsoft.EntityFrameworkCore;
//Scalar é a ferramentação que utilizaremos para documentação da API com interface gráfica no lugar do SWAGGER que era muito utilizado no dotnet 8
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Controladores são responsáveis por lidar com as requisições http e retornar as respostas para o cliente
builder.Services.AddControllers();
//Adiciona o Scalar para a documentação da API
builder.Services.AddOpenApi();

//Defini que o SQLServer vai ser o provedor de banco de dados utilizado e a string de conexão que está no appsettings.json
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //Adiciona o Scalar na pipeline de requisições e permite testar endpoints
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
