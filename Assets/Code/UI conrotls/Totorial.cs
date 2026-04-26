using UnityEngine;
using UnityEngine.Tilemaps;

public class Totorial : MonoBehaviour
{
    public GameObject uiPanel;
    public Tilemap tilemap;
    public Camera mainCamera;

    public Color targetColortilemap = new Color(110f / 255f, 110f / 255f, 110f / 255f);
    public Color targetColorbackground = new Color(19f / 255f, 26f / 255f, 67f / 255f);

    private Color originalTilemapColor;
    private Color originalCameraBackgroundColor;
    private bool isToggled = false;

    void Start()
    {
  
            originalTilemapColor = tilemap.color;
            originalCameraBackgroundColor = mainCamera.backgroundColor;
            uiPanel.SetActive(false);
    }

    public void Toggle()
    {
            isToggled = !isToggled;

            uiPanel.SetActive(isToggled);

            tilemap.color = isToggled ? targetColortilemap : originalTilemapColor;

            mainCamera.backgroundColor = isToggled ? targetColorbackground : originalCameraBackgroundColor;
    }
}