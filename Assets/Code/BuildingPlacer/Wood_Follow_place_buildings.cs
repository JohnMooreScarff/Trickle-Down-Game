using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Wood_Follow_place_buildings : MonoBehaviour
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
    IEnumerator WaitToStart()
        {
             yield return new WaitForSeconds(0.2f);
             StartPlacing();
        }  

    public void StartPlacing()
    {
        if (isPlacing == false)
        {
            
            currentObject = Instantiate(objectPrefab);
            MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Dissabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = false;
            }

            isPlacing = true;
            button.interactable = false;
        }
    }

    public void PlaceObject()
    {
        if (isPlacing == true && WoodTile.Overwater == false && OverVillage == true)
        {
            MonoBehaviour[] scripts = currentObject.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Enabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = true;
            }
        
        isPlacing = false;
        button.interactable = true;
        OverVillage = false; 
        StartCoroutine(WaitToStart());
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

