using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;
using TMPro;

public class woodfactory : MonoBehaviour
{
    public int wood;
    public float timer = 0f;
    public TMP_Text wood_amount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0f;
        }


    }
}
