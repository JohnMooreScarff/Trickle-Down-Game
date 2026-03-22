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
    private float Pollution = 0.01f;
    //consume
    private int wood = 2;
    private int power = 10;
    private int villageColliderCount = 0;
    private ParticleSystem ps;  

    void Start()
    {
        ResourceData.Power_demand += power;
        ResourceData.Wood_demand += wood;
        ResourceData.Stone_supply += stone;
        ResourceData.Wood_amount -= wood_cost;
        ResourceData.Money -=  money_cost + wood_cost * ResourceData.Wood_value;

        StartCoroutine(StoneProduction());
        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4 / ResourceData.Power_multiplier);
        if(ResourceData.Wood_amount >= wood)
        {
        ResourceData.Stone_amount += stone;
        ResourceData.Money -= wood * ResourceData.Wood_value;
        ResourceData.Wood_amount -= wood;
        ResourceData.Pollution += Pollution;
        }
        

        StartCoroutine(StoneProduction());
     }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Village"))
        {
            villageColliderCount++;
            Stone_Follow_place_buildings.OverVillage = true;
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
                Stone_Follow_place_buildings.OverVillage = false;
            }
        }
    }
}
