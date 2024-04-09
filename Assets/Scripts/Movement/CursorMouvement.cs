using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static ArrowTranslator;

public class CursorMouvement : MonoBehaviour
{
  // [SerializeField] private Rigidbody2D cursorRb;
  // private float speed = 5f;
  // Start is called before the first frame update

  public Game game;

  public Vector3 cursorPosition;
  private int Layermask;
  private int layerNumber = 6;
  private UnitController selectedUnit = null; // later on
  private UnitController unit;
  public Unit unitObj;
  public GameObject unitPrefab;

  private PathFinder pathFinder;
  private List<OverlayTileController> path = new List<OverlayTileController>();

  public float speed = 4f;
  private RangeFinder rangeFinder;
  private ArrowTranslator arrowTranslator;
  private List<OverlayTileController> inRangeTiles = new List<OverlayTileController>();

  private bool isMoving = false;
  void Start()
  {
    cursorPosition = transform.position;
    Layermask = 1 << layerNumber;
    pathFinder = new PathFinder();
    rangeFinder = new RangeFinder();
    arrowTranslator = new ArrowTranslator();

  }

  public void cursorMouvement()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {

      if (cursorPosition.x > -9.51f) //f for float
      {
        cursorPosition.x -= 1;

      }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {

      if (cursorPosition.x < 9.49f)
      {
        cursorPosition.x += 1;

      }
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {

      if (cursorPosition.y > -4.52f)
      {
        cursorPosition.y -= 1;

      }

    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {

      if (cursorPosition.y < 4.42f)
      {
        cursorPosition.y += 1;
      }
    }

    transform.position = cursorPosition;
  }

  public void selectUnit(UnitController unit)
  {

    // selectedUnit.setisSelected(true);

    if (selectedUnit == unit) // toggle purpose
    {
      deselectUnit();
    }
    else
    {
      deselectUnit(); // deselect the previous unit if there is any
      selectedUnit = unit;
      selectedUnit.transform.localScale = new Vector3(1, 1, 1);

    }


  }

  public void deselectUnit()
  {
    if (selectedUnit != null)
    {
      selectedUnit.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f); // return to its initial state
      selectedUnit = null;
    }
    // selectedUnit.setisSelected(false);

  }

  public void unitSelection()
  {

    if (Input.GetKeyDown(KeyCode.Space))
    {
      // Convert cursor position from world space to screen space
      Vector3 screenPoint = Camera.main.WorldToScreenPoint(cursorPosition);
      Ray ray = Camera.main.ScreenPointToRay(screenPoint);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, Layermask); // whenever there is  collision between the cursor and the objects that are in the layer (playersLayer), hit will be true
      if (hit)
      {

        selectUnit(hit.collider.gameObject.GetComponent<UnitController>());

      }
      else
      {
        if (selectedUnit != null)
        {

          selectedUnit.unitMouvement(cursorPosition); // move the selected unit to the cursor position
          deselectUnit();
        }

      }
    }
  }

  public RaycastHit2D? GetfocusedOnTile()
  {
    // Convert cursor position from world space to screen space
    // Vector3 screenPoint = Camera.main.ScreenToWorldPoint(cursorPosition);
    Vector2 cursorpos2d = new Vector2(cursorPosition.x, cursorPosition.y);
    RaycastHit2D[] hits = Physics2D.RaycastAll(cursorpos2d, Vector2.zero); // whenever there is  collision between the cursor and the objects that are in the layer (playersLayer), hit will be true
    if (hits.Length > 1)
    {
      // Debug.Log("hits length : " + hits.Length);
      for (int i = 0; i < hits.Length; i++)
      {
        // Debug.Log("Tile : " + hits[i].collider.gameObject.name);
        if (hits[i].collider.gameObject.tag == "OverlayTile")
        {
          return hits[i];
        }


      }
      // return hits.OrderByDescending(i => i.collider.transform.position.z).First();
      //return hits[hits.Length - 1];

    }

    return null;
  }

