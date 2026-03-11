using UnityEngine;
using System.Collections;
using TMPro;

public class Farm : MonoBehaviour
{
    //cost
    private int money_cost = 1000;
    private int stone_cost = 40;
    private int wood_cost = 60;
    //production
    private int food = 5;
    //consume
    private int power = 10;
    

    void Start()
    {
        ResourceData.Food_supply += food;
        StartCoroutine(WoodProduction());
        ResourceData.Money -= money_cost;
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Food_amount += food;
        StartCoroutine(WoodProduction());
        ResourceData.Money += food * ResourceData.Food_value * 2;
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
