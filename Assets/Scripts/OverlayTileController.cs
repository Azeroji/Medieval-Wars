using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayTileController : MonoBehaviour
{
  // Start is called before the first frame update

  public int G;
  public int H;
  public int F { get { return G + H; } }
  public bool isblocked;
  public OverlayTileController previous;
  public Vector3Int gridlocation;
  public Vector2Int grid2Dlocation { get { return new Vector2Int(gridlocation.x, gridlocation.y); } }
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      hideTile();

    }

  }

  public void showTile()
  {
    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
  }
  public void hideTile()
  {
    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
  }
}
