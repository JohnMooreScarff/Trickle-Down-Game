using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public TilemapRenderer targetTilemap;

    void Update()
    {
        Bounds TilemapBounds = targetTilemap.bounds;

        float camHalfHeight = mainCamera.orthographicSize /4f;
        float camHalfWidth = camHalfHeight * mainCamera.aspect / 4f;


        float minX = TilemapBounds.min.x + camHalfHeight;
        float maxX = TilemapBounds.max.x - camHalfHeight;
        float minY = TilemapBounds.min.y + camHalfWidth;
        float maxY = TilemapBounds.max.y - camHalfWidth;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}