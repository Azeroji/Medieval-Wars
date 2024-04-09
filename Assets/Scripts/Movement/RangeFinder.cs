using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeFinder
{
    public List<OverlayTileController> getTilesInRange(OverlayTileController startingtile, int range)
  {
    var inRangeTiles = new List<OverlayTileController>();
    int totalStepCount = 0;
    inRangeTiles.Add(startingtile); // add the starting tile to the list
    var tileForpreviousStep = new List<OverlayTileController>();  // create a list to store the tiles from the previous step
    tileForpreviousStep.Add(startingtile); // add the starting tile to the list
    while (totalStepCount < range)
    {    
      int min = 9999;
      var surroundingTiles = new List<OverlayTileController>(); // create a list to store the tiles for the current step
      foreach (OverlayTileController tile in tileForpreviousStep)
      {
        if ( tile.stepCount + getMovementCost(tile) <= range ) {
          if ( getMovementCost(tile) < min ) {
            min = getMovementCost(tile);
          }
          var neighbouringTiles = (IEnumerable<OverlayTileController>)MapManager.Instance.getNeighbourTiles(tile, new List<OverlayTileController>());
          foreach (OverlayTileController tile1 in neighbouringTiles) {
            tile1.stepCount = tile.stepCount + getMovementCost(tile);
          }
          surroundingTiles.AddRange(neighbouringTiles); // get the neighbours of the tiles from the previous step 
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
    public int getMovementCost(OverlayTileController tile)
    {
        // Assuming terrainMap is accessible here
        int x = tile.grid2Dlocation.x + 10;
        int y = tile.grid2Dlocation.y + 5;
        return TilemapGenerator.terrainMap.map[x,y].movementCost;
    }
}


