using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ArrowTranslator;

public class OverlayTileController : MonoBehaviour
{
  // Start is called before the first frame update

  public Game game;

  public int G;
  public int H;
  public int F { get { return G + H; } }
  public bool isblocked;
  public int stepCount = 0;
  public OverlayTileController previous;
  public Vector3Int gridlocation;
  public Vector2Int grid2Dlocation { get { return new Vector2Int(gridlocation.x, gridlocation.y); } }
  // Update is called once per frame
  public List<Sprite> arrows;
  
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      hideTile();

    }

  }

  public void showTile()
  {
    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
  }
  public void hideTile()
  {
    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    setArrowSprite(ArrowDirection.None);
  }

  public void setArrowSprite(ArrowDirection direction)
  {
    var arrow = GetComponentsInChildren<SpriteRenderer>()[1];

    if (direction == ArrowDirection.None)
    {
      arrow.color = new Color(1, 1, 1, 0);
    }
    else
    {
      arrow.color = new Color(1, 1, 1, 1);
      arrow.sprite = arrows[(int)direction];
      arrow.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;






      // if (direction == ArrowDirection.Up)
      // {
      //   arrow.sprite = arrows[0];
      // }
      // else if (direction == ArrowDirection.Down)
      // {
      //   arrow.sprite = arrows[1];
      // }
      // else if (direction == ArrowDirection.Left)
      // {
      //   arrow.sprite = arrows[2];
      // }
      // else if (direction == ArrowDirection.Right)
      // {
      //   arrow.sprite = arrows[3];
      // }

    }
  }
}
