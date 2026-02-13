using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public SpriteRenderer targetSprite;

    void LateUpdate()
    {
        Bounds spriteBounds = targetSprite.bounds;

        float camHalfHeight = mainCamera.orthographicSize /4f;
        float camHalfWidth = camHalfHeight * mainCamera.aspect / 4f;


        float minX = spriteBounds.min.x + camHalfHeight;
        float maxX = spriteBounds.max.x - camHalfHeight;
        float minY = spriteBounds.min.y + camHalfWidth;
        float maxY = spriteBounds.max.y - camHalfWidth;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}