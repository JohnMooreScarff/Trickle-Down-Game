using UnityEngine;
using System.Collections;
using TMPro;

public class stonefactory : MonoBehaviour
{
    
    //cost
    private int money_cost = 500;
    public static int wood_cost = 20;

    //produce
    private int stone = 5;
    private float Pollution = 0.01f;
    //consume
    private int wood = 2;
    private int power = 10;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_supply += stone;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -=  money_cost + wood_cost * ResourceData.Wood_value;

        StartCoroutine(StoneProduction());
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(ResourceData.Wood_amount >= wood)
        {
        ResourceData.Stone_amount += stone;
        ResourceData.Money -= wood * ResourceData.Wood_value;
        ResourceData.Wood_amount -= wood;
        ResourceData.Pollution += Pollution;
        }
        

        StartCoroutine(StoneProduction());
     }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Stone_Follow_place_buildings.OverVillage = true;
        }
        // else
        // {
        //     Stone_Follow_place_buildings.OverVillage = false;
        // }
    }
}
