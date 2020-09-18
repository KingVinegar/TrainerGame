using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarManager : MonoBehaviour
{
    [SerializeField]
    private Month[] months;

    private Month currentMonth;

    [SerializeField]
    private TextMeshProUGUI currentMonthText;

    [SerializeField]
    private GameObject[] daysOnGrid;

  


    private void PopulateCalendarDays()
    {
        for (int i = 0; i < 42; i++) //There are 42 slots in a 7 x 6 calendar grid
        {
            if (1 + i - (currentMonth.firstDayOfTheMonth-1) > currentMonth.daysInMonth)
            {
                return;
            }
            if (i < (currentMonth.firstDayOfTheMonth - 1))
            {
                daysOnGrid[i].GetComponent<Day>().dayOfTheMonth = 0;
            }
            else if (i >= (currentMonth.firstDayOfTheMonth - 1))
            {
                daysOnGrid[i].GetComponent<Day>().dayOfTheMonth = (1 + i - (currentMonth.firstDayOfTheMonth-1));
            }

        }
    }

    private void Awake()
    {
        currentMonth = months[0];
        currentMonthText.text = currentMonth.nameOfMonth;
        PopulateCalendarDays();
    }

    private void Update()
    {
        for (int i = 0; i < daysOnGrid.Length; i++)
        {
            if(daysOnGrid[i].GetComponent<Day>().dayOfTheMonth == TimeSystem.dayNumber)
            {
                daysOnGrid[i].GetComponentInChildren<Image>().color = Color.blue;
            }
            else
            {
                daysOnGrid[i].GetComponentInChildren<Image>().color = Color.white;
            }
        }
    }

}
