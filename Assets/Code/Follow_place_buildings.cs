using UnityEngine;

public class Follow_place_buildings : MonoBehaviour
{
    bool BuildingSelected;

    void Start()
    {
        BuildingSelected = true;

    }

    void Update()
    {
        if (BuildingSelected == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            transform.position = worldPos;
        }
    }
    public void Placed()
    {
        if (BuildingSelected == true)
        {
            BuildingSelected = false;
            Debug.Log("Clicked");
        }
    }
}
