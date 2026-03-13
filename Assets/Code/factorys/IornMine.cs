using UnityEngine;
using System.Collections;
using TMPro;

public class IornMine : MonoBehaviour
{
    
    //cost
    private int money_cost = 500;
    public static int coal_cost = 20;
    public static int stone_cost = 70;

    //produce
    private int Iron = 3;
    private float Pollution = 0.03f;
    //consume
    private int wood = 4;
    private int coal = 2;
    private int power = 20;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Coal_demand += coal;
        ResourceData.Iron_supply += Iron;
        ResourceData.Coal_amount -= coal_cost;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Money -= money_cost + (ResourceData.Wood_value * coal_cost) + (ResourceData.Stone_value * stone_cost);
        StartCoroutine(StoneProduction());
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(ResourceData.Wood_amount >= wood)
        {
        ResourceData.Iron_amount += Iron;
        ResourceData.Money += Iron * ResourceData.Stone_value;
        ResourceData.Wood_amount -= wood;
        ResourceData.Coal_amount -= coal;
        ResourceData.Pollution += Pollution;
        }
        

        StartCoroutine(StoneProduction());
     }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Iron_Follow_place_buildings.OverVillage = true;
        }
        else
        {
            Stone_Follow_place_buildings.OverVillage = false;
        }
    }
}
