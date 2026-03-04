using UnityEngine;
using TMPro;

public class ResourceData : MonoBehaviour
{
    // effects
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
    public static float SD_Diff = 0.00F;

    //stone
    public static int Stone_amount = 10;
    public static float Stone_value = 4;


    
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
        SD_Diff = 1;
        } 
        else 
        {
        SD_Diff = (float)Wood_demand / Wood_supply;
        }
    }

    void text()
    {
        Wood_amount_text.text = $"Wood : {Wood_amount}".ToString();
        Stone_amount_text.text = $"Stone : {Stone_amount}".ToString();
        Wood_supply_text.text = $"Wood supply: {Wood_supply}".ToString();
        Wood_demand_text.text = $"wood demand : {Wood_demand}".ToString();
        Money_text.text = $"Money : {Mathf.RoundToInt(Money)}".ToString();
        SD_text.text = $"S-D : {SD_Diff}".ToString();

    }

}
