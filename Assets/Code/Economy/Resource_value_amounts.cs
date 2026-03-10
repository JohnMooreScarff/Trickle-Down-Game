using UnityEngine;
using TMPro;

public class ResourceData : MonoBehaviour
{
    // effects
    public static float IntrestRate = 1.05F;
    public static float QOL = 50;
    public static float Pollution = 0f;

    //power
    public static float Power_supply = 1f;
    public static float Power_demand = 1f;
    public static float Power_SD_Diff_ = 1f;
    public static float Power_multiplier = 0.4f;
    public static float power_percentage_display = 40f;

    //money
    public static float Money = 100;

    // wood
    public static float Wood_amount = 100;
    public static float Wood_value = 4;
    public static int Wood_supply = 1;
    public static int Wood_demand = 1;
    public static float Wood_SD_Diff_ = 0;
    public static float Wood_value_currant = 4;
    

    //stone
    public static float Stone_amount = 100;
    public static float Stone_value = 8;
    public static int Stone_supply = 1;
    public static int Stone_demand = 1;
    public static float Stone_SD_Diff_ = 0f;
    public static float Stone_value_currant = 8f;

    //food
    public static float Food_amount = 10;
    public static float Food_value = 5;
    public static int Food_supply = 1;
    public static int Food_demand = 1;
    public static float Food_SD_Diff_ = 0F;
    public static float Food_value_currant = 5F;

    //coal
    public static float Coal_amount = 10;
    public static float Coal_value = 20;
    public static int Coal_supply = 1;
    public static int Coal_demand = 1;
    public static float Coal_SD_Diff_ = 0F;
    public static float Coal_value_currant = 20F;

    //Iron
    public static float Iron_amount = 10;
    public static float Iron_value = 30;
    public static int Iron_supply = 1;
    public static int Iron_demand = 1;
    public static float Iron_SD_Diff_ = 0F;
    public static float Iron_value_currant = 30F;

    // money
    public TMP_Text Money_text;
    //power
    public TMP_Text Power_Percentage_text;
    //Pollution
    public TMP_Text Pollution_Percentage_text;
    //QOL
    public TMP_Text QOL_Percentage_text;
    //wood
    public TMP_Text Wood_amount_text;
    public TMP_Text Wood_value_currant_text;
    //stone
    public TMP_Text Stone_amount_text;
    public TMP_Text Stone_value_currant_text;
    //food
    public TMP_Text Food_amount_text;
    public TMP_Text Food_value_currant_text;
    //coal
    public TMP_Text Coal_amount_text;
    public TMP_Text Coal_value_currant_text;
    //Iron
    public TMP_Text Iron_amount_text;
    public TMP_Text Iron_value_currant_text;

    
    void Update()
    {   
        SupplyDemandPower();
        SupplyDemandWood();
        SupplyDemandStone();
        SupplyDemandFood();
        SupplyDemandCoal();
        SupplyDemandIron();
        text();
    }
    void SupplyDemandWood()
    {
        Wood_value = 4;
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
        if (Wood_value >= Wood_value_currant)
        {
        Wood_value_currant += (float)(0.3 * Time.deltaTime);
        }
        else
        Wood_value_currant -= (float)(0.3 * Time.deltaTime);

    }
        void SupplyDemandStone()
    {
        Stone_value = 8;
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
        if (Stone_value >= Stone_value_currant)
        {
        Stone_value_currant += (float)(0.3 * Time.deltaTime);
        }
        else
        Stone_value_currant -= (float)(0.3 * Time.deltaTime);
    }
        void SupplyDemandFood()
    {
        Food_value = 5;
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
        if (Food_value >= Food_value_currant)
        {
        Food_value_currant += (float)(0.3 * Time.deltaTime);
        }
        else
        Food_value_currant -= (float)(0.3 * Time.deltaTime);
    }
        void SupplyDemandCoal()
    {
        Coal_value = 20;
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
        if (Coal_value >= Coal_value_currant)
        {
        Coal_value_currant += (float)(0.3 * Time.deltaTime);
        }
        else
        Coal_value_currant -= (float)(0.3 * Time.deltaTime);
    }
        void SupplyDemandIron()
    {
        Iron_value = 30;
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
        if (Iron_value >= Iron_value_currant)
        {
        Iron_value_currant += (float)(0.3 * Time.deltaTime);
        }
        else
        Iron_value_currant -= (float)(0.3 * Time.deltaTime);
    }
        void SupplyDemandPower()
    {
        Power_SD_Diff_ = 1;
        if (Power_supply == 0 && Power_demand == 0) {
        } else if (Power_supply == 0) {
        Power_SD_Diff_ = 1;
        }   
        else 
        {
        power_percentage_display = 40f;
        Power_SD_Diff_ = (float)Power_demand / Power_supply;
        if (Power_SD_Diff_ <= 0.4)
            {
                power_percentage_display = 40f;
                
            }
            else if (Power_SD_Diff_ >= 1)
            {
                power_percentage_display = 100;
            }
        }
        if (Power_SD_Diff_ >= power_percentage_display/100)
        {
            power_percentage_display += (float)(2 * Time.deltaTime);
        }
        else
            power_percentage_display -= (float)(2 * Time.deltaTime);
        
    }

    void text()
    {
        //money
        Money_text.text =Mathf.RoundToInt(Money).ToString();
        //power
        if(Power_SD_Diff_ >= 100)
        {
        Power_Percentage_text.text = power_percentage_display.ToString("0");
        }
        else if( Power_SD_Diff_ <= 40)
        {
            Power_Percentage_text.text = power_percentage_display.ToString("0");
        }
        else
        {
            Power_Percentage_text.text = power_percentage_display.ToString("0.00");
        }
        //wood
        if(Wood_value_currant >= 10)
        {
            Wood_value_currant_text.text = Wood_value_currant.ToString("0");
        }
        else
        {
            Wood_value_currant_text.text = Wood_value_currant.ToString("0.0");
        }
        Wood_amount_text.text = Wood_amount.ToString("0");
        //stone
        if(Stone_value_currant >= 10)
        {
            Stone_value_currant_text.text = Stone_value_currant.ToString("0");
        }
        else
        {
            Stone_value_currant_text.text = Stone_value_currant.ToString("0.0");
        }
        Stone_amount_text.text = Stone_amount.ToString("0");
        //food
        if(Food_value_currant >= 10)
        {
            Food_value_currant_text.text = Food_value_currant.ToString("0");
        }
        else
        {
            Food_value_currant_text.text = Food_value_currant.ToString("0.0");
        }
        Food_amount_text.text = Food_amount.ToString("0");
        //coal
        if(Coal_value_currant >= 10)
        {
            Coal_value_currant_text.text = Coal_value_currant.ToString("0");
        }
        else
        {
            Coal_value_currant_text.text = Coal_value_currant.ToString("0.0");
        }
        Coal_amount_text.text = Coal_amount.ToString("0");
        //Iron
        if(Iron_value_currant >= 10)
        {
            Iron_value_currant_text.text = Iron_value_currant.ToString("0");
        }
        else
        {
            Iron_value_currant_text.text = Iron_value_currant.ToString("0.0");
        }
        Iron_amount_text.text = Iron_amount.ToString("0");


        


    }

}
