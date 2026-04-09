using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WindTurbine_Follow_place_buildings : MonoBehaviour
{
    
    public Button button;
    public GameObject objectPrefab;
    private GameObject currentObject;

    public static bool isPlacing = false;
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
        if (isPlacing == false && ResourceData.Coal_amount >= WindTurbine.coal_cost && ResourceData.Iron_amount >= WindTurbine.iron_cost)
        {
            currentObject = Instantiate(objectPrefab);
            MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Disabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = false;
            }

            isPlacing = true;
            button.interactable = false;
        }
    }

    public void PlaceObject()
    {
        if (isPlacing == true && WindTurbineTile.Overwater == false && OverVillage == true)
        {
            MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Enabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = true;
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
        OverVillage = false;
        }
    }
    
}

