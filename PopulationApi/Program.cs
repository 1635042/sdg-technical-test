using Microsoft.EntityFrameworkCore;
using PopulationApi.Data;
using PopulationApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=population.db"));

builder.Services.AddHttpClient<CountryService>(); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// MIDDLEWARES
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
