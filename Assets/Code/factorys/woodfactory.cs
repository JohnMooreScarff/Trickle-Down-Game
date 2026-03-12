using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    //cost
    private int money_cost = 300;
    private int wood = 8;
    //consume
    private int power = 10;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_supply += wood;
        StartCoroutine(WoodProduction());
        ResourceData.Money -= money_cost;
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        ResourceData.Wood_amount += wood;
        StartCoroutine(WoodProduction());
        ResourceData.Money += wood * ResourceData.Wood_value * 2;
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
