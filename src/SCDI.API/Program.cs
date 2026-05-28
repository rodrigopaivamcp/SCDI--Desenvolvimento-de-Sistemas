using Microsoft.EntityFrameworkCore;
using SCDI.Application.Services;
using SCDI.Domain.Interfaces;
using SCDI.Infrastructure.Data;
using SCDI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScdiDbContext>(options =>
    options.UseNpgsql(connectionString));

// --- REGISTRO DA ETAPA 5 (Injeção de Dependência) ---
builder.Services.AddScoped<IInsumoRepository, InsumoRepository>();
builder.Services.AddScoped<InsumoAppService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
