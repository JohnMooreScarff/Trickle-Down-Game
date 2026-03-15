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


    void Start()
    {
        ResourceData.Iron_amount -= iron_cost;
        ResourceData.Coal_amount -= coal_cost;
        ResourceData.Money -=  money_cost + iron_cost * ResourceData.Iron_value + coal_cost * ResourceData.Coal_value;
        ResourceData.Power_supply += power;
    }
 
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            WindTurbine_Follow_place_buildings.OverVillage = true;
        }
        // else
        // {
        //     Stone_Follow_place_buildings.OverVillage = false;
        // }
    }
}
