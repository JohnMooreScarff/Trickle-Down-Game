using UnityEngine;
using System.Collections;
using TMPro;

public class stonefactory : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(WoodProduction());
    }


     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(1);
        ResourceData.Stone_amount += 5;
        StartCoroutine(WoodProduction());

     }



    
}
