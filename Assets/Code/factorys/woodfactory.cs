using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class woodfactory : MonoBehaviour
{
    //cost
    private int money_cost = 600;
    //produce
    private int wood = 8;
    private float Pollution = 0.01f;
    //consume
    private int power = 10;
    private int villageColliderCount = 0;
    public static float TerrainMultiplier = 1f;


    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_supply += wood;
        ResourceData.Money -= money_cost;
        if(WoodTile.OverMountain == true)
        {
            TerrainMultiplier = TerrainMultiplier/2;
        }
        StartCoroutine(WoodProduction());
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(GetComponent<WaterDissable>().Flooded == false)
        {
        ResourceData.Wood_amount += wood;
        ResourceData.Pollution += Pollution;
        }
        StartCoroutine(WoodProduction());
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Wood_Follow_place_buildings.OverVillage = true;
            Debug.Log("Entered village collider, count: " + villageColliderCount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount--;
            Debug.Log("Exited village collider, count: " + villageColliderCount);
            if (villageColliderCount <= 0)
            {
                villageColliderCount = 0;
                Wood_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
