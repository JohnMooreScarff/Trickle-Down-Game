using UnityEngine;
using TMPro;

public class ResourceData : MonoBehaviour
{
    // effects
    public static double IntrestRate = 1.05;
    public static float QOL = 50;
    public static int  Pollution = 0;
    //money
    public static int Money = 100;
    // wood
    public static int Wood_amount = 4;
    public static float Wood_value = 2;
    public static int Wood_supply = 0;
    public static int Wood_demand = 0;

    //stone
    public static int Stone_amount = 10;
    public static float Stone_value = 4;


    
    public TMP_Text Wood_amount_text;
    public TMP_Text Stone_amount_text;
    public TMP_Text Wood_supply_text;
    public TMP_Text Wood_demand_text;
    public TMP_Text Money_text;

    
    void Update()
    {        
        Wood_amount_text.text = $"Wood : {Wood_amount}".ToString();
        Stone_amount_text.text = $"Stone : {Stone_amount}".ToString();
        Wood_supply_text.text = $"Wood supply: {Wood_supply}".ToString();
        Wood_demand_text.text = $"wood demand : {Wood_demand}".ToString();
        Money_text.text = $"Money : {Money}".ToString();
 
    }


}
