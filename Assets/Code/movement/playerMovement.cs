using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    // W,A,S,D movement
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float speedX;
    private float speedY;

    // zoom
    private Camera camera;
    private float zoomTarget;

    public float multiplier = 2f, minzoom = 1f, maxzoom = 10f, smoothTime = .1f;
    public float velocity = 0f;
   

    void Start()
    {
        // W,A,S,D movement
        rb = GetComponent<Rigidbody2D>();
        //zoom
        camera = GetComponent<Camera>();
        zoomTarget = camera.orthographicSize;
    }

    void Update()
    {
        // W,A,S,D movement
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");  
        // zoom
        zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minzoom, maxzoom);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoomTarget, ref velocity, smoothTime);
    }

    void FixedUpdate()
    {
        // W,A,S,D movement

        rb.linearVelocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);
    }
}