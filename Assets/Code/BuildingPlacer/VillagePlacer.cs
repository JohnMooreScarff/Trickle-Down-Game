using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class VillagePlacement : MonoBehaviour
{
    
    public GameObject villagePrefab;
    public Button placeVillageButton;
    

    private GameObject villageToPlace;
    public static bool isPlacing = false;
    public static bool OverWater = false;
    public static bool JustPlaced = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isPlacing == true)
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            villageToPlace.transform.position = mousePos;
            if (Mouse.current.leftButton.isPressed)
            {
                JustPlaced = false;
            }
            else
            {
                JustPlaced = true;
            }            
        }
        
        if(Tree_Follow_place_buildings.isPlacing == true || Wood_Follow_place_buildings.isPlacing == true || Power_Follow_place_buildings.isPlacing == true || Carbon_capture_Follow_place_buildings.isPlacing == true || Stone_Follow_place_buildings.isPlacing == true || Iron_Follow_place_buildings.isPlacing == true || WindTurbine_Follow_place_buildings.isPlacing == true || Farm_Follow_place_buildings.isPlacing == true || Coal_Follow_place_buildings.isPlacing == true)
        
        {
            Destroy(villageToPlace);
            villageToPlace = null;
            isPlacing = false;
            placeVillageButton.interactable = true;
            OverWater = false;
        }
    }

    public void StartPlacingVillage()
    {
        if (isPlacing == false && ResourceData.Stone_amount >= Village.stone_cost && ResourceData.Wood_amount >= Village.wood_cost)
        {
            villageToPlace = Instantiate(villagePrefab);
            MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Disabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = false;
            }

            isPlacing = true;
            placeVillageButton.interactable = false;
            if (Mouse.current.leftButton.isPressed)
            {
                JustPlaced = false;
            }
            else
            {
                JustPlaced = true;
            }
        }
    }

    public void PlaceVillage()
    {
        if (JustPlaced == false && isPlacing == true && VillageTile.Overwater == false && ResourceData.Stone_amount >= Village.stone_cost && ResourceData.Wood_amount >= Village.wood_cost)
        {
            AudioManager.Instance.Play(AudioManager.SoundType.palce);
            AudioManager.Instance.Play(AudioManager.SoundType.Fireworks);
            MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 4; i++)
            {
                Debug.Log("Enabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = true;
            }

            villageToPlace = null;
            isPlacing = false;
            placeVillageButton.interactable = true;
            StartPlacingVillage();
        }
    }


    public void CancelPlacement()
    {
        if (isPlacing == true)
        {
        Destroy(villageToPlace);
        villageToPlace = null;
        isPlacing = false;
        placeVillageButton.interactable = true;
        OverWater = false;
        }
    }
}
