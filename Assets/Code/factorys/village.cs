using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Village : MonoBehaviour

{
    //cost
    
    public static int stone_cost = 70;
    public static int wood_cost = 100;
    public static float money_cost = 10000;
    // consume
    private int wood = 5;
    private int stone = 4;
    private int food = 10; 
    private int coal = 2;
    private int iron = 1;

    private int power = 25;
    private enum ConsumptionType { None, Wood, Stone, Food, Coal, Iron }
    private ConsumptionType Wood_currentConsumption = ConsumptionType.None;
    private ConsumptionType Wood_lastConsumption = ConsumptionType.None;
    private ConsumptionType Stone_currentConsumption = ConsumptionType.None;
    private ConsumptionType Stone_lastConsumption = ConsumptionType.None;
    private ConsumptionType Food_currentConsumption = ConsumptionType.None;
    private ConsumptionType Food_lastConsumption = ConsumptionType.None;
    private ConsumptionType Coal_currentConsumption = ConsumptionType.None;
    private ConsumptionType Coal_lastConsumption = ConsumptionType.None;
    private ConsumptionType Iron_currentConsumption = ConsumptionType.None;
    private ConsumptionType Iron_lastConsumption = ConsumptionType.None;
    //produce
    private int money = 10;  

    //Leveling
    private int Level = 1;
    // private int building_count = 0;

    void Start()
    {
        StartCoroutine(villageProduction());
        if(ResourceData.Stone_amount >= stone_cost && ResourceData.Wood_amount >= wood_cost)
        {
        ResourceData.Power_demand += power;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -= ResourceData.Stone_value * stone_cost;
        ResourceData.Money -= ResourceData.Wood_value * wood_cost;
        
        }


    }
     IEnumerator villageProduction()
     {
        yield return new WaitForSeconds(3);
        
        if (ResourceData.Wood_amount >= wood)
        {
            ResourceData.Money -= wood * Level * ResourceData.Wood_value;
            ResourceData.Wood_amount -= wood * Level;
            ResourceData.Money += money * Level;
            Wood_currentConsumption = ConsumptionType.Wood;
            if(Wood_currentConsumption != Wood_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Wood_lastConsumption = Wood_currentConsumption;
            }
        }
        if (ResourceData.Stone_amount >= stone)
        {
            ResourceData.Money -= stone * Level * ResourceData.Stone_value;
            ResourceData.Stone_amount -= stone * Level;
            ResourceData.Money += money * Level;
            Stone_currentConsumption = ConsumptionType.Stone;
            if(Stone_currentConsumption != Stone_lastConsumption)
            {
                ResourceData.Stone_demand += stone;
                Stone_lastConsumption = Stone_currentConsumption;
            } 
        }
        if(ResourceData.Food_amount >= food)
        {
            ResourceData.Money -= food * Level * ResourceData.Food_value;
            ResourceData.Food_amount -= food * Level;
            ResourceData.Money += money * Level;
            Food_currentConsumption = ConsumptionType.Food;
            if(Food_currentConsumption != Food_lastConsumption)
            {
                ResourceData.Food_demand += food;
                Food_lastConsumption = Food_currentConsumption;
            } 
        }
        if(ResourceData.Coal_amount >= coal)
        {
            ResourceData.Money -= coal * Level * ResourceData.Coal_value;
            ResourceData.Coal_amount -= coal * Level;
            ResourceData.Money += money * Level;
            Coal_currentConsumption = ConsumptionType.Coal;
            if(Coal_currentConsumption != Coal_lastConsumption)
            {
                ResourceData.Coal_demand += coal;
                Coal_lastConsumption = Coal_currentConsumption;
            } 
        }
        if(ResourceData.Iron_amount >= iron)
        {
            ResourceData.Money -= iron * Level * ResourceData.Iron_value;
            ResourceData.Iron_amount -= iron * Level;
            ResourceData.Money += money * Level;
            Iron_currentConsumption = ConsumptionType.Iron;
            if(Iron_currentConsumption != Iron_lastConsumption)
            {
                ResourceData.Iron_demand += iron;
                Iron_lastConsumption = Iron_currentConsumption;
            } 
        }

        //Level check 
        // if (building_count >= 10 && building_count <= 20)
        // {
        //     Level = 2;
        //     ResourceData.Wood_demand = wood wood * Level;
        // }
        StartCoroutine(villageProduction());
     }
    // public void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("map"))
    //     {
    //         Debug.Log("not overwater");
    //         VillagePlacement.OverWater = false;
    //     }
    //     else
    //     {
    //         Debug.Log("over overwater");
    //         VillagePlacement.OverWater = true;
    //     }
    // }
}
