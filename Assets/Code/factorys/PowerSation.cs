using UnityEngine;
using System.Collections;
using TMPro;

public class PowerStation : MonoBehaviour
{
    //cost
    private int money_cost = 1000;
    private int wood_cost = 30;
    private int stone_cost = 40;
    //consume 
    private int wood = 10;
    private int Coal = 5;
    //produce
    private int power = 50;
    //consuming
    private bool using_wood = false;
    private bool using_Coal = false;

    void Start()
    {
        StartCoroutine(PowerStationConsumption());
        if(ResourceData.Stone_amount >= stone_cost)
        {
            ResourceData.Power_supply += power;
            ResourceData.Money -= money_cost + wood_cost * ResourceData.Wood_value_currant + stone_cost * ResourceData.Stone_value_currant;
            ResourceData.Wood_amount -= wood_cost;
            ResourceData.Stone_amount -= stone_cost;
        }
    }
    void Update()
    {
        if(!using_Coal)
        {
            using_wood = true;

        }
        else
        if(!using_wood)
        {
            using_Coal = true;

        }
    }
     IEnumerator PowerStationConsumption()
     {
        yield return new WaitForSeconds(4);
        if (ResourceData.Coal_amount >= Coal)
     {
        ResourceData.Coal_amount -= Coal;
        using_Coal = true;
        using_wood = false;
     }
     else if (ResourceData.Wood_amount >= wood)
     {
        ResourceData.Wood_amount -= wood;
        using_wood = true;
        using_Coal = false;

        // ResourceData.Wood_demand += wood;
        // if (ResourceData.Coal_demand > 0)
        // {
        // ResourceData.Coal_demand -= Coal;
        // }
     }
     StartCoroutine(PowerStationConsumption());
     }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Follow_place_buildings.OverVillage = true;
        }
    }
}
