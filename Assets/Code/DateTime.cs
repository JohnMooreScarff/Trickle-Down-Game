using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;
using TMPro;

public class DateTime : MonoBehaviour
{

    public int Day;
    public int Month;
    public int Year;
    private int MonthDayAmmont;
    private float timer = 0f;
    public TMP_Text day;
    public TMP_Text month;
    public TMP_Text year;

    
    void Start()
    {
        Day = 1;
        Month = 1;
        Year = 0;
        MonthDayAmmont = 30;
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f) 
        {
            timer = 0f;
            Dayloop();
            //Debug.Log(GetDateString());
        }
         day.text = $"Day {Day}".ToString();
         month.text = $"Month {Month}".ToString();
         year.text = $"Year {Year}".ToString();

    }

    void DateCount()
    {
        
        if (Day >= MonthDayAmmont)
        {
            Day = 1;
            Month++;
            if (Month >= 12)
            {
                Year++;
                Month = 1;
            }
        }
       
    }
    void Dayloop()
    { 
        Day++; 
        DateCount();
    }

    public string GetDateString()
    {
        return $"Year {Year}, Month {Month}, Day {Day}";
       
    }
}
