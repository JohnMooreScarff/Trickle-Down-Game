using UnityEngine;
using System.Collections;
using TMPro;

public class CoalMine : MonoBehaviour
{
    
    //cost
    private int money_cost = 500;
    public static int wood_cost = 50;
    public static int stone_cost = 50;

    //produce
    private int coal = 6;
    private float Pollution = 0.03f;
    //consume
    private int wood = 4;
    private int stone = 2;
    private int power = 20;
    private int villageColliderCount = 0;
    public float TerrainMultiplier = 1f;
    public static bool OverCoal = false;
  

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_demand += stone;
        ResourceData.Coal_supply += coal;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Money -= money_cost + (ResourceData.Wood_value * wood_cost) + (ResourceData.Stone_value * stone_cost);
        if(CoalTile.OverMountain == true)
        {
            TerrainMultiplier = 0.5f;
        }
        if(CoalTile.OverSnow == true)
        {
            TerrainMultiplier = 0.2f;
        }
        if(OverCoal == true)
        {
            TerrainMultiplier = TerrainMultiplier * 3f;
        }
        StartCoroutine(CoalProduction());
    }
     IEnumerator CoalProduction()
     {
        yield return new WaitForSeconds(4f / (TerrainMultiplier *ResourceData.Power_multiplier));
        if(GetComponent<WaterDissable>().Flooded == false)
        {
        if(ResourceData.Wood_amount >= wood && ResourceData.Stone_amount >= wood)
        {
        ResourceData.Coal_amount += coal;
        ResourceData.Wood_amount -= wood;
        ResourceData.Stone_amount -= stone;
        ResourceData.Pollution += Pollution;

        }
        }
        

        StartCoroutine(CoalProduction());
     }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Coal_Follow_place_buildings.OverVillage = true;
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
                Coal_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
