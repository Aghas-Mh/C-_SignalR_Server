using Microsoft.AspNetCore.Cors.Infrastructure;
using SignalRChat;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // Разрешить любой источник
            .AllowCredentials());
});

var app = builder.Build();

app.UseRouting();

app.UseCors("CorsPolicy");

app.MapHub<ChatHub>("/chatHub");

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

static void CorsPolicy(CorsPolicyBuilder builder)
{
    builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader();
}
