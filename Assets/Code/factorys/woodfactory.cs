using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    private bool s_d = true;
    // produce
    private int wood = 10;


    void Start()
    {
        StartCoroutine(WoodProduction());
            if (s_d == true)
        {
            ResourceData.Wood_supply += wood;
            s_d = false;
        }
    }


     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Wood_amount += wood;
        StartCoroutine(WoodProduction());

     }



    
}
