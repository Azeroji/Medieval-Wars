using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using static ArrowTranslator;
using TMPro;

public class CursorMouvement : MonoBehaviour
{
  // [SerializeField] private Rigidbody2D cursorRb;
  // private float speed = 5f;
  // Start is called before the first frame update

  public Game game;
  

  public GameObject menuPanel;
  public GameObject endMenuPanel;
    private int selectedIndex = 0;
    private bool menuOpen = false;

    private int selectedUnitIndex = 0;

  public Vector3 cursorPosition;
  private int Layermask;
  private int layerNumber = 6;
  private UnitController selectedUnit = null; // later on
  private UnitController unit = null;
  public Unit unitObj;
  public GameObject unitPrefab;

  private PathFinder pathFinder;
  private List<OverlayTileController> path = new List<OverlayTileController>();

  public float speed = 4f;
  private RangeFinder rangeFinder;
  private ArrowTranslator arrowTranslator;
  private List<OverlayTileController> inRangeTiles = new List<OverlayTileController>();

  private bool isMoving = false;
  private bool hasMoved = false;
  private bool cursorMove = false;
  private bool isAttacking = false;
  private bool endMenuOpen = false;

  public Tilemap tilemap;
  public GameObject image;
  public TMP_Text winText;
  public TMP_Text tileName;
  public TMP_Text tileDefense;
   public TMP_Text tileCap;
    public TMP_Text tileCapText;
  public GameObject unitBg;
  public GameObject unitImage;
  public TMP_Text unitName;
  public GameObject unitHpImage;
  public TMP_Text unitHp;
  public GameObject unitAmmoImage;
  public TMP_Text unitAmmo;
  public GameObject unitStaminaImage;
  public GameObject cursor;
  public GameObject cursorATK;
  public TMP_Text unitStamina;

  public TextMeshProUGUI waitText;
  public TextMeshProUGUI attackText;
  public TextMeshProUGUI endText;


  void Start()
  {
    cursorPosition = transform.position;
    Layermask = 1 << layerNumber;
    pathFinder = new PathFinder();
    rangeFinder = new RangeFinder();
    rangeFinder.game = game;
    arrowTranslator = new ArrowTranslator();
    
  }

  // FUNCTIONS MOVEMENT

