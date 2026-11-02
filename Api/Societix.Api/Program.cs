using Societix.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SocietyRepository>();

var app = builder.Build();

app.MapGet("/", () => "Societix API is running. Try /api/societies");

app.MapGet("/api/societies", (SocietyRepository repo) =>
    Results.Ok(repo.GetAll()));

app.MapGet("/api/societies/{id:int}", (int id, SocietyRepository repo) =>
{
    var society = repo.GetById(id);
    return society is null
        ? Results.NotFound(new { message = $"Society {id} not found" })
        : Results.Ok(society);
});

app.Run();