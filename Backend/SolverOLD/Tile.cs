namespace Solver;

public class Tile
{
  public string Color { get; set; }
  public int Number { get; set; }
  public Tile(string color, int number)
  {
    Color = color;
    Number = number;
  }

  public bool Equals(Tile tile) {
    return (Color == tile.Color && Number == tile.Number);
  }
}