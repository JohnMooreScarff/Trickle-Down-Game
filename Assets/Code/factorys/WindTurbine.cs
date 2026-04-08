using UnityEngine;
using System.Collections;
using TMPro;

public class WindTurbine : MonoBehaviour
{
    
    //cost
    private int money_cost = 200;
    public static int iron_cost = 10;
    public static int coal_cost = 20;

    //produce
    private int power = 100;
    private int villageColliderCount = 0;
    private bool lastFloodedState = false;
    public static float TerrainMultiplier = 1f;



    void Start()
    {
        ResourceData.Iron_amount -= iron_cost;
        ResourceData.Coal_amount -= coal_cost;
        ResourceData.Money -=  money_cost + iron_cost * ResourceData.Iron_value + coal_cost * ResourceData.Coal_value;
        ResourceData.Power_supply += power;
        if(WindTurbineTile.OverMountain == true)
        {
            TerrainMultiplier = TerrainMultiplier/2;
        }
        StartCoroutine(Areweflooded());

    }
    IEnumerator Areweflooded()
{
    while (true)
    {
        yield return new WaitForSeconds(1);

        bool isFlooded = GetComponent<WaterDissable>().Flooded;

        if (isFlooded != lastFloodedState)
        {
            if (isFlooded)
            {
                ResourceData.Power_supply -= power;
            }
            else
            {

                ResourceData.Power_supply += power;
            }
            lastFloodedState = isFlooded;
        }
    }
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            WindTurbine_Follow_place_buildings.OverVillage = true;
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
                WindTurbine_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
