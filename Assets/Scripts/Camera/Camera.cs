using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cursor;
    public float edgeSizeX = 9f;
    public float edgeSizeY = 5f;
    public CursorMouvement cursorMouvement;

    void Update()
    {
        Vector3 pos = transform.position;
        
        if (Mathf.Ceil(cursor.transform.position.x) - pos.x > edgeSizeX)
        {
            cursorMouvement.targetPos1.x += 0.05f;
            cursorMouvement.targetPos2.x += 0.05f;
            cursorMouvement.targetPos3.x += 0.05f;

            pos.x += 0.05f;
            pos.x = Mathf.Round(pos.x * 100.0f) / 100.0f;
        }
        else if (Mathf.Ceil(cursor.transform.position.x) - pos.x < -edgeSizeX+1)
        {
            cursorMouvement.targetPos1.x -= 0.05f;
            cursorMouvement.targetPos2.x -= 0.05f;
            cursorMouvement.targetPos3.x -= 0.05f;

            pos.x -= 0.05f;
            pos.x = Mathf.Round(pos.x * 100.0f) / 100.0f;
        }

        if (Mathf.Ceil(cursor.transform.position.y) - pos.y > edgeSizeY)
        {
            cursorMouvement.targetPos1.y += 0.05f;
            cursorMouvement.targetPos2.y += 0.05f;
            cursorMouvement.targetPos3.y += 0.05f;

            pos.y += 0.05f;
            pos.y = Mathf.Round(pos.y * 100.0f) / 100.0f;
        }
        else if (Mathf.Ceil(cursor.transform.position.y) - pos.y < -edgeSizeY+1)
        {
            cursorMouvement.targetPos1.y += 0.05f;
            cursorMouvement.targetPos2.y += 0.05f;
            cursorMouvement.targetPos3.y += 0.05f;
            
            pos.y -= 0.05f;
            pos.y = Mathf.Round(pos.y * 100.0f) / 100.0f;
        }

        transform.position = pos;
    }
}
