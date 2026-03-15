using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverInformation : MonoBehaviour
{
    public CanvasGroup HoverCity;
    public CanvasGroup HoverWood;
    public CanvasGroup HoverStone;
    public CanvasGroup HoverFood;
    public CanvasGroup HoverCoal;
    public CanvasGroup HoverIron;
    public CanvasGroup HoverTree;
    public CanvasGroup HoverCarboncatcher;
    public CanvasGroup HoverPowerplant;
    public CanvasGroup HoverWindturbine;

    // private float fadein = 0;
    // private float fadeout = 1;
    void start()
    {

    }
    //City
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
    //Wood
        public void MouseOverWoodButton()
    {
        // fadein += Time.deltaTime/2;
        HoverWood.alpha = 1;
        HoverWood.interactable = true;
        HoverWood.blocksRaycasts = true;
        HoverWood.gameObject.SetActive(true);
    }

    public void MouseNotOverWoodButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverWood.alpha = 0;
        HoverWood.interactable = false;
        HoverWood.blocksRaycasts = false;
        HoverWood.gameObject.SetActive(false);
    }
    //Stone
        public void MouseOverStoneButton()
    {
        // fadein += Time.deltaTime/2;
        HoverStone.alpha = 1;
        HoverStone.interactable = true;
        HoverStone.blocksRaycasts = true;
        HoverStone.gameObject.SetActive(true);
    }

    public void MouseNotOverStoneButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverStone.alpha = 0;
        HoverStone.interactable = false;
        HoverStone.blocksRaycasts = false;
        HoverStone.gameObject.SetActive(false);
    }
    //Food
        public void MouseOverFoodButton()
    {
        // fadein += Time.deltaTime/2;
        HoverFood.alpha = 1;
        HoverFood.interactable = true;
        HoverFood.blocksRaycasts = true;
        HoverFood.gameObject.SetActive(true);
    }

    public void MouseNotOverFoodButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverFood.alpha = 0;
        HoverFood.interactable = false;
        HoverFood.blocksRaycasts = false;
        HoverFood.gameObject.SetActive(false);
    }
    //Coal
        public void MouseOverCoalButton()
    {
        // fadein += Time.deltaTime/2;
        HoverCoal.alpha = 1;
        HoverCoal.interactable = true;
        HoverCoal.blocksRaycasts = true;
        HoverCoal.gameObject.SetActive(true);
    }

    public void MouseNotOverCoalButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverCoal.alpha = 0;
        HoverCoal.interactable = false;
        HoverCoal.blocksRaycasts = false;
        HoverCoal.gameObject.SetActive(false);
    }
    //Iron
        public void MouseOverIronButton()
    {
        // fadein += Time.deltaTime/2;
        HoverIron.alpha = 1;
        HoverIron.interactable = true;
        HoverIron.blocksRaycasts = true;
        HoverIron.gameObject.SetActive(true);
    }

    public void MouseNotOverIronButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverIron.alpha = 0;
        HoverIron.interactable = false;
        HoverIron.blocksRaycasts = false;
        HoverIron.gameObject.SetActive(false);
    }
    //Tree
        public void MouseOverTreeButton()
    {
        // fadein += Time.deltaTime/2;
        HoverTree.alpha = 1;
        HoverTree.interactable = true;
        HoverTree.blocksRaycasts = true;
        HoverTree.gameObject.SetActive(true);
    }

    public void MouseNotOverTreeButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverTree.alpha = 0;
        HoverTree.interactable = false;
        HoverTree.blocksRaycasts = false;
        HoverTree.gameObject.SetActive(false);
    }
    //Carboncatcher
        public void MouseOverCarboncatcherButton()
    {
        // fadein += Time.deltaTime/2;
        HoverCarboncatcher.alpha = 1;
        HoverCarboncatcher.interactable = true;
        HoverCarboncatcher.blocksRaycasts = true;
        HoverCarboncatcher.gameObject.SetActive(true);
    }

    public void MouseNotOverCarboncatcherButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverCarboncatcher.alpha = 0;
        HoverCarboncatcher.interactable = false;
        HoverCarboncatcher.blocksRaycasts = false;
        HoverCarboncatcher.gameObject.SetActive(false);
    }
    //Powerplant
        public void MouseOverPowerplantButton()
    {
        // fadein += Time.deltaTime/2;
        HoverPowerplant.alpha = 1;
        HoverPowerplant.interactable = true;
        HoverPowerplant.blocksRaycasts = true;
        HoverPowerplant.gameObject.SetActive(true);
    }

    public void MouseNotOverPowerplantButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverPowerplant.alpha = 0;
        HoverPowerplant.interactable = false;
        HoverPowerplant.blocksRaycasts = false;
        HoverPowerplant.gameObject.SetActive(false);
    }
    //Windturbine
        public void MouseOverWindturbineButton()
    {
        // fadein += Time.deltaTime/2;
        HoverWindturbine.alpha = 1;
        HoverWindturbine.interactable = true;
        HoverWindturbine.blocksRaycasts = true;
        HoverWindturbine.gameObject.SetActive(true);
    }

    public void MouseNotOverWindturbineButton()
    {
        // fadeout -= Time.deltaTime/2;
        HoverWindturbine.alpha = 0;
        HoverWindturbine.interactable = false;
        HoverWindturbine.blocksRaycasts = false;
        HoverWindturbine.gameObject.SetActive(false);
    }
}
