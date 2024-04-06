using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder
{
  // Start is called before the first frame update

  public List<OverlayTileController> findPath(OverlayTileController startNode, OverlayTileController endNode)
  {
    List<OverlayTileController> openList = new List<OverlayTileController>();
    List<OverlayTileController> closedList = new List<OverlayTileController>();
    openList.Add(startNode);
    while (openList.Count > 0)
    {
      OverlayTileController currentNode = openList[0];
      for (int i = 1; i < openList.Count; i++)
      {
        if (openList[i].F < currentNode.F || openList[i].F == currentNode.F && openList[i].H < currentNode.H)
        {
          currentNode = openList[i];
        }
      }
      openList.Remove(currentNode);
      closedList.Add(currentNode);
      if (currentNode == endNode)
      {
        return getfinishedlist(startNode, endNode);
      }
      var neighbourstiles = getNeighbourTiles(currentNode);
      foreach (OverlayTileController neighbour in (List<OverlayTileController>)neighbourstiles)
      {
        if (neighbour.isblocked || closedList.Contains(neighbour))
        {
          continue;
        }
        // int newMovementCostToNeighbour = currentNode.G + getManhattenDistance(currentNode, neighbour);
        // if (newMovementCostToNeighbour < neighbour.G || !openList.Contains(neighbour))
        // {
        neighbour.G = getManhattenDistance(startNode, neighbour);
        neighbour.H = getManhattenDistance(endNode, neighbour);

        neighbour.previous = currentNode;
        if (!openList.Contains(neighbour))
        {
          openList.Add(neighbour);
        }
        // }
      }
    }
    return null;
  }

  private int getManhattenDistance(OverlayTileController nodeA, OverlayTileController nodeB)
  {
    int x = Mathf.Abs(nodeA.gridlocation.x - nodeB.gridlocation.x);
    int y = Mathf.Abs(nodeA.gridlocation.y - nodeB.gridlocation.y);
    return x + y;
  }
  public List<OverlayTileController> getfinishedlist(OverlayTileController startNode, OverlayTileController endNode)
  {
    List<OverlayTileController> finishedlist = new List<OverlayTileController>();
    OverlayTileController currentNode = endNode;
    while (currentNode != startNode)
    {
      finishedlist.Add(currentNode);
      currentNode = currentNode.previous;
    }
    finishedlist.Reverse();
    return finishedlist;
  }
  public object getNeighbourTiles(OverlayTileController currentoverlayTile)
  {
    var map = MapManager.Instance.map;
    List<OverlayTileController> neighbours = new List<OverlayTileController>();
    //top
    Vector2Int locationTocheck = new Vector2Int(currentoverlayTile.gridlocation.x, currentoverlayTile.gridlocation.y + 1);

    if (map.ContainsKey(locationTocheck))
    {
      neighbours.Add(map[locationTocheck]);
    }

    //bottom
    locationTocheck = new Vector2Int(currentoverlayTile.gridlocation.x, currentoverlayTile.gridlocation.y - 1);

    if (map.ContainsKey(locationTocheck))
    {
      neighbours.Add(map[locationTocheck]);
    }


    //right

    locationTocheck = new Vector2Int(currentoverlayTile.gridlocation.x + 1, currentoverlayTile.gridlocation.y);

    if (map.ContainsKey(locationTocheck))
    {
      neighbours.Add(map[locationTocheck]);
    }
    //left
    locationTocheck = new Vector2Int(currentoverlayTile.gridlocation.x - 1, currentoverlayTile.gridlocation.y);

    if (map.ContainsKey(locationTocheck))
    {
      neighbours.Add(map[locationTocheck]);
    }

    return neighbours;

  }
}