using UnityEngine;
using UnityEngine.UI;

public class SpawnOnClick : MonoBehaviour
{
    public GameObject gameObject; 


    public void SpawnObject()
    {
        if (gameObject != null)
        {
            // Instantiate at origin with no rotation, you can customize position and rotation
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            Instantiate(gameObject, worldPos, Quaternion.identity);
        }
    }
}