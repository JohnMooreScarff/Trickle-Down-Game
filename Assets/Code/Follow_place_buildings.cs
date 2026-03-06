using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Follow_place_buildings : MonoBehaviour
{

    public Button button;
    public GameObject objectPrefab;
    public string allowedTag = "Village";
    private GameObject currentObject;
    
    private bool isPlacing = false;
    private bool OverVillage = false;
    void Start()
    {
        OverVillage = false;
        isPlacing = false;
    }


void Update()
{
    if (isPlacing && currentObject != null)
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;
        currentObject.transform.position = worldPos;

        // Get all colliders overlapping the point
        Collider2D[] hits = Physics2D.OverlapPointAll(worldPos);
        foreach (Collider2D hit in hits)
        {
            // Ignore colliders on the current object
            if (hit.gameObject == currentObject)
                continue;

            // Check for your target tag or other conditions
            if (hit.CompareTag("Village"))
            {
                OverVillage = true;
                Debug.Log("Over valid Village collider: " + hit.name);

            }
            else
            {
                OverVillage = false;
  
            }
        }
    }
}
    public void StartPlacing()
    {
        if (isPlacing == false)
        {
        Debug.Log("StartPlacing");
        currentObject = Instantiate(objectPrefab);
        MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            Debug.Log("scriptdisabled");
            script.enabled = false;
        }
        isPlacing = true;
        button.interactable = false;
        }
        
    }

    public void PlaceObject()
    {
        if (isPlacing == true && OverVillage == true)
        {
        Debug.Log("PlaceObject");
        MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            Debug.Log("scriptenabled");
            script.enabled = true;
        }
        isPlacing = false;
        currentObject = null;
        button.interactable = true;
        OverVillage = false;
        
        }
    }

        public void CancelPlacement()
    {
        if (isPlacing == true)
        {
        Debug.Log("Cancel");
        Destroy(currentObject);
        currentObject = null;
        isPlacing = false;
        button.interactable = true;
        }
    }

}
