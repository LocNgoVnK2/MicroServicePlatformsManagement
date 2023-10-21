using MicroservicePlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.JSInterop.Infrastructure;
using MicroservicePlatform.SyncDataServices.Http;
using MicroservicePlatform.SyncDataServices.Http;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// run container docker run -p 8080:80 -d  ten image

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//db context
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
// scope
builder.Services.AddScoped<IPlatFormRepo,PlatFormRepo>();
//http client
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

PrepDb.PrepPopulation(app);

app.Run();
