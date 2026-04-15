using UnityEngine;
using System.Collections;
using TMPro;

public class Farm : MonoBehaviour
{
    public bool Isplaced = false;
    //cost
    private int money_cost = 1000;
    public static int stone_cost = 40;
    public static int wood_cost = 60;
    //production
    private int food = 6;
    private float Pollution = 0.02f;
    //consume
    private int power = 10;
    private int villageColliderCount = 0;  
    public float TerrainMultiplier = 1f;

    void Start()
    {
        Isplaced = true;
        ResourceData.Power_demand += power;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Food_supply += food;
        if(FarmTile.OverMountain == true)
        {
            TerrainMultiplier = 0.5f;
        }
        else if(FarmTile.OverSnow == true)
        {
            TerrainMultiplier = 0.2f;
        }
        else if(FarmTile.OverFarmland == true)
        {
            TerrainMultiplier = 2f;
        }
        StartCoroutine(WoodProduction());
        ResourceData.Money -= money_cost + (ResourceData.Wood_value * wood_cost) + (ResourceData.Stone_value * stone_cost);
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4f / (TerrainMultiplier *ResourceData.Power_multiplier));
        if(GetComponent<WaterDissable>().Flooded == false)
        {
        ResourceData.Food_amount += food;
        ResourceData.Pollution += Pollution;
        }
        StartCoroutine(WoodProduction());
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Farm_Follow_place_buildings.OverVillage = true;
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
                Farm_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
