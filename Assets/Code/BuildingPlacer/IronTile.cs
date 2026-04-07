using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class IronTile : MonoBehaviour
{
    public static bool Overwater;
    private Tilemap tilemapO;
    private Tilemap tilemapU;

    void Start()
    {
        if (tilemapO == null)
        {
            Tilemap[] allObjects = FindObjectsOfType<Tilemap>();
            tilemapO = allObjects[0];
            tilemapU = allObjects[1];
        }
    }

    void Update()
    {
        if(Iron_Follow_place_buildings.isPlacing == true)
        {
        Vector3 worldPosition = transform.position;
        Vector3Int cellPosition = tilemapO.WorldToCell(worldPosition);
        TileBase tilem1 = tilemapO.GetTile(cellPosition);   
        Debug.Log("Tile found: " + tilem1.name);
        if(tilem1.name == "Sea" || tilem1.name == "Deepsea")
        {
            Overwater = true;
        }
        else
        {
            Overwater = false;
        }
        TileBase tilem2 = tilemapU.GetTile(cellPosition);
        Debug.Log("Tile found: " + tilem2.name);
        if(tilem2.name == "Iron")
            {
                IornMine.OverIron = true;
            }
            else
            {
                IornMine.OverIron = false;
            }
        tilemapU.DOFade(1f,1f);
        tilemapU.color = Color.red;
        }
    }
}
