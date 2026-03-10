using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Village : MonoBehaviour

{
    //cost
    
    public static int stone_cost = 20;
    public static int wood_cost = 35;
    //public static float money_cost = 10000;
    // consume
    private int wood = 4;
    private int stone = 2;
    //produce
    private int money = 10;  

    //Leveling
    private int Level = 1;
    private int building_count = 0;

    void Start()
    {
        StartCoroutine(villageProduction());
        if(ResourceData.Stone_amount >= stone_cost)
        {
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_demand += stone;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -= ResourceData.Stone_value * stone_cost;
        }


    }
     IEnumerator villageProduction()
     {
        yield return new WaitForSeconds(3);
        if (ResourceData.Wood_amount >= wood)
        {
            ResourceData.Money += money * Level * ResourceData.Wood_value;
            ResourceData.Money -= wood * ResourceData.Wood_value;
            ResourceData.Wood_amount -= wood * Level;
        }
                Debug.Log(Level);
                Debug.Log(building_count);

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
