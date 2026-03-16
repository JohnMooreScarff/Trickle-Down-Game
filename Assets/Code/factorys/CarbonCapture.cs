using UnityEngine;
using System.Collections;
using TMPro;

public class CarbonCapture : MonoBehaviour
{
    
    //cost
    private int money_cost = 2000;
    public static int iron_cost = 20;
    

    //produce
    private float Pollution = -0.40f;
    //consume
    private int money = 50;
    private int power = 25;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Iron_amount -= iron_cost;
        ResourceData.Money -=  money_cost + iron_cost * ResourceData.Iron_value;
        StartCoroutine(Carboncapture());
    }
     IEnumerator Carboncapture()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        ResourceData.Money -= money;
        ResourceData.Pollution += Pollution;
        StartCoroutine(Carboncapture());
     }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Carbon_capture_Follow_place_buildings.OverVillage = true;
        }
        // else
        // {
        //     Stone_Follow_place_buildings.OverVillage = false;
        // }
    }
}
