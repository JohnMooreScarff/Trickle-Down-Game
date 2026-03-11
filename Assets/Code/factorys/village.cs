using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Village : MonoBehaviour

{
    //cost
    
    public static int stone_cost = 70;
    public static int wood_cost = 100;
    //public static float money_cost = 10000;
    // consume
    private int wood = 4;
    private int stone = 2;
    private int food = 10; 
    private int power = 25;
    //produce
    private int money = 50;  

    //Leveling
    private int Level = 1;
    // private int building_count = 0;

    void Start()
    {
        StartCoroutine(villageProduction());
        if(ResourceData.Stone_amount >= stone_cost)
        {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_demand += stone;
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
            ResourceData.Money += money * Level;
            ResourceData.Money -= wood * Level * ResourceData.Wood_value;
            ResourceData.Money -= stone * Level * ResourceData.Stone_value;
            ResourceData.Money -= food * Level * ResourceData.Food_value;
            ResourceData.Wood_amount -= wood * Level;
            ResourceData.Stone_amount -= stone * Level;
        }
                // Debug.Log(Level);
                // Debug.Log(building_count);

        //Level check 
        // if (building_count >= 10 && building_count <= 20)
        // {
        //     Level = 2;
        //     ResourceData.Wood_demand = wood wood * Level;
        // }
        StartCoroutine(villageProduction());
     }
    //building ammount check
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("+1");
    //     building_count += 1;
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     Debug.Log("-1");
    //     building_count -= 1;    
    // }
}
