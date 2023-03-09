using WebApi.Application.AppServices;
using WebApi.Application.Interfaces;
using WebApi.Infra.Interfaces;
using WebApi.Infra.Repositories;
using WebApiMentoria;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("WebApiConnection");
builder.Services.AddDbContext<WebApiContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
