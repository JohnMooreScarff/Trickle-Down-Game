using UnityEngine;
using System.Collections;
using TMPro;

public class PowerStation : MonoBehaviour
{

    //cost
    private int money_cost = 1000;
    public static int wood_cost = 30;
    public static int stone_cost = 40;
    //consume 
    private int wood = 10;
    private int Coal = 5;
    
    //produce
    private int wood_power = 60;
    private int coal_power = 200;
    private float Pollution = 0.03f;

    //consuming
    private enum ConsumptionType { None, Wood, Coal }
    private ConsumptionType currentConsumption = ConsumptionType.None;
    private ConsumptionType lastConsumption = ConsumptionType.None;
    private int villageColliderCount = 0;
    public float TerrainMultiplier = 1f;


    void Start()
    {
        StartCoroutine(PowerStationConsumption());
        if(ResourceData.Stone_amount >= stone_cost && ResourceData.Wood_amount >= wood_cost)
        {
            ResourceData.Money -= money_cost + wood_cost * ResourceData.Wood_value_currant + stone_cost * ResourceData.Stone_value_currant;
            ResourceData.Wood_amount -= wood_cost;
            ResourceData.Stone_amount -= stone_cost;            
        }
        if(PowerTile.OverMountain == true)
        {
            TerrainMultiplier = 0.5f;
        }
        else if(PowerTile.OverSnow == true)
        {
            TerrainMultiplier = 0.2f;
        }
    }
IEnumerator PowerStationConsumption()
{
    bool lastFloodedState = false;

    while (true)
    {
        yield return new WaitForSeconds(4);
        bool isFlooded = GetComponent<WaterDissable>().Flooded;

        if (isFlooded != lastFloodedState)
        {
            if (isFlooded)
            {
                if (lastConsumption == ConsumptionType.Coal)
                {
                    ResourceData.Power_supply -= coal_power;
                    ResourceData.Coal_demand -= Coal;
                }
                else if (lastConsumption == ConsumptionType.Wood)
                {
                    ResourceData.Power_supply -= wood_power;
                    ResourceData.Wood_demand -= wood;
                }
            }
            else
            {
                if (lastConsumption == ConsumptionType.Coal)
                {
                    ResourceData.Power_supply += coal_power;
                    ResourceData.Coal_demand += Coal;
                }
                else if (lastConsumption == ConsumptionType.Wood)
                {
                    ResourceData.Power_supply += wood_power;
                    ResourceData.Wood_demand += wood;
                }
            }

            lastFloodedState = isFlooded;
        }
        if (!isFlooded)
        {
            if (ResourceData.Coal_amount >= Coal)
            {
                ResourceData.Pollution += Pollution;
                ResourceData.Coal_amount -= Coal;
                currentConsumption = ConsumptionType.Coal;

                if (currentConsumption != lastConsumption)
                {
                    if (lastConsumption == ConsumptionType.Wood)
                    {
                        ResourceData.Wood_demand -= wood;
                        ResourceData.Power_supply -= wood_power;
                    }
                    ResourceData.Power_supply += coal_power;
                    ResourceData.Coal_demand += Coal;
                    lastConsumption = currentConsumption;
                }
            }
            else if (ResourceData.Wood_amount >= wood)
            {
                ResourceData.Pollution += Pollution;
                ResourceData.Wood_amount -= wood;
                currentConsumption = ConsumptionType.Wood;

                if (currentConsumption != lastConsumption)
                {
                    if (lastConsumption == ConsumptionType.Coal)
                    {
                        ResourceData.Power_supply -= coal_power;
                        ResourceData.Coal_demand -= Coal;
                    }
                    ResourceData.Power_supply += wood_power;
                    ResourceData.Wood_demand += wood;
                    lastConsumption = currentConsumption;
                }
            }
            else
            {
                currentConsumption = ConsumptionType.None;

                if (lastConsumption == ConsumptionType.Wood)
                {
                    ResourceData.Power_supply -= wood_power;
                    ResourceData.Wood_demand -= wood;
                }
                else if (lastConsumption == ConsumptionType.Coal)
                {
                    ResourceData.Power_supply -= coal_power;
                    ResourceData.Coal_demand -= Coal;
                }

                lastConsumption = currentConsumption;
            }
        }
    }
}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Power_Follow_place_buildings.OverVillage = true;
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
                Power_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
