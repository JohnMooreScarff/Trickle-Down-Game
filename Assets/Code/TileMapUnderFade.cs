using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using DG.Tweening;

public class TileMapUnderFade : MonoBehaviour
{
    private Tilemap tilemapU;
    private Tween fadeTween;
    void Start()
    {
        if (tilemapU == null)
        {
            Tilemap[] allObjects = FindObjectsOfType<Tilemap>();
            tilemapU = allObjects[1];
        }
    }
    
    void Update()
    {

            Color color = tilemapU.color;
            if (fadeTween == null || !fadeTween.IsActive() || !fadeTween.IsPlaying())
            {
                if (fadeTween != null && fadeTween.IsActive())
                {
                    fadeTween.Kill();
                }
                if (Iron_Follow_place_buildings.isPlacing == true || Coal_Follow_place_buildings.isPlacing == true)
                {
                    fadeTween = DOTween.To(() => color.a, x => { color.a = x; tilemapU.color = color; }, 0.3f, 1f);
                }
                else
                {
                    fadeTween = DOTween.To(() => color.a, x => { color.a = x; tilemapU.color = color; }, 0f, 0.5f);
                }
            }
    }
}
