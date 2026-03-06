using UnityEngine;
using System.Collections;
using TMPro;

public class Village : MonoBehaviour

{
    private bool s_d = true;
    //cost
    public static int stone_cost = 4;
    public static float money_cost = 10000;
    // consume
    private int wood = 4;
    //produce
    private int money = 100;

    void Start()
    {
        StartCoroutine(villageProduction());
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_amount -= stone_cost ;
        ResourceData.Money -= money_cost;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            Debug.Log("over village");
            Follow_place_buildings.OverVillage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            Debug.Log("not village");
            Follow_place_buildings.OverVillage = false;
        }
    }

     IEnumerator villageProduction()
     {
        yield return new WaitForSeconds(3);
        if (ResourceData.Wood_amount >= wood)
        {
            ResourceData.Money += money;
            ResourceData.Wood_amount -= wood;
        }
        
        StartCoroutine(villageProduction());

     }


    
}
