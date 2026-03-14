using UnityEngine;
using System.Collections;

public class Debt : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(intrest());
    }
        
    IEnumerator intrest()
    {
        yield return new WaitForSeconds(30);
        if (ResourceData.Money <= 0)
        {
            ResourceData.Money = ResourceData.Money *= ResourceData.IntrestRate;
            Mathf.RoundToInt(ResourceData.Money);
        }
   
        StartCoroutine(intrest());
    }  
}