  public void getTile()
  {
    // Convert cursor position from world space to cell position
    Vector3Int cellPosition = tilemap.WorldToCell(cursorPosition);

    // Get the tile at the cell position
    TileBase tile = tilemap.GetTile(cellPosition);

    if (tile != null)
    {
      // Debug.Log("Tile coordinate: " + cellPosition.ToString());
      // Debug.Log("Tile name: " + tile.name);
      // Image panelImage = canvas.GetComponentInChildren<Panel>();
      UnityEngine.UI.Image panelImage = image.GetComponent<UnityEngine.UI.Image>();

      Tile tileData = tile as Tile; // Cast TileBase to Tile

      if (tileData != null)
      {
        panelImage.sprite = tileData.sprite; 
        tileName.text = ""+TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].terrainType; // Use name property from Tile class with explicit cast
        tileDefense.text = "" + TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].defenseBonus; // Use defense property from Tile class with explicit cast
        
        if ( TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].isCapturable ) {
          tileCap.text = "" + TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].cap; 
      } else {
        tileCap.enabled = false;
        tileCapText.enabled = false;
        }
      }

      if ( game.isEmptyF(cursorPosition.x, cursorPosition.y) ) {
        
        unitAmmo.enabled = false;
        unitAmmoImage.SetActive(false);
        unitBg.SetActive(false);
        unitHp.enabled = false;
        unitHpImage.SetActive(false);
        unitImage.SetActive(false);
        unitName.enabled = false;
        unitStamina.enabled = false;
        unitStaminaImage.SetActive(false);

      } else {
        
        Unit u = game.getUnitAll(cursorPosition.x, cursorPosition.y);
        unitAmmo.text = ""+u.ammo;
        unitHp.text = ""+u.hp;
        unitName.text = ""+u.unitName;
        unitStamina.text = ""+u.stamina;
        UnityEngine.UI.Image uImage = unitImage.GetComponent<UnityEngine.UI.Image>();
        uImage.sprite = u.sprite;

        unitAmmo.enabled = true;
        unitAmmoImage.SetActive(true);
        unitBg.SetActive(true);
        unitHp.enabled = true;
        unitHpImage.SetActive(true);
        unitImage.SetActive(true);
        unitName.enabled = true;
        unitStamina.enabled = true;
        unitStaminaImage.SetActive(true);

      }

    }
  }


  public void updatePath ( ) {
    if ( unit != null ) {
      Debug.Log("hey");
      var focusedTile = GetfocusedOnTile();
      if (focusedTile.HasValue)
    { 
            Debug.Log("hey1");
        GameObject overlayTile = focusedTile.Value.collider.gameObject;
        if ( path.Contains(overlayTile.GetComponent<OverlayTileController>()) ) {
            Debug.Log("removed");
            path.Remove(overlayTile.GetComponent<OverlayTileController>());
          } else {
            Debug.Log("added");
            path.Add(overlayTile.GetComponent<OverlayTileController>());
        }
    }
  }

}

  public void cursorMouvement()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      if (cursorPosition.x > -9.51f) //f for float
      {
        cursorPosition.x -= 1;
        cursorMove = true;
      }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      if (cursorPosition.x < 9.49f)
      {
        cursorPosition.x += 1;
        cursorMove = true;
      }
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      if (cursorPosition.y > -4.52f)
      {
        cursorPosition.y -= 1;
        cursorMove = true;
      }

    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      if (cursorPosition.y < 4.42f)
      {
        cursorPosition.y += 1;
        cursorMove = true;
      }
    } else {
      cursorMove = false;
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

    if (Input.GetKeyDown(KeyCode.L))
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

private void cancel() {
    if ( unitObj != null ) {
      unitObj.hasPlayed = false;
    }
    foreach (var item in inRangeTiles)
    {
          item.hideTile();
    }
    isMoving = false;
    inRangeTiles.Clear();
    unit = null;
  }

  private void moveAlongPath()
  {
    foreach (var item in inRangeTiles)
    {
          item.setArrowSprite(ArrowDirection.None);
    }

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
    unit.activeTile.stepCount = 0;
    inRangeTiles = rangeFinder.getTilesInRange(unit.activeTile, range);
    foreach (var item in inRangeTiles)
    {
      item.showTile();
    }
  }


  // HANDLE MOVEMENT

  private void handleMovement ( GameObject overlayTile ) {

      if (inRangeTiles.Contains(overlayTile.GetComponent<OverlayTileController>()) && !isMoving)
      {

        path = pathFinder.findPath(unit.activeTile, overlayTile.GetComponent<OverlayTileController>(), inRangeTiles); 
        
        
        // Pass searchableTiles argument
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

      if ( Input.GetKeyDown(KeyCode.K) ) {
        cancel();
      }


      if (Input.GetKeyDown(KeyCode.L))
      {

        if (unit == null)
        {
          if ( game.canGetUnit(cursorPosition.x, cursorPosition.y) ) {
            unitObj = game.getUnit(cursorPosition.x, cursorPosition.y);
            unit = unitObj.objectInstance.GetComponent<UnitController>();

            PositionUnitOnTile(overlayTile.GetComponent<OverlayTileController>()); // Pass OverlayTileController component instead of GameObject
            getinRangeTiles(game.getUnit(cursorPosition.x, cursorPosition.y).movement);
          } else {
            endMenuOpen = true;
          }// Instantiate UnitController instead of Unit
        }
        else
        {
          isMoving = true;
        }

      }
  }
  
  private void endMovement ( ) {
      hasMoved = true;  
      isMoving = false;
      foreach (var item in inRangeTiles)
        {
          item.setArrowSprite(ArrowDirection.None);
        }
      inRangeTiles.Clear();
      unit = null;
  }

  // LATE UPDATE 



  void LateUpdate()
  {

    winText.enabled = false;

    if ( game.hasRedWon() ) {
      winText.enabled = true;
      winText.text = "RED WINS";
      gameObject.SetActive(false);
    } else if ( game.hasBlueWon() ) {
      winText.enabled = true;
      winText.text = "Blue WINS";
      gameObject.SetActive(false);
    }

    if ( !menuOpen && !endMenuOpen ) {
    
    cursorATK.SetActive(false);
    closeEndMenu();
    CloseMenu();
    cursorMouvement();
    getTile();

    var focusedTile = GetfocusedOnTile();

    if (focusedTile.HasValue)
    {

      GameObject overlayTile = focusedTile.Value.collider.gameObject;
      handleMovement ( overlayTile );

    }
    if (path != null && path.Count > 0 && isMoving)
    {

      hasMoved = true;
      moveAlongPath();

    } else if ( ( path == null || path.Count <= 0 ) && isMoving ) { 
      
      endMovement();
      
      } else if ( !isMoving && hasMoved  ) {

      hasMoved = false;
      menuOpen = true;

      }

    } else if ( menuOpen ) {

      OpenMenu();

  } else if ( endMenuOpen ) {

    endMenuPanel.SetActive(true);
    endText.enabled = true;
    cursor.SetActive (true);

    if (Input.GetKeyDown(KeyCode.L)) {
      game.endTurn();
      closeEndMenu();
      endMenuOpen = false;
    } else if (Input.GetKeyDown(KeyCode.K)){
      closeEndMenu();
      endMenuOpen = false;
    }


  }

  }

  private void closeEndMenu ( ) {
    cursor.SetActive (false);
    endMenuPanel.SetActive(false);
    endText.enabled = false;
  }

  // OPEN MENU

  private void OpenMenu () {

      if ( !isAttacking ) {
        
        cursor.SetActive(true);
        menuPanel.SetActive(true);
        waitText.enabled = true;
        if ( game.attackableUnits(unitObj).Count > 0 ) {
          attackText.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
              {
                  ChangeSelection();
                  UpdateCursorPosition();
              }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
              {
                  ChangeSelection();
                  UpdateCursorPosition();
              }

              // Handle action when pressing Enter
        if (Input.GetKeyDown(KeyCode.L))
              {
                  ExecuteAction();
              }

      } else {

          attackFunction();

      }

    }





// MENU FUNCTIONS 



void ChangeSelection()
    {

        if ( (selectedIndex == 0) && (game.attackableUnits(unitObj).Count > 0) ) {
            selectedIndex = 1;
        } else if (selectedIndex == 1 && game.attackableUnits(unitObj).Count > 0) {
            selectedIndex = 0;
        }

        // Update the selected button
    }


    void ExecuteAction()
    {
        // Execute the action based on the selected index
        if (selectedIndex == 0)
        {
            CloseMenu();
        }
        else if (selectedIndex == 1)
        {
            ChangeSelection();
            UpdateCursorPosition();
            isAttacking = true;
        }
    }

  void CloseMenu()
    {
        cursor.SetActive(false);
        menuPanel.SetActive(false);
        menuOpen = false;
        waitText.enabled = false;
        attackText.enabled = false;

    }

void UpdateCursorPosition()
    {
        // Set the cursor's position based on the selected index
        Vector3 targetPosition = Vector3.zero;
        if (selectedIndex == 0)
        {
            targetPosition = new Vector3 (-1.56f, 2.74f, 0);
        }
        else if (selectedIndex == 1)
        {
            targetPosition = new Vector3 (-1.56f, 1.64f, 0);
        }

        cursor.transform.position = targetPosition;

        // Show the cursor
        cursor.SetActive(true);
    }

// ATTACK FUNCTIONS 

private void attackFunction() {

  cursor.SetActive(false);
  menuPanel.SetActive(false);
  waitText.enabled = false;
  attackText.enabled = false;

  cursorATK.SetActive(true);

  List<Unit> units = game.attackableUnits(unitObj).OrderBy(e => e.posx).ToList();

  cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );

  if (Input.GetKeyDown(KeyCode.DownArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex - 1 )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.UpArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex + 1 )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.RightArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex + 1 )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.LeftArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex - 1 )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
          
              // Handle action when pressing Enter
  if (Input.GetKeyDown(KeyCode.L))
              {
                  unitObj.Attack(units[selectedUnitIndex]);
                  cursorATK.SetActive(false);
                  isAttacking = false;
                  selectedUnitIndex = 0;
                  CloseMenu();
              }

}

}