using UnityEngine;
using TMPro;
using System.Collections;

public class CarbonCaptureTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        CarbonCapture carboncapture = gameObject.GetComponent<CarbonCapture>();
        
        if(Carbon_capture_Follow_place_buildings.isPlacing == true && carboncapture.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(CarbonCaptureTile.OverMountain == true)
            {
                carboncapture.TerrainMultiplier = 0.5f;
            }
            else if(CarbonCaptureTile.OverSnow == true)
            {
                carboncapture.TerrainMultiplier = 0.2f;
            }
            else
            {
                carboncapture.TerrainMultiplier = 1f;
            } 
        
            if (carboncapture.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (carboncapture.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (carboncapture.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (carboncapture.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = carboncapture.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
