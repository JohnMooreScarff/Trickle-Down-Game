using UnityEngine;
using TMPro;
using System.Collections;

public class PowerTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        PowerStation powerstation = gameObject.GetComponent<PowerStation>();
        
        if(Power_Follow_place_buildings.isPlacing == true && powerstation.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(PowerTile.OverMountain == true)
            {
                powerstation.TerrainMultiplier = 0.5f;
            }
            else if(PowerTile.OverSnow == true)
            {
                powerstation.TerrainMultiplier = 0.2f;
            }
            else
            {
                powerstation.TerrainMultiplier = 1f;
            } 
        
            if (powerstation.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (powerstation.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (powerstation.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (powerstation.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = powerstation.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
