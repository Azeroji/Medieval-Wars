using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayTileController : MonoBehaviour
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTile(){
      gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }
    public void hideTile(){
      gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
    }
}
