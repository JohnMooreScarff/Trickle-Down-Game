using UnityEngine;
using System.Collections;
using TMPro;

public class stonefactory : MonoBehaviour
{
    private int stone = 5;

    void Start()
    {
        ResourceData.Stone_supply += stone;
        StartCoroutine(StoneProduction());
    }
     IEnumerator StoneProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Stone_amount += stone;
        StartCoroutine(StoneProduction());
     }  
}
