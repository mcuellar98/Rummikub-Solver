using System.Runtime.CompilerServices;

namespace Solver;

public class TileSet
{
  // public string Type { get; set; }
  // public int Size { get; set; }
  public List<Tile> Tiles { get; set; } = new List<Tile>();

  public TileSet(List<Tile> tiles)
  {
    // Type = type;
    Tiles = tiles;
  }

  public TileSet() {
    // type
    Tiles = new List<Tile>();
  }

  private bool IsValidStraightSet() {
    // change to recfelct tile set size
    if (Tiles.Count < 2) {
      return false;
    }
    if (Tiles.Select(tile => tile.Color).ToHashSet().Count > 1) {
      return false;
    }
    if (Tiles.Select(tile => tile.Number).ToHashSet().Count < Tiles.Count) {
      return false;
    }
    return true;
  }

  private bool IsValidSingleNumSet() {
    // change to recfelct tile set size
    if (Tiles.Count > 4 || Tiles.Count < 2) {
      return false;
    }
    if (Tiles.Select(tile => tile.Color).ToHashSet().Count < Tiles.Count) {
      return false;
    }
    if (Tiles.Select(tile => tile.Number).ToHashSet().Count > 1) {
      return false;
    }
    return true;
  }

  public bool IsValidSet() {
    return IsValidStraightSet() || IsValidSingleNumSet();
    // return Tiles.All(tiles => Tiles.Count > 2);
  }

  // public TileSet(int size, List<Tile> tiles)
  // {
  //   // Type = type;
  //   // Size = size;
  //   Tiles = tiles;
  // }

}