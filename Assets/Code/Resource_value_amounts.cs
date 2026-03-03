using UnityEngine;
using TMPro;

public class ResourceData : MonoBehaviour
{

    public static int Wood_amount = 4;
    public static int Stone_amount = 0;


    //public static int Wood_value = 0;
    public TMP_Text Wood_amount_text;
    public TMP_Text Stone_amount_text;
    
    void Update()
    { 
        Wood_amount_text.text = $"Wood : {Wood_amount}".ToString();
        Stone_amount_text.text = $"Stone : {Stone_amount}".ToString();
        //Debug.Log(Wood_amount + " " + Wood_value);
    }


}
