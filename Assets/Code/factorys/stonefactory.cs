using UnityEngine;
using System.Collections;
using TMPro;

public class stonefactory : MonoBehaviour
{
    //cost
    private int money_cost = 500;
    private int stone = 5;

    void Start()
    {
        ResourceData.Stone_supply += stone;
        StartCoroutine(StoneProduction());
        ResourceData.Money -= money_cost;
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Stone_amount += stone;
        StartCoroutine(StoneProduction());
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
