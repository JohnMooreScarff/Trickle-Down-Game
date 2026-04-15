using UnityEngine;
using TMPro;
using System.Collections;

public class CoalTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        CoalMine coalmine = gameObject.GetComponent<CoalMine>();
        
        if(Coal_Follow_place_buildings.isPlacing == true && coalmine.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(CoalTile.OverMountain == true)
            {
                coalmine.TerrainMultiplier = 0.5f;
            }
            else if(CoalTile.OverSnow == true)
            {
                coalmine.TerrainMultiplier = 0.2f;
            }
            else if(CoalMine.OverCoal == true)
            {
                coalmine.TerrainMultiplier = 2f;
            }
            else
            {
                coalmine.TerrainMultiplier = 1f;
            } 
        
            if (coalmine.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (coalmine.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (coalmine.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (coalmine.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = coalmine.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
