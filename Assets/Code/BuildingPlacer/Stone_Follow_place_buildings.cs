using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Stone_Follow_place_buildings : MonoBehaviour
{
    

    public Button button;
    public GameObject objectPrefab;
    private GameObject currentObject;

    private bool isPlacing = false;
    public static bool OverVillage = false;

    void Update()
    {
        if (isPlacing == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f;
            currentObject.transform.position = worldPos;
        }
    }

    public void StartPlacing()
    {
        if (isPlacing == false && ResourceData.Wood_amount >= stonefactory.wood_cost)
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
        else
        {
           Debug.Log("Not enough materials"); 
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

