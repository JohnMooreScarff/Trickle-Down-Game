using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
public class WaterDissable : MonoBehaviour
{
    public bool Flooded;
    SpriteRenderer spriteRenderer;
    private Tilemap tilemap;
    Animator animator;
    public GameObject PlaceParticals;
    
    void Start()
    {
        if (tilemap == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            tilemap = Object.FindFirstObjectByType<Tilemap>();
            animator = gameObject.GetComponent<Animator>();
            StartCoroutine(timer());
        }
    }
    IEnumerator timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f,2f));
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
            TileBase tile = tilemap.GetTile(cellPosition);
            if(tile.name == "Sea" || tile.name == "Deepsea")
            {
                Flooded = true;
                spriteRenderer.color = Color.blue;
                animator.enabled = false;  
                PlaceParticals.gameObject.SetActive(false);              
            }
            else
            {
                Flooded = false;
                spriteRenderer.color = Color.white;
                animator.enabled = true;  
                PlaceParticals.gameObject.SetActive(true);

            }
        }
    }
    
}
