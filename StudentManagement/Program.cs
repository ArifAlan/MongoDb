using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<StudentStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSettings:ConnectionString")));

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
