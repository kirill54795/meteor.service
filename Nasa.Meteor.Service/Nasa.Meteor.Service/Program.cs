using Meteor.Service.BL.Extensions;
using Meteor.Service.BL.Services;
using Meteor.Service.DataLayer.Repositories;
using Meteor.Service.Share.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMeteorService, MeteorService>();
builder.Services.RegisterMeteorDataLayer();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddScoped<MeteorServiceAbstract, NasaMeteorService>();
builder.Services.AddScoped<IMeteorRepository, MeteorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<MyExceptionMiddleware>(); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();