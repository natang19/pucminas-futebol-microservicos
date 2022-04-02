using MediatR;
using pucminas.futebol.core.ModelOptions;
using pucminas.futebol.jogadores.business.Handlers;
using pucminas.futebol.jogadores.infrastructure.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbConnection>(builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddSingleton<IJogadorRepositorio, JogadorRepositorio>();
builder.Services.AddMediatR(typeof(MediatrHandlersEntryPoint));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
