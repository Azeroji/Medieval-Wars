using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RangeFinder
{
  public List<OverlayTileController> getTilesInRange(OverlayTileController startingtile, int range)
  {
    var inRangeTiles = new List<OverlayTileController>();
    int stepCount = 0;
    inRangeTiles.Add(startingtile); // add the starting tile to the list
    var tileForpreviousStep = new List<OverlayTileController>();  // create a list to store the tiles from the previous step
    tileForpreviousStep.Add(startingtile); // add the starting tile to the list
    while (stepCount < range)
    {
      var surroundingTiles = new List<OverlayTileController>(); // create a list to store the tiles for the current step
      foreach (OverlayTileController tile in tileForpreviousStep)
      {
        surroundingTiles.AddRange((IEnumerable<OverlayTileController>)MapManager.Instance.getNeighbourTiles(tile, new List<OverlayTileController>())); // get the neighbours of the tiles from the previous step 

      }
      inRangeTiles.AddRange(surroundingTiles); // add the tiles from the current step to the list of tiles in range
      tileForpreviousStep = surroundingTiles.Distinct().ToList();
      stepCount++;// set the tiles from the current step as the tiles for the previous step
    }
    return inRangeTiles.Distinct().ToList();
  }
}
