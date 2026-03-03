using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(WoodProduction());
    }


     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(1);
        ResourceData.Wood_amount += 10;
        StartCoroutine(WoodProduction());

     }



    
}
