using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class TerrainMap
{
  public Terrain[,] map;
  public TerrainMap(int x, int y)
  {
    map = new Terrain[x, y];
  }
}
public class TilemapGenerator : MonoBehaviour
{
  public TerrainMap terrainMap;
  public int[] mat;
  public Tilemap tilemap;
  public TileBase[] tiles; // Array of tiles corresponding to different terrain types
                           // Method to generate the Tilemap
  public void GenerateTilemap()
  {
    int xm = terrainMap.map.GetLength(0) / 2;
    int ym = terrainMap.map.GetLength(1) / 2;
    for (int x = -xm; x < xm; x++)
    {
      for (int y = -ym; y < ym; y++)
      {
        Terrain terrain = terrainMap.map[x + xm, y + ym];
        Vector3Int tilePosition = new Vector3Int(x, y, 0);
        tilemap.SetTile(tilePosition, tiles[(int)terrain.terrainType]);
      }
    }
  }

  void Start()
  {
    int mapWidth = 20;
    int mapHeight = 10;
    // Initialize terrainMap with desired dimensions
    terrainMap = new TerrainMap(20, 10);

    string mapString = File.ReadAllText("Assets/Maps/MAP_001.map");

    string[] cols = mapString.Split('\n');

    for (int y = 0; y < mapHeight; y++)
    {
      string[] rows = cols[mapHeight - y - 1].Split(';');
      for (int x = 0; x < mapWidth; x++)
      {
        TerrainType type = TerrainType.Plaine;
        System.Enum.TryParse(rows[x], true, out type);
        terrainMap.map[x, y] = new Terrain(type, 1, 0);
      }
    }
    GenerateTilemap();
  //  Debug.Log("tile coordinate : " + terrainMap.map[6, 4].terrainType.ToString());
  BoundsInt bounds = tilemap.cellBounds;
  Debug.Log("Bounds: Position: " + bounds.position + ", Size: " + bounds.size);
  }

}