  private void PositionUnitOnTile(OverlayTileController overlayTile)
  {
    unitObj.Move(Mathf.RoundToInt(overlayTile.transform.position.x+9.5f),Mathf.RoundToInt(overlayTile.transform.position.y+4.5f));
    unit.transform.position = new Vector3(overlayTile.transform.position.x, overlayTile.transform.position.y-0.25f + 0.0001f, 0);
    //unit.GetComponent<SpriteRenderer>().sortingOrder = overlayTile.GetComponent<SpriteRenderer>().sortingOrder;
    unit.activeTile = overlayTile;
  }

void ClearTileFocus()
{
    foreach (var tile in inRangeTiles)
    {
        tile.setArrowSprite(ArrowDirection.None); // Assuming this method resets arrow sprite
        // Add any other resetting logic here
    }
}

  // Update is called once per frame
  void LateUpdate()
  {
    cursorMouvement();
    // unitSelection();
    var focusedTile = GetfocusedOnTile();
    if (focusedTile.HasValue)
    {
      GameObject overlayTile = focusedTile.Value.collider.gameObject;
      // transform.position = overlayTile.transform.position;
      // gameObject.GetComponent<SpriteRenderer>().sortingLayerID = overlayTile.GetComponent<SpriteRenderer>().sortingLayerID;


      if (inRangeTiles.Contains(overlayTile.GetComponent<OverlayTileController>()) && !isMoving)
      {
        path = pathFinder.findPath(unit.activeTile, overlayTile.GetComponent<OverlayTileController>(), inRangeTiles); // Pass searchableTiles argument
        foreach (var item in inRangeTiles)
        {
          item.setArrowSprite(ArrowDirection.None);
        }
        for (int i = 0; i < path.Count; i++)
        {
          var previsousTile = i > 0 ? path[i - 1] : unit.activeTile;
          var futureTile = i < path.Count - 1 ? path[i + 1] : null;
          var arrowDir = arrowTranslator.TranslateDirection(previsousTile, path[i], futureTile);
          path[i].setArrowSprite(arrowDir);

        }
      }


      if (Input.GetKeyDown(KeyCode.Space))
      {
        // Debug.Log("overlaytile : "+overlayTile);
        overlayTile.GetComponent<OverlayTileController>().showTile();
        if (unit == null)
        {
          if ( game.canGetUnit(cursorPosition.x, cursorPosition.y) ) {

            unitObj = game.getUnit(cursorPosition.x, cursorPosition.y);
            unit = unitObj.objectInstance.GetComponent<UnitController>();

            PositionUnitOnTile(overlayTile.GetComponent<OverlayTileController>()); // Pass OverlayTileController component instead of GameObject
            getinRangeTiles(game.getUnit(cursorPosition.x, cursorPosition.y).movement);
          } else {
            Debug.Log("Terrain");
          }// Instantiate UnitController instead of Unit
        }
        else
        {
          isMoving = true;
        }

      }
    }
    if (path != null && path.Count > 0 && isMoving)
    {
      moveAlongPath();
    } else if ( ( path == null || path.Count <= 0 ) && isMoving ) { 
      isMoving = false;
      inRangeTiles.Clear();
      unit = null;
    }

  }

  private void moveAlongPath()
  {
    var step = speed * Time.deltaTime;
    unit.transform.position = Vector2.MoveTowards(unit.transform.position, path[0].transform.position, step);
    if (Vector2.Distance(unit.transform.position, path[0].transform.position) < 0.001f)
    {
      PositionUnitOnTile(path[0]);
      path.RemoveAt(0);
    }
    if (path.Count == 0)
    {
      isMoving = false;
      inRangeTiles.Clear();
      unit = null;

    }

  }

  private void getinRangeTiles( int range )
  {
    foreach (var item in inRangeTiles)
    {
      item.hideTile();
    }
    inRangeTiles = rangeFinder.getTilesInRange(unit.activeTile, range);
    foreach (var item in inRangeTiles)
    {
      item.showTile();
    }
  }
}
