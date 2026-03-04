using UnityEngine;
using System.Collections;
using TMPro;

public class Village : MonoBehaviour

{
    private bool s_d = true;
    //cost
    public static int stone_cost = 4;
    public static int money_cost = 0;
    // consume
    private int wood = 4;
    //produce
    private int money = 10;

    void Start()
    {
        StartCoroutine(villageProduction());
        if (s_d == true)
        {
            ResourceData.Wood_demand += wood;
            ResourceData.Stone_amount -= stone_cost ;
            money_cost = ResourceData.Stone_value;
            ResourceData.Money -= money_cost;
            s_d = false;
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
