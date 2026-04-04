using UnityEngine;
using System.Collections;
using TMPro;

public class Farm : MonoBehaviour
{
    //cost
    private int money_cost = 1000;
    public static int stone_cost = 40;
    public static int wood_cost = 60;
    //production
    private int food = 6;
    private float Pollution = 0.02f;
    //consume
    private int power = 10;
    private int villageColliderCount = 0;  

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Stone_amount -= stone_cost;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Food_supply += food;
        StartCoroutine(WoodProduction());
        ResourceData.Money -= money_cost + (ResourceData.Wood_value * wood_cost) + (ResourceData.Stone_value * stone_cost);
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        ResourceData.Food_amount += food;
        StartCoroutine(WoodProduction());
        ResourceData.Pollution += Pollution;
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Farm_Follow_place_buildings.OverVillage = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount--;
            if (villageColliderCount <= 0)
            {
                villageColliderCount = 0;
                Farm_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
