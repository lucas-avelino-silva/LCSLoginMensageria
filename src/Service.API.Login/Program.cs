using Application.Mapper;
using Application.Service.Interfaces;
using Application.Service.Login;
using Domain.Model.Models.Login.Interfaces;
using Infra.backgroundService;
using Infra.EmailService;
using Infra.Mensageria;
using Infra.Repository.Contexts;
using Infra.Repository.RepositoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILoginApplicationService, LoginApplicationService>();

builder.Services.AddScoped<IAtivarContaApplicationService, AtivarContaApplicationService>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();

builder.Services.AddScoped<IAtivarContaRepository, AtivarContaRepository>();

builder.Services.AddScoped<IMessageBusService, RabbitMqService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddHostedService<NotificarBackgroundService>();

builder.Services.AddAutoMapper(typeof(MapperConfiguration));

builder.Services.AddDbContext<Context>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
