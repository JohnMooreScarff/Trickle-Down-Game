using UnityEngine;

public class infohovercontroller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.size = new Vector2(240, 150);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
