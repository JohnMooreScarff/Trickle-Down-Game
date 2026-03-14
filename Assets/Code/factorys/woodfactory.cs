using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    //cost
    private int money_cost = 600;
    //produce
    private int wood = 8;
    private float Pollution = 0.01f;
    //consume
    private int power = 10;

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_supply += wood;
        ResourceData.Money -= money_cost;
        StartCoroutine(WoodProduction());
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        ResourceData.Wood_amount += wood;
        ResourceData.Pollution += Pollution;
        StartCoroutine(WoodProduction());
     }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Wood_Follow_place_buildings.OverVillage = true;
        }
        // else
        // {
        //     Wood_Follow_place_buildings.OverVillage = false;
        // }
    }
}
