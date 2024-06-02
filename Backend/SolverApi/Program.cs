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
    Board board = new Board(tiles);
    board.GenerateValidBoards();
    List<List<TileSet>> result = (board.ValidBoards);
    return Results.Ok(result);
})
.WithName("SolveBoard")
.WithOpenApi();

app.Run();