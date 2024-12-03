using AppWithoutMediatR.Application.AddGoat;
using AppWithoutMediatR.Application.AddGoatWithMediatR;
using AppWithoutMediatR.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddGoatHandler, AddGoatHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/goat", async (
            [FromServices] IAddGoatHandler handler,
            GoatToCreate input)
        =>
    {
        var command = new AddGoatCommand(input.Name, input.Description);
        return await handler.Handle(command);
    })
    .WithOpenApi();

app.MapPost("/goat/with-mediatr", async (
            [FromServices] ISender mediator,
            GoatToCreate input)
        =>
    {
        var command = new AddGoatWithMediatRCommand(input.Name, input.Description);
        return await mediator.Send(command);
    });

app.Run();