using UnityEngine;
using UnityEngine.UI;

public class Follow_place_buildings : MonoBehaviour
{
    public Button button;
    public GameObject objectPrefab;
    private GameObject currentObject;
    private bool isPlacing = false;


    void Update()
    {
        if (isPlacing == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            currentObject.transform.position = worldPos;

        }
    }
    public void StartPlacing()
    {
        Debug.Log("StartPlacing");
        currentObject = Instantiate(objectPrefab);
        isPlacing = true;
        button.interactable = false;
    }

    public void PlaceObject()
    {
        Debug.Log("PlaceObject");
        isPlacing = false;
        currentObject = null;
        button.interactable = true;
    }

}
