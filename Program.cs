using LABAPI.Middleware;
using LABAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

// Enable Swagger UI in all environments so reviewers can test the API.
app.UseSwagger();
app.UseSwaggerUI();

// Redirect root to Swagger UI to avoid 404 on '/'
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
