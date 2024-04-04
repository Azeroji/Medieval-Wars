using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouvement : MonoBehaviour
{
  // [SerializeField] private Rigidbody2D cursorRb;
  // private float speed = 5f;
  // Start is called before the first frame update
  Vector3 cursorPosition;
  private int Layermask;
  private int layerNumber = 6;
  private UnitController selectedUnit = null;
  void Start()
  {
    cursorPosition = transform.position;
    Layermask = 1 << layerNumber;

  }

  public void cursorMouvement()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {

      if (cursorPosition.x > -7.51f) //f for float
      {
        cursorPosition.x -= 1;

      }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {

      if (cursorPosition.x < 7.49f)
      {
        cursorPosition.x += 1;

      }
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {

      if (cursorPosition.y > -3.82f)
      {
        cursorPosition.y -= 1;

      }

    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {

      if (cursorPosition.y < 4.18f)
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

  public void playerSelection()
  {

    if (Input.GetKeyDown(KeyCode.Space))
    {
      // Convert cursor position from world space to screen space
      Vector3 screenPoint = Camera.main.WorldToScreenPoint(cursorPosition);
      Ray ray = Camera.main.ScreenPointToRay(screenPoint);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, Layermask); // whenever there is  collision between the cursor and the objects that are in the layer (playersLayer) and a click on space button, hit will be true
      if (hit)
      {

        selectUnit(hit.collider.gameObject.GetComponent<UnitController>());

      }
      else
      {
        deselectUnit();
      }
    }
  }



  // Update is called once per frame
  void Update()
  {
    cursorMouvement();
    playerSelection();

  }



}
