using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Transform cursor;
    public GameObject unitInfo;
    public GameObject terrainInfo;
    private RectTransform rectTransformTerrain;
    private RectTransform rectTransformUnit;

    void Start()
    {
        rectTransformTerrain = terrainInfo.GetComponent<RectTransform>();
        rectTransformUnit = unitInfo.GetComponent<RectTransform>();
    }

    void Update()
    {

        if ( cursor.position.x < 0 ) {
            rectTransformTerrain.offsetMin = new Vector2(-40f,0f);
            rectTransformUnit.offsetMin = new Vector2(-40f,0f);
        } else {
            rectTransformTerrain.offsetMin = new Vector2(-Screen.width + 50f,0f);
            rectTransformUnit.offsetMin = new Vector2(-Screen.width + 513.8f,0f);           
        }


    }
}
