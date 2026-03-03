using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
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
        statcon.Wood_amount += 10;
        StartCoroutine(WoodProduction());

     }



    
}
