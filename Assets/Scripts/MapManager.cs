using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }

    public OverlayTileController overlayTileprefab;
    public GameObject overlayContainer;
    public float delaySeconds = 1f; // Adjust the delay time as needed

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedTilemapProcessing());
    }

    IEnumerator DelayedTilemapProcessing()
    {
        yield return new WaitForSeconds(delaySeconds);

        var tilemap = gameObject.GetComponentInChildren<Tilemap>();

        if (tilemap != null)
        {
            BoundsInt bounds = tilemap.cellBounds;

            // Output the bounds for debugging purposes
            Debug.Log("Bounds: Position: " + bounds.position + ", Size: " + bounds.size);

            // Now you can iterate over the bounds to process each tile within the tilemap
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    var tilelocation = new Vector3Int(x, y, 0); // Convert Vector2Int to Vector3Int
                    if (tilemap.HasTile(tilelocation))
                    {
                        var overlayTile = Instantiate(overlayTileprefab, overlayContainer.transform);
                        var cellWorldPosition = tilemap.GetCellCenterWorld(tilelocation);
                        overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, 0);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tilemap.GetComponent<TilemapRenderer>().sortingOrder;

                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("No Tilemap found in children of " + gameObject.name);
        }
    }

    // Update is called once per frame
}
