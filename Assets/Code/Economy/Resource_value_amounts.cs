using UnityEngine;
using TMPro;

public class ResourceData : MonoBehaviour
{
    // effects
    public static float power = 0.00f;
    public static float IntrestRate = 1.05F;
    public static float QOL = 50;
    public static int  Pollution = 0;

    //money
    public static float Money = 100;

    // wood
    public static int Wood_amount = 4;
    public static float Wood_value = 2;
    public static int Wood_supply = 0;
    public static int Wood_demand = 0;
    public static float Wood_SD_Diff_ = 0.00F;

    //stone
    public static int Stone_amount = 10;
    public static float Stone_value = 4;
    public static int Stone_supply = 0;
    public static int Stone_demand = 0;
    public static float Stone_SD_Diff_ = 0.00F;

    //food
    public static int Food_amount = 10;
    public static float Food_value = 4;
    public static int Food_supply = 0;
    public static int Food_demand = 0;
    public static float Food_SD_Diff_ = 0.00F;

    //coal
    public static int Coal_amount = 10;
    public static float Coal_value = 4;
    public static int Coal_supply = 0;
    public static int Coal_demand = 0;
    public static float Coal_SD_Diff_ = 0.00F;

    //Iorn
    public static int Iorn_amount = 10;
    public static float Iorn_value = 4;
    public static int Iorn_supply = 0;
    public static int Iorn_demand = 0;
    public static float Iorn_SD_Diff_ = 0.00F;


    
    public TMP_Text Wood_amount_text;
    public TMP_Text Stone_amount_text;
    public TMP_Text Wood_supply_text;
    public TMP_Text Wood_demand_text;
    public TMP_Text Money_text;
    public TMP_Text SD_text;

    
    void Update()
    {   
        SupplyDemandWood();
        text();
    }
    void SupplyDemandWood()
    {
        if (Wood_supply == 0 && Wood_demand == 0) {
        } else if (Wood_supply == 0) {
        Wood_SD_Diff_ = 1;
        } 
        else 
        {
        Wood_SD_Diff_ = (float)Wood_demand / Wood_supply;
        }
    }

    void text()
    {
        Wood_amount_text.text = $"Wood : {Wood_amount}".ToString();
        Stone_amount_text.text = $"Stone : {Stone_amount}".ToString();
        Wood_supply_text.text = $"Wood supply: {Wood_supply}".ToString();
        Wood_demand_text.text = $"wood demand : {Wood_demand}".ToString();
        Money_text.text = $"Money : {Mathf.RoundToInt(Money)}".ToString();
        SD_text.text = $"S-D Wood: {Wood_SD_Diff_}".ToString();

    }

}
