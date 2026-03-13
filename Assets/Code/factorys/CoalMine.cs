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

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_demand += stone;
        ResourceData.Coal_supply += coal;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -= money_cost + (ResourceData.Wood_value * wood_cost) + (ResourceData.Stone_value * stone_cost);
        StartCoroutine(CoalProduction());
    }
     IEnumerator CoalProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(ResourceData.Wood_amount >= wood)
        {
        ResourceData.Coal_amount += coal;
        ResourceData.Money += coal * ResourceData.Coal_value;
        ResourceData.Wood_amount -= wood;
        ResourceData.Stone_amount -= stone;
        ResourceData.Pollution += Pollution;

        }
        

        StartCoroutine(CoalProduction());
     }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Coal_Follow_place_buildings.OverVillage = true;
        }
        else
        {
            Coal_Follow_place_buildings.OverVillage = false;
        }
    }
}
