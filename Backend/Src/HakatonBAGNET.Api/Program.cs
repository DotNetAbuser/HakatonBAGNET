var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelSection = configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
}).UseKestrel();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();