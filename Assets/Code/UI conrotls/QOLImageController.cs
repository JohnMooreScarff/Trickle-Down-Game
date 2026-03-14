using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QOLImageController : MonoBehaviour
{
    public Image QOLImage;
    public Sprite image0to19;
    public Sprite image20to39;
    public Sprite image40to59;
    public Sprite image60to79;
    public Sprite image80to100;
    void Update()
    {
        if (ResourceData.QOL <= 19)
        {
            QOLImage.sprite = image0to19;
        }
        else if (ResourceData.QOL <= 39)
        {
            QOLImage.sprite = image20to39;
        }
        else if (ResourceData.QOL <= 59)
        {
            QOLImage.sprite = image40to59;
        }
        else if (ResourceData.QOL <= 79)
        {
            QOLImage.sprite = image60to79;
        }
        else
        {
            QOLImage.sprite = image80to100;
        }
    }
}