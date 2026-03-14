using UnityEngine;
using System.Collections;
using TMPro;

public class Tree : MonoBehaviour
{
    
    //cost
    private int money_cost = 500;
    public static int wood_cost = 60;
    public static int food_cost = 30;

    //produce
    private float Pollution = -0.05f;


    void Start()
    {
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Food_amount -= food_cost;
        ResourceData.Money -=  money_cost + wood_cost * ResourceData.Wood_value + food_cost * ResourceData.Food_value;

        StartCoroutine(Tree_oxygen());
    }
     IEnumerator Tree_oxygen()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        ResourceData.Pollution += Pollution;
        StartCoroutine(Tree_oxygen());
     }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            Debug.Log("over village");
            Tree_Follow_place_buildings.OverVillage = true;
        }
        // else
        // {
        //     Stone_Follow_place_buildings.OverVillage = false;
        // }
    }
}
