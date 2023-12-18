using SmartEmail.Application.Extensions;
using SmartEmail.Core.Models.Ui.Settings;
using SmartEmail.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration.GetSection("Settings").Get<AppSettings>()!);
builder.Services
    .AddInfrastructure()
    .AddAplication();

var app = builder.Build();

app.Run();
