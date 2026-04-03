using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagePlacement : MonoBehaviour
{
    public GameObject villagePrefab;
    public Button placeVillageButton;

    private GameObject villageToPlace;
    public static bool isPlacing = false;
    public static bool OverWater = false;


    void Update()
    {
        if (isPlacing == true)
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            villageToPlace.transform.position = mousePos;
        }
    }

    public void StartPlacingVillage()
    {
        if (isPlacing == false && ResourceData.Stone_amount >= Village.stone_cost && ResourceData.Wood_amount >= Village.wood_cost)
        {
            villageToPlace = Instantiate(villagePrefab);
            MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 3; i++)
            {
                Debug.Log("Disabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = false;
            }

            isPlacing = true;
            placeVillageButton.interactable = false;
        }
    }

    public void PlaceVillage()
    {
        if (isPlacing == true && VillageTile.Overwater == false)
        {
            MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length && i < 3; i++)
            {
                Debug.Log("Enabling script: " + scripts[i].GetType().Name);
                scripts[i].enabled = true;
            }

            villageToPlace = null;
            isPlacing = false;
            placeVillageButton.interactable = true;
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
