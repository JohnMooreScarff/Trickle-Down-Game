
using UnityEngine;
using UnityEngine.UI;

public class MoneyImageController : MonoBehaviour
{
    public Image Yellow;
    public Image Red;

    public float money;


    public float flashInterval = 0.5f;
    private float flashTimer = 0f;
    private bool isImageVisible = true;

    void Start()
    {
        Yellow.gameObject.SetActive(false);
        Red.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ResourceData.Money < -90000)
        {
            Yellow.gameObject.SetActive(false);
            Red.gameObject.SetActive(true);
            FlashImage();
        }
        else if (ResourceData.Money < -75000)
        {
            Red.gameObject.SetActive(false);
            Yellow.gameObject.SetActive(true);
        }
        else
        {
            Yellow.gameObject.SetActive(false);
            Red.gameObject.SetActive(false);
        }
    }

    void FlashImage()
    {
        flashTimer += Time.deltaTime;
        if (flashTimer >= flashInterval)
        {
            flashTimer = 0f;
            isImageVisible = !isImageVisible;
            Red.enabled = isImageVisible;
        }
    }
}
