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
    //consume
    private int wood = 2;
    private int power = 10;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_supply += stone;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -=  wood_cost * ResourceData.Wood_value;
        StartCoroutine(StoneProduction());
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(ResourceData.Wood_amount >= wood)
        {
        ResourceData.Stone_amount += stone;
        ResourceData.Money += stone * ResourceData.Stone_value * 2;
        ResourceData.Wood_amount -= wood;
        }
        

        StartCoroutine(StoneProduction());
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
