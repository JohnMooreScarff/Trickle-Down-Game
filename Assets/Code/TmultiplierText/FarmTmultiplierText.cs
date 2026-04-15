using UnityEngine;
using TMPro;
using System.Collections;

public class FarmTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        Farm farm = gameObject.GetComponent<Farm>();
        
        if(Farm_Follow_place_buildings.isPlacing == true && farm.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(FarmTile.OverMountain == true)
            {
                farm.TerrainMultiplier = 0.5f;
            }
            else if(FarmTile.OverSnow == true)
            {
                farm.TerrainMultiplier = 0.2f;
            }
            else if(FarmTile.OverFarmland == true)
            {
                farm.TerrainMultiplier = 2f;
            }
            else
            {
                farm.TerrainMultiplier = 1f;
            } 
        
            if (farm.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (farm.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (farm.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (farm.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = farm.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
