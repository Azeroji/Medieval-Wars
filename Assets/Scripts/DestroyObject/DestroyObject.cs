using UnityEngine;

public class DestroyObject : MonoBehaviour {
    public static void Detruire ( GameObject unitGameObject, float time ) {
        Destroy(unitGameObject, time);
    }

}