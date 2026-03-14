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
    private int money = 40;

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
        ResourceData.village_ammount += 1;
        
        }


    }
     IEnumerator villageProduction()
     {
        yield return new WaitForSeconds(3);

        //wood
        if (ResourceData.Wood_amount >= wood)
        {
            ResourceData.Money -= wood * Level * ResourceData.Wood_value;
            ResourceData.Wood_amount -= wood * Level;
            ResourceData.Money += money * Level;

            Wood_currentConsumption = ConsumptionType.Wood;
            if (Wood_currentConsumption != Wood_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Wood_lastConsumption = Wood_currentConsumption;
                ResourceData.QOl_wood += 1;
            }
        }
        else
        {
            Wood_currentConsumption = ConsumptionType.None;
            if (Wood_currentConsumption != Wood_lastConsumption)
            {
                Wood_lastConsumption = Wood_currentConsumption;
                ResourceData.QOl_wood -= 1;
            }
        }

        //stone
        if (ResourceData.Stone_amount >= stone)
        {
            ResourceData.Money -= stone * Level * ResourceData.Stone_value;
            ResourceData.Stone_amount -= stone * Level;
            ResourceData.Money += money * Level * 2;
            Stone_currentConsumption = ConsumptionType.Stone;
            if(Stone_currentConsumption != Stone_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Stone_lastConsumption = Stone_currentConsumption;
                ResourceData.QOl_stone += 1;
            }
        }
        else
        {
            Wood_currentConsumption = ConsumptionType.None;
            if (Stone_currentConsumption != Stone_lastConsumption)
            {
                Stone_lastConsumption = Stone_currentConsumption;
                ResourceData.QOl_stone -= 1;
            }
        }

        //food
        if(ResourceData.Food_amount >= food)
        {
            ResourceData.Money -= food * Level * ResourceData.Food_value;
            ResourceData.Food_amount -= food * Level;
            ResourceData.Money += money * Level * 3;
            Food_currentConsumption = ConsumptionType.Food;
            if(Food_currentConsumption != Food_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Food_lastConsumption = Food_currentConsumption;
                ResourceData.QOl_stone += 1;
            }
        }
        else
        {
            Wood_currentConsumption = ConsumptionType.None;
            if (Food_currentConsumption != Food_lastConsumption)
            {
                Food_lastConsumption = Food_currentConsumption;
                ResourceData.QOl_stone -= 1;
            }
        }

        //coal
        if(ResourceData.Coal_amount >= coal)
        {
            ResourceData.Money -= coal * Level * ResourceData.Coal_value;
            ResourceData.Coal_amount -= coal * Level;
            ResourceData.Money += money * Level * 4;
            Coal_currentConsumption = ConsumptionType.Coal;
            if(Coal_currentConsumption != Coal_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Coal_lastConsumption = Coal_currentConsumption;
                ResourceData.QOl_stone += 1;
            }
        }
        else
        {
            Wood_currentConsumption = ConsumptionType.None;
            if (Coal_currentConsumption != Coal_lastConsumption)
            {
                Coal_lastConsumption = Coal_currentConsumption;
                ResourceData.QOl_stone -= 1;
            }
        }

        //iron
        if(ResourceData.Iron_amount >= iron)
        {
            ResourceData.Money -= iron * Level * ResourceData.Iron_value;
            ResourceData.Iron_amount -= iron * Level;
            ResourceData.Money += money * Level * 5;
            Iron_currentConsumption = ConsumptionType.Iron;
            if(Iron_currentConsumption != Iron_lastConsumption)
            {
                ResourceData.Wood_demand += wood;
                Iron_lastConsumption = Iron_currentConsumption;
                ResourceData.QOl_stone += 1;
            }
        }
        else
        {
            Wood_currentConsumption = ConsumptionType.None;
            if (Iron_currentConsumption != Iron_lastConsumption)
            {
                Iron_lastConsumption = Iron_currentConsumption;
                ResourceData.QOl_stone -= 1;
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
