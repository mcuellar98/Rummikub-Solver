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
}