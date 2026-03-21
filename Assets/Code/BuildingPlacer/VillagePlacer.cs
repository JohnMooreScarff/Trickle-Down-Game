using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagePlacement : MonoBehaviour
{
    public GameObject villagePrefab;
    public Button placeVillageButton;

    private GameObject villageToPlace;
    private bool isPlacing = false;
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
        if (isPlacing == false &&ResourceData.Stone_amount >= Village.stone_cost && ResourceData.Wood_amount >= Village.wood_cost)
        {
        villageToPlace = Instantiate(villagePrefab);
        MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            Debug.Log("scriptdisabled");
            script.enabled = false;
        }
        isPlacing = true;
        placeVillageButton.interactable = false;
        }
    }

    public void PlaceVillage()
    {
        if (isPlacing == true && OverWater == false)
        {
        MonoBehaviour[] scripts = villageToPlace.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            Debug.Log("scriptenabled");
            script.enabled = true;
        }
        villageToPlace = null;
        isPlacing = false;
        placeVillageButton.interactable = true;
        OverWater = false;
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
