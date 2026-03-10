using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup ResourceMenu;
    public CanvasGroup ManufacturingMenu;
    public CanvasGroup EnergyMenu;

    public float transitionDuration = 0.25f;

    void Start()
    {
        ShowMainMenuInstant();
    }

    // ---------- BUTTON EVENTS ----------

    public void OpenResourceMenu()
    {
        StartCoroutine(TransitionMenus(mainMenu, ResourceMenu));
    }
        public void OpenManufacturingMenu()
    {
        StartCoroutine(TransitionMenus(mainMenu, ManufacturingMenu));
    }
        public void OpenEnergyMenu()
    {
        StartCoroutine(TransitionMenus(mainMenu, EnergyMenu));
    }

    public void BackToMainMenuFromResourceMenu()
    {
        StartCoroutine(TransitionMenus(ResourceMenu, mainMenu));
    }
        public void BackToMainMenuManufacturingMenu()
    {
        StartCoroutine(TransitionMenus(ManufacturingMenu, mainMenu));
    }
        public void BackToMainMenuFromEnergyMenu()
    {
        StartCoroutine(TransitionMenus(EnergyMenu, mainMenu));
    }


    // ---------- INITIAL STATE ----------

    void ShowMainMenuInstant()
    {
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;

        ResourceMenu.alpha = 0;
        ResourceMenu.interactable = false;
        ResourceMenu.blocksRaycasts = false;
        ResourceMenu.gameObject.SetActive(false);

        ManufacturingMenu.alpha = 0;
        ManufacturingMenu.interactable = false;
        ManufacturingMenu.blocksRaycasts = false;
        ManufacturingMenu.gameObject.SetActive(false);

        EnergyMenu.alpha = 0;
        EnergyMenu.interactable = false;
        EnergyMenu.blocksRaycasts = false;
        EnergyMenu.gameObject.SetActive(false);
    }

    // ---------- TRANSITION SYSTEM ----------

    IEnumerator TransitionMenus(CanvasGroup currentMenu, CanvasGroup nextMenu)
    {
        float timer = 0f;

        nextMenu.gameObject.SetActive(true);

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;

            float progress = timer / transitionDuration;

            // fade out current
            currentMenu.alpha = 1 - progress;

            // fade in next
            nextMenu.alpha = progress;

            yield return null;
        }

        // disable the old menu
        currentMenu.interactable = false;
        currentMenu.blocksRaycasts = false;
        currentMenu.gameObject.SetActive(false);

        // enable the new menu
        nextMenu.interactable = true;
        nextMenu.blocksRaycasts = true;
    }
}
