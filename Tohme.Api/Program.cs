using FluentValidation;
using FluentValidation.AspNetCore;

using Tohme.Application.Command.GymCommands;
using Tohme.Application.Interfaces;
using Tohme.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IGymRepository, GymRepository>();
builder.Services.AddTransient<ITrainerRepository, TrainerRepository>();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateGym).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(CreateGym).Assembly);
builder.Services.AddFluentValidationAutoValidation();
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
