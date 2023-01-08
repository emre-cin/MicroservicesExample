using Example.Services.Catalog.Core.Mapper;
using Example.Services.Catalog.Core.Repository;
using Example.Services.Catalog.Domain.Models.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

#region Application Settings

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

var assembly = AppDomain.CurrentDomain.Load("Example.Services.Catalog.Core");
builder.Services.AddMediatR(assembly);

builder.Services.AddSingleton<IMapper, Example.Services.Catalog.Core.Mapper.Mapster>();

#endregion

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice Example Catalog Api", Version = "v1" });
});
#endregion

#region Injection

builder.Services.AddTransient(typeof(IRepository<>), typeof(MongoRepository<>));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
