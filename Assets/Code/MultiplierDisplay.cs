using UnityEngine;
using TMPro;
using System.Collections;

public class MultiplierDisplay : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private GameObject currentObject;
    
    
    
    void Start()
    {
        MonoBehaviour script = currentObject.GetComponent<MonoBehaviour>();
        Color orange = new Color(1.0f, 0.64f, 0.0f);
    }    

    void Update()
    {
        if(isPlacing == true)
        {
            script.enabled = true;

            if(script.TerrainMultiplier = 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if(TerrainMultiplier = 0.5f)
            {
                Multiplier_text.color = Color.orange;
            }
            else if(TerrainMultiplier = 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if(TerrainMultiplier = 2f)
            {
                Multiplier_text.color = Color.green;
            }
        }
        else
        {
            script.enabled = false;
        }
    }
}
