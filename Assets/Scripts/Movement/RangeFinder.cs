using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeFinder
{
  public Game game;
    public List<OverlayTileController> getTilesInRange(OverlayTileController startingtile, int range)
  {
    var inRangeTiles = new List<OverlayTileController>();
    int totalStepCount = 0;
    inRangeTiles.Add(startingtile); // add the starting tile to the list
    var tileForpreviousStep = new List<OverlayTileController>();  // create a list to store the tiles from the previous step
    tileForpreviousStep.Add(startingtile); // add the starting tile to the list

    while (totalStepCount < range)
    {    

      int min = 99;
      var surroundingTiles = new List<OverlayTileController>(); // create a list to store the tiles for the current step

      foreach (OverlayTileController tile in tileForpreviousStep)
      {
        if ( tile.stepCount + getMovementCost(startingtile, tile) <= range ) { 

          if ( getMovementCost(startingtile, tile) < min ) {

            min = getMovementCost(startingtile, tile);

          }

          var neighbouringTiles = (IEnumerable<OverlayTileController>)MapManager.Instance.getNeighbourTiles(tile, new List<OverlayTileController>());
          
          foreach (OverlayTileController tile1 in neighbouringTiles) {

            tile1.stepCount = tile.stepCount + getMovementCost(startingtile, tile1);

            if ( tile1.stepCount <= range ) {

              surroundingTiles.Add(tile1);

            }

          }

        }

      }

      inRangeTiles.AddRange(surroundingTiles); // add the tiles from the current step to the list of tiles in range
      tileForpreviousStep = surroundingTiles.Distinct().ToList();
      totalStepCount = totalStepCount + min;// set the tiles from the current step as the tiles for the previous step

    }

    foreach (OverlayTileController tile1 in inRangeTiles) {

            tile1.stepCount = 0;

    }

    return inRangeTiles.Distinct().ToList();

  }

    // Function to get movement cost for a tile
    public int getMovementCost(OverlayTileController startingtile, OverlayTileController tile)
    {
        // Assuming terrainMap is accessible here
        int x = tile.grid2Dlocation.x + 10;
        int y = tile.grid2Dlocation.y + 5;

        if ( ( tile != startingtile ) && ( !game.isEmpty (x, y) ) ) {
          return 99;
        }

        return TilemapGenerator.terrainMap.map[x,y].movementCost;
    }
}