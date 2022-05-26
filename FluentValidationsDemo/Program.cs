using FluentValidation.AspNetCore;
using FluentValidationsDemo.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BatchValidator>());
builder.Services.AddMvcCore().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = string.Join('\n', context.ModelState.Values.Where(v => v.Errors.Count > 0)
           .SelectMany(v => v.Errors)
           .Select(v => v.ErrorMessage));
        var Errors = "";
        var correlationId = "";
        Error err = new Error
        {
            Source="string",
            Description="string"
        };

        return new BadRequestObjectResult(new
        {
            correlationId="string",
            Errors = err
        }); ;
    };
});
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
