using backend.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<ChatHub>("/chatHub");

app.Run();
