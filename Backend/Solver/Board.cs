using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security;

namespace Solver;

public class Board
{
  public List<Tile> AllTiles {get; set; }
  public List<List<TileSet>> ValidBoards {get; set;}
  private List<string> ValidBoardTracker {get; set;}
  private Dictionary<int, string[]> AvailableColorsByNumbers {get; set;}
  private Dictionary<string, int[]> AvailableNumbersByColors {get; set;}

  public Board(List<Tile> tiles) {
    AllTiles = tiles;
    ValidBoards = [];
    ValidBoardTracker = [];
    //AvailableColorsByNumbers = AllTiles.GroupBy(x => x.Number).toDictionary(x => x.Number, x => [] ?? )
  }

  private List<T> CopyListMinusIndex<T>(List<T> list, int indexToSkip) {
    return list.Where((val, index) => index != indexToSkip).ToList();
  }

  private bool IsAlreadyInValidBoards(string trackerString) {
    return ValidBoardTracker.Contains(trackerString);
  }

  private string getTrackerString(List<TileSet> board) {
    var trackerString = "";
    board = [.. board.OrderBy(set => set.Tiles[0].Number).ThenBy(set => set.Tiles.Count)];
    for (int i = 0; i < board.Count; i++) {
      TileSet set = board[i];
      set.Tiles = [.. set.Tiles.OrderBy(tile => tile.Number).ThenBy(tile => tile.Color)];
      trackerString += set.Tiles.Aggregate("", (acc, tile) => acc + tile.Number.ToString() + tile.Color);
      if (i != board.Count-1) {trackerString += " ";}
    }
    return trackerString;
  }

  private void RecursivelyGenerateValidBoards(List<Tile> tiles, List<TileSet> currentBoard, TileSet currentSet, int index) {
    if (ValidBoards.Count() < 1) {
      if (currentSet.Tiles.Count > 2 && !currentSet.IsValidSet()) { return; }
      if (tiles.Count == 1) {
        currentSet.AddTile(tiles[index]);
        if (currentSet.IsValidSet()) {
            currentBoard.Add(currentSet);
            string trackerString = getTrackerString(currentBoard);
            if (!IsAlreadyInValidBoards(trackerString)) {
              ValidBoards.Add(currentBoard);
              ValidBoardTracker.Add(trackerString);
            }
        }
        return;
      }
      List<TileSet> currentBoardCopy1 = new([.. currentBoard]);
      List<TileSet> currentBoardCopy2 = new([.. currentBoard]);
      TileSet currentSetCopy1 = new([.. currentSet.Tiles]);
      currentSetCopy1.AddTile(tiles[index]);
      List<Tile> newTiles = CopyListMinusIndex(tiles, index);
      for (int i = 0; i < newTiles.Count; i++) {
        RecursivelyGenerateValidBoards(newTiles, currentBoardCopy1, currentSetCopy1, i);
        currentBoardCopy2.Add(currentSetCopy1);
        if (currentSet.Tiles.Count > 1 && currentSetCopy1.IsValidSet()) {
          RecursivelyGenerateValidBoards(newTiles, currentBoardCopy2, new TileSet(), i);
          currentBoardCopy2 = new([.. currentBoard]);
        }
      }
    }
  }

  public List<List<TileSet>> GenerateValidBoards() {
    List<TileSet> currentBoard = [];
    for (var i = 0; i < AllTiles.Count; i++) {
      RecursivelyGenerateValidBoards(AllTiles, currentBoard, new TileSet(), i);
    }
    return ValidBoards;
  }

  // public bool IsBoardValid () {
  //   return BoardTileSets.All(set => set.IsValidSet());
  // }
}