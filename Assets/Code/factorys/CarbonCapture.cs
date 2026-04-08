using UnityEngine;
using System.Collections;
using TMPro;

public class CarbonCapture : MonoBehaviour
{
    
    //cost
    private int money_cost = 2000;
    public static int iron_cost = 20;
    

    //produce
    private float Pollution = -0.40f;
    //consume
    private int money = 50;
    private int power = 25;
    private int villageColliderCount = 0;
    public static float TerrainMultiplier = 1f;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Iron_amount -= iron_cost;
        ResourceData.Money -=  money_cost + iron_cost * ResourceData.Iron_value;
        if(CarbonCaptureTile.OverMountain == true)
        {
            TerrainMultiplier = TerrainMultiplier/2;
        }
        StartCoroutine(Carboncapture());
    }
     IEnumerator Carboncapture()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(GetComponent<WaterDissable>().Flooded == false)
        {
        ResourceData.Money -= money;
        ResourceData.Pollution += Pollution;
        }
        StartCoroutine(Carboncapture());
     }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Carbon_capture_Follow_place_buildings.OverVillage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount--;
            if (villageColliderCount <= 0)
            {
                villageColliderCount = 0;
                Carbon_capture_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
