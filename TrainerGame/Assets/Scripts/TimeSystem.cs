using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeSystem : MonoBehaviour

{
    public TextMeshProUGUI dayNumberText;
    public TextMeshProUGUI dayOfWeekText;
    public TextMeshProUGUI monthText;
    public TextMeshProUGUI yearText;

    public static double dayNumber, dayOfWeek, month, year;
    public string dayOfWeekName;



    // Start is called before the first frame update
    void Start()
    {
        dayNumber = 1;
        dayOfWeek = 1;
        month = 8;
        year = 2020;
    }


    void TextCallFunction()
    {
        dayNumberText.text = dayNumber.ToString();
        dayOfWeekText.text = dayOfWeekName;
        monthText.text = month.ToString();
        yearText.text = year.ToString();
    }

    public void CalculateDay()
    {
        dayNumber++;
        CalculateDayOfWeek();

        if(dayNumber >= 28)
        {
            CalculateMonth();
        }else if(month > 12)
        {
            month = 1;
            year++;
        }

        TextCallFunction();
    }

    void CalculateMonth()
    {
        if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if(dayNumber >= 32)
            {
                month++;
                dayNumber = 1;
                TextCallFunction();
            }
        }

        if(month == 4 || month == 6 || month == 9 || month == 11)
        {
            if(dayNumber >= 31)
            {
                month++;
                dayNumber = 1;
                TextCallFunction();
            }
        }

        if(month == 2)
        {
            month++;
            dayNumber = 1;
            TextCallFunction();
        }
    }

    void CalculateDayOfWeek()
    {
        dayOfWeek++;
        if(dayOfWeek > 7)
        {
            dayOfWeek = 1;
        }

        switch (dayOfWeek)
        {
            case 1:
                dayOfWeekName = "Sunday";
                break;
            case 2:
                dayOfWeekName = "Monday";
                break;
            case 3:
                dayOfWeekName = "Tuesday";
                break;
            case 4:
                dayOfWeekName = "Wednesday";
                break;
            case 5:
                dayOfWeekName = "Thursday";
                break;
            case 6:
                dayOfWeekName = "Friday";
                break;
            case 7:
                dayOfWeekName = "Saturday";
                break;
        }
    }
}
