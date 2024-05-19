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
    if (Tiles.Count < 3) {
      return false;
    }
    if (Tiles.Select(tile => tile.Color).ToHashSet().Count > 1) {
      return false;
    }
    HashSet<int> tileNums = Tiles.Select(tile => tile.Number).ToHashSet();
    if (tileNums.Count < Tiles.Count) {
      return false;
    }
    if (tileNums.Max() - tileNums.Min() != tileNums.Count-1) {
      return false;
    }
    for (var i = 1; i < Tiles.Count; i++) {
      if (Tiles[i].Number != Tiles[i-1].Number+1) {
        return false;
      }
    }
    return true;
  }

  private bool IsValidSingleNumSet() {
    if (Tiles.Count > 4 || Tiles.Count < 3) {
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

  public void AddTile(Tile tile) {
    Tiles.Add(tile);
  }

// assumes input sets are sorted by number
  public bool Equals(TileSet set) {
    if (Tiles.Count != set.Tiles.Count) { return false; }
    List<Tile> nonMatchingTiles = Tiles.Where((tile, index) => tile.Equals(set.Tiles[index])).ToList();
    if (nonMatchingTiles.Count < Tiles.Count) { return false;}
    return true;
  }

}