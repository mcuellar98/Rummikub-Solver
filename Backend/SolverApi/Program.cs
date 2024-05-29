using Solver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/test", (List<Tile> tiles, ILogger<Program> logger) => {
    logger.LogInformation(tiles[0].Number.ToString());
    logger.LogInformation(tiles[1].Number.ToString());
    logger.LogInformation((tiles.Count).ToString());
})
.WithName("SolveBoard")
.WithOpenApi();

app.Run();