using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
  // private bool isSelected = false;
  // public GameObject getUnit()
  // {
  //   return gameObject;
  // }
  // public bool getisSelected()
  // {
  //   return isSelected;
  // }
  // public void setisSelected(bool value)
  // {
  //   isSelected = value;

  // }
  public float moveSpeed = 100f;
  public float stopDistance = 0.1f;
  // Start is called before the first frame update

  void Start()
  {

  }

  public void unitMouvement(Vector3 cursorPosition)
  {

    // Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

    Vector3 direction = (cursorPosition - transform.position).normalized;
    Debug.Log("direcation : "+direction);

    Debug.Log("Unit Position Before: " + transform.position);
    // transform.Translate(direction * Time.deltaTime * moveSpeed);
    transform.position = Vector3.MoveTowards(transform.position, cursorPosition, moveSpeed * Time.deltaTime);
    Debug.Log("Unit Position After: " + transform.position);


    // float distanceToCursor = Vector3.Distance(transform.position, cursorPosition);
    // Debug.Log(distanceToCursor);

    // if (distanceToCursor < stopDistance)
    // {
    //   transform.position = cursorPosition;
    // }
  }
  public void playerAttack()
  {
    if (Input.GetMouseButtonDown(1)) // right mouse button
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit))
      {
        if (hit.collider.tag == "Enemy")
        {
          Debug.Log("Attack");
        }
      }
    }
  }
  public void playerAction()
  {
    // unitMouvement();
    // playerAttack();
  }
  // Update is called once per frame
  void Update()
  {
    CursorMouvement cursorMouvement = GetComponent<CursorMouvement>(); // in order to use its position
    if (cursorMouvement != null)
    {
      // Convert cursor position from world space to screen space
      //Vector3 screenPoint = Camera.main.WorldToScreenPoint(cursorMouvement.cursorPosition);
      Vector3 cursorPosition = cursorMouvement.cursorPosition;
      Debug.Log("Cursor Position: " + cursorPosition);
      unitMouvement(cursorPosition);

      // we had to call it here even though it is called in the CursorMouvement script because i dont know (ki n7itha mamchatch)
    }
  }
}


