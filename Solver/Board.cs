using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Solver;

public class Board
{
  public List<TileSet> BoardTileSets { get; set; }
  public TileSet? HandTiles { get; set; }

  public Board(List<TileSet> boardSets, TileSet handTiles)
  {
   BoardTileSets = boardSets;
   HandTiles = handTiles;
  }

  public Board(List<TileSet> boardSets)
  {
   BoardTileSets = boardSets;
  }

  public string GetCurrentSetsAsString() {
    string allSetsAsString = "";
    foreach(TileSet set in BoardTileSets)
    {
      allSetsAsString += set.Tiles.Aggregate("", (acc, x) => acc + x.Number.ToString()) + "\n";

    };
    return allSetsAsString;
  }

  private void GenerateValidBoardsRecursion(List<Tile> allTiles, List<List<TileSet>> validBoards, List<TileSet> currentBoard, TileSet currentSet, int index) {
    for (var i = 0; i < allTiles.Count; i++) {
      Tile currentTile = allTiles[(i+index)%allTiles.Count];
      currentSet.Tiles.Add(currentTile);
      if (currentSet.Tiles.Count > 1 && !currentSet.IsValidSet()) {
        // currentSet = new TileSet();
        return;
        }
      if (index == allTiles.Count-1 && currentSet.IsValidSet()) {
        currentBoard.Add(currentSet);
        validBoards.Add(currentBoard);
        // currentSet = new TileSet();
        return;
      } else if (index == allTiles.Count-1 && !currentSet.IsValidSet()) {
        // currentSet = new TileSet();
        return;
      }
      GenerateValidBoardsRecursion(allTiles, validBoards, currentBoard, currentSet, index+1);
      if (currentSet.Tiles.Count > 1 && currentSet.IsValidSet()) {
        currentBoard.Add(currentSet);
        GenerateValidBoardsRecursion(allTiles, validBoards, currentBoard, new TileSet(), index+1);
      }
    };
  }

  public List<List<TileSet>> GenerateValidBoards() {
    List<Tile> allTiles = [];
    if (HandTiles != null) {
      allTiles = [.. HandTiles.Tiles, .. BoardTileSets.SelectMany(set => set.Tiles).ToList()];
    } else {
      allTiles = BoardTileSets.SelectMany(set => set.Tiles).ToList();
    }
    List<List<TileSet>> validBoards = new List<List<TileSet>>();
    List<TileSet> currentBoard = new List<TileSet>();
    GenerateValidBoardsRecursion(allTiles, validBoards, currentBoard, new TileSet(), 0);
    return validBoards;
  }

  public bool IsBoardValid () {
    return BoardTileSets.All(set => set.IsValidSet());
  }
}