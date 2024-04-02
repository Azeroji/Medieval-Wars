using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouvement : MonoBehaviour
{
  // [SerializeField] private Rigidbody2D cursorRb;
  // private float speed = 5f;
  // Start is called before the first frame update
  Vector3 newPosition;
  void Start()
  {
    newPosition = transform.position;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {

      if (newPosition.x > -7.51f) //f for float
      {
        newPosition.x -= 1;

      }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {

      if (newPosition.x < 7.49f)
      {
        newPosition.x += 1;

      }
    }

    if (Input.GetKeyDown(KeyCode.DownArrow))
    {

      if (newPosition.y > -3.82f)
      {
        newPosition.y -= 1;

      }

    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {

      if (newPosition.y < 4.18f)
      {
        newPosition.y += 1;
      }
    }

    transform.position = newPosition;
  }

  // cursorRb.velocity = new Vector2(directionx * speed, directiony * speed);


}
