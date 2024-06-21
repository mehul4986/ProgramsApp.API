using Microsoft.OpenApi.Models;
using ProgramsApp.API.Repositories;
using ProgramsApp.API.Repositories.Interfaces;
using ProgramsApp.API.Services;
using ProgramsApp.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Programs - Applications API", Version = "v1" });
});

builder.Services.AddLogging((loggingBuilder) =>
{
    loggingBuilder.SetMinimumLevel(LogLevel.Error); // Update default MEL-filter
});

builder.Services.AddSingleton<IApplicationFormRepository, ApplicationFormRepository>();
builder.Services.AddSingleton<IApplicationFormService, ApplicationFormService>();

builder.Services.AddSingleton<ISubmitAppService, SubmitAppService>();
builder.Services.AddSingleton<ISubmitAppRepository, SubmitAppRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllOrigins",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllOrigins");

app.MapControllers();

app.Run();
