using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class TerrainMap {
    public Terrain[,] map;
    public TerrainMap(int x, int y) {
        map = new Terrain[x, y];
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                map[i, j] = new Terrain();
            }
        }
    }
}

public class TilemapGenerator : MonoBehaviour {
    public Game game;
    public static TerrainMap terrainMap = new TerrainMap(20,10);
    public Tilemap tilemap;
    public TileBase[] tiles;
    public void GenerateTilemap() {
        int xm = terrainMap.map.GetLength(0)/2;
        int ym = terrainMap.map.GetLength(1)/2;
        for (int x = -xm; x < xm; x++) {
            for (int y = -ym; y < ym; y++) {
                Terrain terrain = terrainMap.map[x+xm, y+ym];
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tiles[(int)terrain.terrainType]);
            }
        }
    }

    void Start() {
        int mapWidth = 20;
        int mapHeight = 10;
        // Initialize terrainMap with desired dimensions

    string mapString = File.ReadAllText("Assets/Maps/MAP_002.map");

    string[] cols = mapString.Split('\n');

    for (int y = 0; y < mapHeight; y++)
    {
      string[] rows = cols[mapHeight - y - 1].Split(';');
      for (int x = 0; x < mapWidth; x++)
      {
        TerrainType type = TerrainType.Plaine;
        System.Enum.TryParse(rows[x], true, out type);
        
        switch (type) {
                    case TerrainType.Plaine:
                        terrainMap.map[x, y] = new Plaine();
                        break;
                    case TerrainType.Montagne:
                        terrainMap.map[x, y] = new Montagne();
                        break;
                    case TerrainType.Foret:
                        terrainMap.map[x, y] = new Foret();
                        break;
                    case TerrainType.Cave:
                        terrainMap.map[x, y] = new Cave();
                        break;
                    case TerrainType.Marais:
                        terrainMap.map[x, y] = new Marais();
                        break;
                    case TerrainType.Ocean:
                        terrainMap.map[x, y] = new Ocean(TerrainType.Ocean);
                        break;
                    case TerrainType.OceanCote:
                        terrainMap.map[x, y] = new Ocean(TerrainType.OceanCote);
                        break;
                    case TerrainType.VillageNeutre:
                        terrainMap.map[x, y] = new Village(Teams.Neutral);
                        break;
                    case TerrainType.QgBleu:
                        terrainMap.map[x, y] = new Qg(Teams.Blue);
                        break;
                    case TerrainType.VillageBleu:
                        terrainMap.map[x, y] = new Village(Teams.Blue);
                        game.playerBlue.AddVille(terrainMap.map[x, y]);
                        break;
                    case TerrainType.BaraqueBleu:
                        terrainMap.map[x, y] = new Baraque(Teams.Blue);
                        break;
                    case TerrainType.PortBleu:
                        terrainMap.map[x, y] = new Port(Teams.Blue);
                        break;
                    case TerrainType.AtelierBleu:
                        terrainMap.map[x, y] = new Atelier(Teams.Blue);
                        break;
                    case TerrainType.QgRouge:
                        terrainMap.map[x, y] = new Qg(Teams.Red);
                        break;
                    case TerrainType.VillageRouge:
                        terrainMap.map[x, y] = new Village(Teams.Red);
                        game.playerRed.AddVille(terrainMap.map[x, y]);
                        break;
                    case TerrainType.BaraqueRouge:
                        terrainMap.map[x, y] = new Baraque(Teams.Red);
                        break;
                    case TerrainType.PortRouge:
                        terrainMap.map[x, y] = new Port(Teams.Red);
                        break;
                    case TerrainType.AtelierRouge:
                        terrainMap.map[x, y] = new Atelier(Teams.Red);
                        break;
                    default:
                        terrainMap.map[x, y] = new Plaine(); // Default to plain if type is not recognized
                        break;
                }
        
      }
    }

    GenerateTilemap();

  }

}
