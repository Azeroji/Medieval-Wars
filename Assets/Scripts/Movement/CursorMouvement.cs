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

  public Vector3 targetPos1 = new Vector3 (-1.56f, 2.68f, 0);
  public Vector3 targetPos2 = new Vector3 (-1.56f, 1.9f, 0);
  public Vector3 targetPos3 = new Vector3 (-1.56f, 1.27f, 0);

  public Game game;
  public bool redWin = false;
  public bool blueWin = false;
  public TilemapGenerator tilemapGenerator;  
  public GameObject menuPanel;
  public GameObject endMenuPanel;
    private int selectedIndex = 0;
    private bool menuOpen = false;
    private bool baraqueOpen = false;

    private int selectedUnitIndex = 0;

  public Vector3 cursorPosition;
  private Vector3 oldPosition;
  private int Layermask;
  private int layerNumber = 6;
  private UnitController selectedUnit = null; // later on
  private UnitController unit = null;
  public Unit unitObj;
  public GameObject unitPrefab;

  private PathFinder pathFinder;
  private List<OverlayTileController> path = new List<OverlayTileController>();
  private OverlayTileController previousTile;

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
  public TMP_Text unitStamina;

  public GameObject cursor;
  public GameObject cursorATK;
  public TextMeshProUGUI waitText;
  public TextMeshProUGUI attackText;
  public TextMeshProUGUI capText;
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
          tileCap.enabled = true;
          tileCapText.enabled = true;
          tileCap.text = "" + TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].capturePoints; 
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
  public void cursorMouvement()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      if (cursorPosition.x > -9) //f for float
      {
        cursorPosition.x -= 1;
        cursorMove = true;
      }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      if (cursorPosition.x < 9)
      {
        cursorPosition.x += 1;
        cursorMove = true;
      }
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      if (cursorPosition.y > -4)
      {
        cursorPosition.y -= 1;
        cursorMove = true;
      }

    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      if (cursorPosition.y < 4)
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

    Transform unitRoot = unit.transform.Find("UnitRoot");

    if ( unitRoot == null ) {
      unitRoot = unit.transform.Find("HorseRoot");
    }

    if (unitRoot != null) {
       Animator animator = unitRoot.gameObject.GetComponent<Animator>();
       animator.SetFloat("RunState", 0f );
    }

    unitObj.Move(Mathf.RoundToInt(overlayTile.transform.position.x+9.5f),Mathf.RoundToInt(overlayTile.transform.position.y+4.5f));
    unit.transform.position = new Vector3(overlayTile.transform.position.x, overlayTile.transform.position.y-0.25f + 0.0001f, 0);
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

    // moving animation 

    Transform unitRoot = unit.transform.Find("UnitRoot");

    if ( unitRoot == null ) {
      unitRoot = unit.transform.Find("HorseRoot");
    }

    if (unitRoot != null) {
       Animator animator = unitRoot.gameObject.GetComponent<Animator>();
       animator.SetFloat("RunState", 0.5f );
    }

    // 

    var step = speed * Time.deltaTime;
    unit.transform.position = Vector2.MoveTowards(unit.transform.position, new Vector2(path[0].transform.position.x, path[0].transform.position.y-0.25f) , step);
    if (Vector2.Distance(unit.transform.position, new Vector2(path[0].transform.position.x, path[0].transform.position.y-0.25f)) < 0.001f)
    {
      PositionUnitOnTile(path[0]);
      path.RemoveAt(0);
    }
    if (path.Count == 0)
    {
      isMoving = false;
      inRangeTiles.Clear();
    }

  }



  private void getinRangeTiles( int range )
  {
    foreach (var item in inRangeTiles)
    {
      item.hideTile();
    }
    unit.activeTile.stepCount = 0;
    inRangeTiles = rangeFinder.getTilesInRange(unit.activeTile, range, unitObj.unitType);
    foreach (var item in inRangeTiles)
    {
      item.showTile();
    }
  }



  // HANDLE MOVEMENT

  private void handleMovement ( GameObject overlayTile ) {

      if (inRangeTiles.Contains(overlayTile.GetComponent<OverlayTileController>()) && !isMoving)
      {

          if ( path.Count <= unitObj.movement ) {

            if ( ( path.Count == 0 ) ) {

                if ( overlayTile.GetComponent<OverlayTileController>() != unit.activeTile ) {
                  path.Add(overlayTile.GetComponent<OverlayTileController>());
                }

            } else if ( overlayTile.GetComponent<OverlayTileController>() != path[path.Count - 1] ) {
                
              if ( path.Contains(overlayTile.GetComponent<OverlayTileController>()) || ( overlayTile.GetComponent<OverlayTileController>() == unit.activeTile) ) {
                
                path.RemoveAt(path.Count - 1);

              } else if ( overlayTile.GetComponent<OverlayTileController>() != unit.activeTile ) {

                path.Add(overlayTile.GetComponent<OverlayTileController>());

              }
              
            }

          } else {
            path = pathFinder.findPath(unit.activeTile, overlayTile.GetComponent<OverlayTileController>(), inRangeTiles);
          }


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
            oldPosition = cursorPosition;

            PositionUnitOnTile(overlayTile.GetComponent<OverlayTileController>());
            previousTile = overlayTile.GetComponent<OverlayTileController>();
            path.Clear();
            getinRangeTiles(game.getUnit(cursorPosition.x, cursorPosition.y).movement);
          } else {
            endMenuOpen = true;
          }// Instantiate UnitController instead of Unit
        }
        else if ( inRangeTiles.Contains(overlayTile.GetComponent<OverlayTileController>()) )
        {
          if (game.isEmpty(Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f), unitObj)) {
            unitObj.UseStamina(path.Count);
            isMoving = true;
          } else if ( unitObj != null ) {
            getinRangeTiles(unitObj.movement);
          }
        } else if ( unitObj != null ) {
          getinRangeTiles(unitObj.movement);
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
  }

  // LATE UPDATE 



  void LateUpdate()
  {

    winText.enabled = false;

    if ( game.hasRedWon() || redWin ) {
      winText.enabled = true;
      winText.text = "RED WINS";
      gameObject.SetActive(false);
    }
    else if ( game.hasBlueWon() || blueWin ) {
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

    }
    else if ( ( path == null || path.Count <= 0 ) && isMoving ) { 
      
      endMovement();
      
      }
    else if ( !isMoving && hasMoved  ) {

      hasMoved = false;
      menuOpen = true;

      }

    }
    else if ( menuOpen ) {

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
    selectedIndex = 0;
    UpdateCursorPosition();
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
        if ( TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].isCapturable && ( unitObj.team != TilemapGenerator.terrainMap.map[Mathf.RoundToInt(cursorPosition.x+9.51f),Mathf.RoundToInt(cursorPosition.y+4.58f)].team ) && unitObj.canCapture ) {
          capText.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
              {
                  MoveSelection(1);
                  UpdateCursorPosition();
              }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
              {
                  MoveSelection(-1);
                  UpdateCursorPosition();
              }

              // Handle action when pressing Enter
        else if (Input.GetKeyDown(KeyCode.L))
              {
                  ExecuteAction();
              }
        else if (Input.GetKeyDown(KeyCode.K))
              {
                cursorPosition = oldPosition;
                transform.position = oldPosition;
                selectedIndex = 0;
                UpdateCursorPosition();
                PositionUnitOnTile(previousTile);
                unitObj.hasMoved = false;
                getinRangeTiles(unitObj.movement);
                CloseMenu();
              }

      }
      else {

          attackFunction();

      }

    }





