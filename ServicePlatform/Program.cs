using MicroservicePlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.JSInterop.Infrastructure;
using MicroservicePlatform.SyncDataServices.Http;

using Microsoft.IdentityModel.Tokens;
using MicroservicePlatform.AsyncDataServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// run container docker run -p 8080:80 -d  ten image

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IWebHostEnvironment _env = builder.Environment;
IConfiguration configuration = builder.Configuration;
//db context
if(_env.IsProduction()){
    Console.WriteLine("Use MS SQL Database");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("PlatformsConn")));
}else{
    Console.WriteLine("Use MEMORY");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
}

// scope
builder.Services.AddScoped<IPlatFormRepo,PlatFormRepo>();
//http client
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Add rabbit mq message bus
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
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

PrepDb.PrepPopulation(app,_env.IsProduction());

app.Run();
