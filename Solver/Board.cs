using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security;

namespace Solver;

public class Board
{
  public List<TileSet> BoardTileSets { get; set; }
  public TileSet? HandTiles { get; set; }
  public List<Tile> AllTiles {get; set; }

  public Board(List<TileSet> boardSets, TileSet handTiles)
  {
   BoardTileSets = boardSets;
   HandTiles = handTiles;
   AllTiles = GetAllTiles();
  }

  public Board(List<TileSet> boardSets)
  {
   BoardTileSets = boardSets;
   AllTiles = GetAllTiles();
  }

  public string GetCurrentSetsAsString() {
    string allSetsAsString = "";
    foreach(TileSet set in BoardTileSets)
    {
      allSetsAsString += set.Tiles.Aggregate("", (acc, x) => acc + x.Number.ToString()) + "\n";

    };
    return allSetsAsString;
  }

  // private void GenerateValidBoardsRecursion(List<Tile> tiles, List<List<TileSet>> validBoards, List<TileSet> currentBoard, TileSet currentSet, int index) {
  //     Tile currentTile = tiles[(index)%tiles.Count];
  //     currentSet.Tiles.Add(currentTile);
  //     TileSet currentSetCopy1 = new([.. currentSet.Tiles]);
  //     List<TileSet> currentBoardCopy1 = new([.. currentBoard]);
  //     List<TileSet> currentBoardCopy2 = new([.. currentBoard]);
  //     // if (currentSet.Tiles.Count > 2 && !currentSet.IsValidSet()) {
  //     //   return;
  //     //   }
  //     if (index == tiles.Count-1){// && currentSet.IsValidSet()) {
  //       currentBoard.Add(currentSet);
  //       validBoards.Add(currentBoard);
  //       return;
  //     }
  //     GenerateValidBoardsRecursion(tiles, validBoards, currentBoardCopy1, currentSetCopy1, index+1);
  //     if (currentSet.Tiles.Count > 2 && currentSet.IsValidSet()) {
  //       currentBoardCopy2.Add(currentSet);
  //       GenerateValidBoardsRecursion(tiles, validBoards, currentBoardCopy2, new TileSet(), index+1);
  //     }
  //   }
  // // }

  private List<T> CopyListMinusIndex<T>(List<T> list, int indexToSkip) {
    return list.Where((val, index) => index != indexToSkip).ToList();
  }

  private List<Tile> GetAllTiles() {
    List<Tile> allTiles = [];
    if (HandTiles != null) {
      allTiles = [.. HandTiles.Tiles, .. BoardTileSets.SelectMany(set => set.Tiles).ToList()];
    } else {
      allTiles = BoardTileSets.SelectMany(set => set.Tiles).ToList();
    }
    return allTiles;
  }

  private void GenerateValidBoardsRecursion(List<Tile> tiles, List<List<TileSet>> validBoards, List<TileSet> currentBoard, TileSet currentSet, int index) {
    if (currentSet.Tiles.Count > 2 && !currentSet.IsValidSet()) { return; }
    if (tiles.Count == 1) {
      currentSet.AddTile(tiles[index]);
      if (currentSet.IsValidSet()) {
          currentBoard.Add(currentSet);
          validBoards.Add(currentBoard);
      }
      return;
    }
    List<TileSet> currentBoardCopy1 = new([.. currentBoard]);
    List<TileSet> currentBoardCopy2 = new([.. currentBoard]);
    TileSet currentSetCopy1 = new([.. currentSet.Tiles]);
    currentSetCopy1.AddTile(tiles[index]);
    List<Tile> newTiles = CopyListMinusIndex(tiles, index);
    for (int i = 0; i < newTiles.Count; i++) {
      GenerateValidBoardsRecursion(newTiles, validBoards, currentBoardCopy1, currentSetCopy1, i);
      currentBoardCopy2.Add(currentSetCopy1);
      if (currentSet.Tiles.Count > 1 && currentSetCopy1.IsValidSet()) {
        GenerateValidBoardsRecursion(newTiles, validBoards, currentBoardCopy2, new TileSet(), i);
        currentBoardCopy2 = new([.. currentBoard]);
      }
    }
  }

  public List<List<TileSet>> GenerateValidBoards() {
    List<List<TileSet>> validBoards = [];
    List<TileSet> currentBoard = [];
    for (var i = 0; i < AllTiles.Count; i++) {
      GenerateValidBoardsRecursion(AllTiles, validBoards, currentBoard, new TileSet(), i);
    }
    // List<List<TileSet>> allValidBoards = validBoards.Where(board => board.All(set => set.IsValidSet())).ToList();
    // HashSet<List<TileSet>> allFilteredValidBoards = allValidBoards.Select(board => {
    //   for (var i = 0; i < board.Count; i++) {
    //     board[i].Tiles.Sort((x, y) => x.Number.CompareTo(y.Number));
    //   }
    //   return board;
    // }).ToHashSet();
    // return allFilteredValidBoards;
    // return allValidBoards;
    return validBoards;
  }

  public bool IsBoardValid () {
    return BoardTileSets.All(set => set.IsValidSet());
  }
}