using DataFusionPlus.Application.FactoryPattern;
using DataFusionPlus.Application.Services;
using DataFusionPlus.Infrastructure.DataAccess;


var builder = WebApplication.CreateBuilder(args);

var applicationSettings = builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>();
if (applicationSettings is not null)
{
    builder.Services.AddSingleton(applicationSettings);
}

// Add services to the container.
builder.Services.AddScoped<IProductDataFactory, ConcreteProductDataFactory>();
builder.Services.AddScoped<ExcelDataAccess>();
builder.Services.AddScoped<CsvDataAccess>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
