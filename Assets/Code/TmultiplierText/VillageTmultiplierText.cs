using UnityEngine;
using TMPro;
using System.Collections;

public class VillageTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        if(VillagePlacement.isPlacing == true)
        {
            Multiplier_text.enabled = true;
            Village village = gameObject.GetComponent<Village>();
            if(VillageTile.OverMountain == true)
            {
                village.TerrainMultiplier = 0.5f;
            }
            else if(VillageTile.OverSnow == true)
            {
                village.TerrainMultiplier = 0.2f;
            }
            else
            {
                village.TerrainMultiplier = 1f;
            } 
        
            if (village.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (village.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (village.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (village.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = village.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
