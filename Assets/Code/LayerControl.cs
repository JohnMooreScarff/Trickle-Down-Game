using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LayerControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        spriteRenderer.sortingOrder = (int)((120 - transform.position.y) * 100);
    }
}
