using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouvement : MonoBehaviour
{
  [SerializeField] private Rigidbody2D cursorRb;
  private float speed = 5f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    float directionx = Input.GetAxis("Horizontal");
    float directiony = Input.GetAxis("Vertical");
    cursorRb.velocity = new Vector2(directionx * speed, directiony * speed);

  }
}
