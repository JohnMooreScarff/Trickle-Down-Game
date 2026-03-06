using UnityEngine;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    private int wood = 10;

    void Start()
    {
        ResourceData.Wood_supply += wood;
        StartCoroutine(WoodProduction());
    }
     IEnumerator WoodProduction()
     {
        yield return new WaitForSeconds(4);
        ResourceData.Wood_amount += wood;
        StartCoroutine(WoodProduction());
     }
}
