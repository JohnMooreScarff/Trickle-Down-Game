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

            Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
        }
    }
}