using UnityEngine;
using TMPro;
using System.Collections;

public class TreeTmultiplierText : MonoBehaviour
{
    public TMP_Text Multiplier_text;
    private Color orange;
    

    void Start()
    {
        orange = new Color(1.0f, 0.64f, 0.0f);
        
    }

    void Update()
    {
        Tree tree = gameObject.GetComponent<Tree>();
        
        if(Tree_Follow_place_buildings.isPlacing == true && tree.Isplaced == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            mousePos.y += 3f;
            Multiplier_text.transform.position = mousePos;
            
            if(TreeTile.OverMountain == true)
            {
                tree.TerrainMultiplier = 0.5f;
            }
            else if(TreeTile.OverSnow == true)
            {
                tree.TerrainMultiplier = 0.2f;
            }
            else
            {
                tree.TerrainMultiplier = 1f;
            } 
        
            if (tree.TerrainMultiplier == 0.2f)
            {
                Multiplier_text.color = Color.red;
            }
            else if (tree.TerrainMultiplier == 0.5f)
            {
                Multiplier_text.color = orange;
            }
            else if (tree.TerrainMultiplier == 1f)
            {
                Multiplier_text.color = Color.white;
            }
            else if (tree.TerrainMultiplier == 2f)
            {
                Multiplier_text.color = Color.green;
            }
            Multiplier_text.text = tree.TerrainMultiplier.ToString() + " x";
        }
        else
        {
            Multiplier_text.enabled = false;
        }
    }
}
