using Astroshop.Core.Interfaces;
using DAL.MySQL;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

// Сервис конфигурации
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.WebHost.UseNLog();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IUserCart, UserCartService>();
builder.Services.AddScoped<IProduct, ProductService>();

builder.Services.AddCors(opt => opt.AddPolicy("Policy",
    builder => builder.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("*")));
builder.Services.AddDbContext<EfContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Конфигурация
var app = builder.Build();
app.Logger.LogInformation("Log");
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseCors("Policy");
app.UseEndpoints(endpoints => endpoints.MapControllers());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Запуск
app.Run();