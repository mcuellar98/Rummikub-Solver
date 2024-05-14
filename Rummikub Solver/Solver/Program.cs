﻿using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Solver;

Tile tile1 = new Tile("blue", 1);
Tile tile2 = new Tile("blue", 2);
Tile tile3 = new Tile("blue", 3);
// Tile tile4 = new Tile("blue", 4);
// Tile tile5 = new Tile("blue", 5);
// Tile tile6 = new Tile("blue", 6);
// Tile tile7 = new Tile("blue", 7);
// Tile tile8 = new Tile("purple", 4);
TileSet tileSet1 = new TileSet(
  [tile1, tile2, tile3]
);
// TileSet tileSet2 = new TileSet(
//  [  tile4]//, tile5, tile6, tile7]//, tile7, tile8 }
// );
List<TileSet> tileSets = new List<TileSet> {tileSet1};//, tileSet2};
Board board= new Board(tileSets);

// Console.WriteLine(board.GetCurrentSetsAsString());
// Console.WriteLine(board.IsBoardValid());
// Console.WriteLine(board.GenerateValidBoards().Count);

List<List<TileSet>> validBoards = board.GenerateValidBoards();
Console.WriteLine(validBoards.Count);
foreach (List<TileSet> b in validBoards) {
  string tileString = "";
  // for (var j = 0; j < validBoards[i].Count; j++) {
  foreach (TileSet set in b) {
    foreach( Tile tile in set.Tiles) {
      tileString += tile.Number;
    }
    tileString += " ";
  }
  Console.WriteLine(tileString);
}




