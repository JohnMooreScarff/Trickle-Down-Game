using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverInformation : MonoBehaviour
{
    public CanvasGroup HoverCity;
    // private float fadein = 0;
    // private float fadeout = 1;
    void start()
    {

    }
    
    public void MouseOverCityButton()
    {
        // fadein += Time.deltaTime/2;
        HoverCity.alpha = 1;
        HoverCity.interactable = true;
        HoverCity.blocksRaycasts = true;
        HoverCity.gameObject.SetActive(true);
    }

    public void MouseNotOverCityButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverCity.alpha = 0;
        HoverCity.interactable = false;
        HoverCity.blocksRaycasts = false;
        HoverCity.gameObject.SetActive(false);
    }
}