// MENU FUNCTIONS 


void MoveSelection(int direction) {
        // Calculate next index based on direction
        int nextIndex = (selectedIndex + direction + 3) % 3;

        // Check if the next option is available based on boolean variables A and B
        if ((nextIndex == 1 && !capText.enabled) || (nextIndex == 2 && !attackText.enabled))
        {
            // If the next option is not available, skip it and try the next one
            MoveSelection(direction > 0 ? direction + 1 : direction - 1);
            return;
        }

        selectedIndex = nextIndex;

  }


    void ExecuteAction()
    {
        // Execute the action based on the selected index
        if (selectedIndex == 0)
        {
            unitObj.hasMoved = true;
            unitObj.hasPlayed = true;
            selectedIndex = 0;
            UpdateCursorPosition();
            unit = null;
            unitObj = null;
            CloseMenu();
        }
        else if (selectedIndex == 1)
        {
          unitObj.hasMoved = true;
          unitObj.hasPlayed = true;
          selectedIndex = 0;
          UpdateCursorPosition();
          int i = unitObj.Capture(tilemapGenerator);
          if ( i == - 1 ) {
            redWin = true;
          } else if ( i == 1 ) {
            blueWin = true;
          }
          unit = null;
          unitObj = null;
          CloseMenu();
        }
        else if (selectedIndex == 2)
        {
            selectedIndex = 0;
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
        capText.enabled = false;

    }

void UpdateCursorPosition()
    {
        // Set the cursor's position based on the selected index
        Vector3 targetPosition = Vector3.zero;
        if (selectedIndex == 0)
        {
            targetPosition = targetPos1;
        }
        else if (selectedIndex == 1)
        {
            targetPosition = targetPos2;
        }
        else if (selectedIndex == 2)
        {
            targetPosition = targetPos3;
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

  List<Unit> units = game.attackableUnits(unitObj).OrderBy(e => e.posx).ToList();  cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );

  if (Input.GetKeyDown(KeyCode.DownArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex - 1 + units.Count )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.UpArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex + 1 + units.Count )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.RightArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex + 1 + units.Count )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
  else if (Input.GetKeyDown(KeyCode.LeftArrow))
              {
                 selectedUnitIndex = (selectedUnitIndex - 1 + units.Count )%units.Count;
                 cursorATK.transform.position = new Vector3( ( units[selectedUnitIndex].posx - 9.5f ), ( units[selectedUnitIndex].posy - 4.5f ) );
              }
          
              // Handle action when pressing Enter
  if (Input.GetKeyDown(KeyCode.L))
              {
                  unitObj.Attack(units[selectedUnitIndex]);
                  unitObj = null;
                  unit = null;
                  cursorATK.SetActive(false);
                  isAttacking = false;
                  selectedUnitIndex = 0;
                  CloseMenu();
              }

}

}