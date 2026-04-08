using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class WoodTile : MonoBehaviour
{
    public static bool Overwater;
    public static bool OverMountain;
    private Tilemap tilemap;
    void Start()
    {
        if (tilemap == null)
        {
            tilemap = Object.FindFirstObjectByType<Tilemap>();
        }
    }

    void Update()
    {
        if(Wood_Follow_place_buildings.isPlacing == true)
        {
        Vector3 worldPosition = transform.position;
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);   
        Debug.Log("Tile found: " + tile.name);
        if(tile.name == "Sea" || tile.name == "Deepsea")
        {
            Overwater = true;
        }
        else
        {
            Overwater = false;
        }
        if(tile.name == "Mountainlow" || tile.name == "Mountain" || tile.name == "Mountainhigh")
            {
                OverMountain = true;
            }
            else
            {
                OverMountain = false;
            }
        }
    }
}
