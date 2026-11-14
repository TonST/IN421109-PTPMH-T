using EduHub.Application.Events;
using EduHub.Infrastructure.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddSingleton<InMemoryEventRepository>();
builder.Services.AddSingleton<IEventRepository>(sp => sp.GetRequiredService<InMemoryEventRepository>());
builder.Services.AddSingleton<EmailNotificationService>();
builder.Services.AddSingleton<SmsNotificationService>();
builder.Services.AddSingleton<INotificationService>(sp => sp.GetRequiredService<EmailNotificationService>());
builder.Services.AddSingleton<IEventNotificationFactory, EventNotificationFactory>();
builder.Services.AddScoped<EventService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseStaticFiles();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "EduHub | API Explorer";
        options.InjectStylesheet("/swagger-ui/eduhub.css");
        options.SwaggerEndpoint("/openapi/v1.json", "EduHub API v1");
    });
}
app.MapControllers();

app.Run();
