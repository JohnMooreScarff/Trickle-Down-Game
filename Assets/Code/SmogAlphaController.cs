using UnityEngine;
using UnityEngine.UI;


public class SmogAlphaController : MonoBehaviour
{
    public Image smogOverlay;
    

    void Update()
    {
        float alpha = ResourceData.Pollution / 100f;
        Color color = smogOverlay.color;
        color.a = alpha;
        smogOverlay.color = color;
    }
}
