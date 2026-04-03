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
        spriteRenderer.sortingOrder = (int)((130 - transform.position.y) * 100);
    }
}
