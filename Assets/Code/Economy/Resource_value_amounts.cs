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
    public static float Wood_value = 4;
    public static int Wood_supply = 0;
    public static int Wood_demand = 0;
    public static float Wood_SD_Diff_ = 0.00F;

    //stone
    public static int Stone_amount = 10;
    public static float Stone_value = 8;
    public static int Stone_supply = 0;
    public static int Stone_demand = 0;
    public static float Stone_SD_Diff_ = 0.00F;

    //food
    public static int Food_amount = 10;
    public static float Food_value = 5;
    public static int Food_supply = 0;
    public static int Food_demand = 0;
    public static float Food_SD_Diff_ = 0.00F;

    //coal
    public static int Coal_amount = 10;
    public static float Coal_value = 20;
    public static int Coal_supply = 0;
    public static int Coal_demand = 0;
    public static float Coal_SD_Diff_ = 0.00F;

    //Iron
    public static int Iron_amount = 10;
    public static float Iron_value = 30;
    public static int Iron_supply = 0;
    public static int Iron_demand = 0;
    public static float Iron_SD_Diff_ = 0.00F;

    // money
    public TMP_Text Money_text;
    //wood
    public TMP_Text Wood_amount_text;
    public TMP_Text Wood_value_text;
    //stone
    public TMP_Text Stone_amount_text;
    public TMP_Text Stone_value_text;
    //food
    public TMP_Text Food_amount_text;
    public TMP_Text Food_value_text;
    //coal
    public TMP_Text Coal_amount_text;
    public TMP_Text Coal_value_text;
    //Iron
    public TMP_Text Iron_amount_text;
    public TMP_Text Iron_value_text;

    
    void Update()
    {   
        SupplyDemandWood();
        SupplyDemandStone();
        SupplyDemandFood();
        SupplyDemandCoal();
        SupplyDemandIron();
        text();
    }
    void SupplyDemandWood()
    {
        Wood_value = 2;
        if (Wood_supply == 0 && Wood_demand == 0) {
        } else if (Wood_supply == 0) {
        Wood_SD_Diff_ = 1;
        } 
        else 
        {
        Wood_SD_Diff_ = (float)Wood_demand / Wood_supply;
        if (Wood_SD_Diff_ <= 0.3)
            {
                Wood_SD_Diff_ = 0.3f;
                
            }
        }
        Wood_value = Wood_value * Wood_SD_Diff_;
    }
        void SupplyDemandStone()
    {
        Stone_value = 2;
        if (Stone_supply == 0 && Stone_demand == 0) {
        } else if (Stone_supply == 0) {
        Stone_SD_Diff_ = 1;
        } 
        else 
        {
        Stone_SD_Diff_ = (float)Stone_demand / Stone_supply;
        if (Stone_SD_Diff_ <= 0.3)
            {
                Stone_SD_Diff_ = 0.3f;
                
            }
        }
        Stone_value = Stone_value * Stone_SD_Diff_;
    }
        void SupplyDemandFood()
    {
        Food_value = 2;
        if (Food_supply == 0 && Food_demand == 0) {
        } else if (Food_supply == 0) {
        Food_SD_Diff_ = 1;
        } 
        else 
        {
        Food_SD_Diff_ = (float)Food_demand / Food_supply;
        if (Food_SD_Diff_ <= 0.3)
            {
                Food_SD_Diff_ = 0.3f;
                
            }
        }
        Food_value = Food_value * Food_SD_Diff_;
    }
        void SupplyDemandCoal()
    {
        Coal_value = 2;
        if (Coal_supply == 0 && Coal_demand == 0) {
        } else if (Coal_supply == 0) {
        Coal_SD_Diff_ = 1;
        } 
        else 
        {
        Coal_SD_Diff_ = (float)Coal_demand / Coal_supply;
        if (Coal_SD_Diff_ <= 0.3)
            {
                Coal_SD_Diff_ = 0.3f;
                
            }
        }
        Coal_value = Coal_value * Coal_SD_Diff_;
    }
        void SupplyDemandIron()
    {
        Iron_value = 2;
        if (Iron_supply == 0 && Iron_demand == 0) {
        } else if (Iron_supply == 0) {
        Iron_SD_Diff_ = 1;
        } 
        else 
        {
        Iron_SD_Diff_ = (float)Iron_demand / Iron_supply;
        if (Iron_SD_Diff_ <= 0.3)
            {
                Iron_SD_Diff_ = 0.3f;
                
            }
        }
        Iron_value = Iron_value * Iron_SD_Diff_;
    }

    void text()
    {
        //money
        Money_text.text =Mathf.RoundToInt(Money).ToString();
        Wood_amount_text.text = Wood_amount.ToString();
        //wood
        Wood_value_text.text = Wood_value.ToString("0.0");
        Wood_amount_text.text = Wood_amount.ToString();
        //stone
        Stone_value_text.text = Stone_value.ToString("0.0");
        Stone_amount_text.text = Stone_amount.ToString();
        //food
        Food_value_text.text = Food_value.ToString("0.0");
        Food_amount_text.text = Food_amount.ToString();
        //coal
        Coal_value_text.text = Coal_value.ToString("0.0");
        Coal_amount_text.text = Coal_amount.ToString();
        //Iron
        Iron_value_text.text = Iron_value.ToString("0.0");
        Iron_amount_text.text = Iron_amount.ToString();


        


    }

}
