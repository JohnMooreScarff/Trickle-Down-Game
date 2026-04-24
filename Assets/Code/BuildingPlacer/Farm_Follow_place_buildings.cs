using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Farm_Follow_place_buildings : MonoBehaviour
{
    

    public Button button;
    public GameObject objectPrefab;
    private GameObject currentObject;

    public static bool isPlacing = false;
    public static bool OverVillage = false;
    public static bool JustPlaced = false;

    void Update()
    {
        if (isPlacing == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f;
            currentObject.transform.position = worldPos;
            if (Mouse.current.leftButton.isPressed)
            {
                JustPlaced = false;
            }
            else
            {
                JustPlaced = true;
            }
        }
        if(VillagePlacement.isPlacing == true || Tree_Follow_place_buildings.isPlacing == true || Wood_Follow_place_buildings.isPlacing == true || Power_Follow_place_buildings.isPlacing == true || Carbon_capture_Follow_place_buildings.isPlacing == true || Stone_Follow_place_buildings.isPlacing == true || Iron_Follow_place_buildings.isPlacing == true || WindTurbine_Follow_place_buildings.isPlacing == true || Coal_Follow_place_buildings.isPlacing == true)
        
        {
            Destroy(currentObject);
            currentObject = null;
            isPlacing = false;
            button.interactable = true;
            OverVillage = false;
        }
    }

    public void StartPlacing()
    {
        if (isPlacing == false && ResourceData.Stone_amount >= Farm.stone_cost && ResourceData.Wood_amount >= Farm.wood_cost)
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
        if (JustPlaced == false && isPlacing == true && FarmTile.Overwater == false && OverVillage == true && ResourceData.Stone_amount >= Farm.stone_cost && ResourceData.Wood_amount >= Farm.wood_cost)
        {
            AudioManager.Instance.Play(AudioManager.SoundType.palce);
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
        StartPlacing();
        
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

