using UnityEngine;
using TMPro;
using System.Collections;

public class IronTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        IornMine ironmine = gameObject.GetComponent<IornMine>();
        
        if(Iron_Follow_place_buildings.isPlacing == true && ironmine.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(IronTile.OverMountain == true)
            {
                ironmine.TerrainMultiplier = 0.5f;
            }
            else if(IronTile.OverSnow == true)
            {
                ironmine.TerrainMultiplier = 0.2f;
            }
            else if(IornMine.OverIron == true)
            {
                ironmine.TerrainMultiplier = 2f;
            }
            else if(IronTile.OverMountain == true && IornMine.OverIron == true)
            {
                ironmine.TerrainMultiplier = 1f;
            }
            else if(IronTile.OverSnow == true && IornMine.OverIron == true)
            {
                ironmine.TerrainMultiplier = 0.5f;
            }
            else
            {
                ironmine.TerrainMultiplier = 1f;
            } 
        
            if (ironmine.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (ironmine.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (ironmine.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (ironmine.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = ironmine.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
