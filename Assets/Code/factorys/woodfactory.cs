using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    //cost
    private int money_cost = 100;
    private int wood = 10;

    void Start()
    {
        ResourceData.Wood_supply += wood;
        StartCoroutine(WoodProduction());
        ResourceData.Money -= money_cost;
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Wood_amount += wood;
        StartCoroutine(WoodProduction());
     }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Follow_place_buildings.OverVillage = true;
        }
        else
        {
            Debug.Log("Not village");
            Follow_place_buildings.OverVillage = true;
        }
    }

}
