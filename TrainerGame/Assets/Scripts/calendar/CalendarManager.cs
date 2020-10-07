using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    private EventObject[] eventObjects;


    private void SortEventObjectsByDate()
    {
        eventObjects = eventObjects.OrderBy(a => a.month).ThenBy(a => a.day).ToArray();
    }

    private void PopulateCalendarDays()
    {
        for (int i = 0; i < daysOnGrid.Length; i++) //There are 42 slots in a 7 x 6 calendar grid
        {
            if (i < (currentMonth.firstDayOfTheMonth - 1) || ((1 + i - (currentMonth.firstDayOfTheMonth - 1)) > currentMonth.daysInMonth))
            {
                daysOnGrid[i].GetComponent<Day>().dayOfTheMonth = -1;
            }
            else if (i >= (currentMonth.firstDayOfTheMonth - 1) && (i - currentMonth.firstDayOfTheMonth) < currentMonth.daysInMonth)
            {
                daysOnGrid[i].GetComponent<Day>().dayOfTheMonth = (1 + i - (currentMonth.firstDayOfTheMonth - 1));
            }
            for (int j = 0; j < eventObjects.Length; j++)
            {
                if (daysOnGrid[i].GetComponent<Day>().dayOfTheMonth == eventObjects[j].day && currentMonth.monthNumber == eventObjects[j].month)
                {
                    daysOnGrid[i].GetComponent<Day>().eventImage.sprite = eventObjects[j].icon;
                }
                else
                {
                    daysOnGrid[i].GetComponent<Day>().eventImage.sprite = null;
                }
            }
            daysOnGrid[i].GetComponent<Day>().UpdateDayText();
        }
    }

    private void Awake()
    {
        TimeSystem.Instance.updateDay += TrackCalendarDay;
        currentMonth = months[0];
        currentMonthText.text = currentMonth.nameOfMonth;
        PopulateCalendarDays();
        TrackCalendarDay();
        SortEventObjectsByDate();
    }


    private void TrackCalendarDay()
    {
        if (currentMonth.monthNumber != TimeSystem.month)
        {
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i].monthNumber == TimeSystem.month)
                {
                    currentMonth = months[i];
                    currentMonthText.text = currentMonth.nameOfMonth;
                    PopulateCalendarDays();
                }
            }
        }

        for (int i = 0; i < daysOnGrid.Length; i++)
        {
            if (daysOnGrid[i].GetComponent<Day>().dayOfTheMonth == TimeSystem.dayNumber)
            {
                daysOnGrid[i].GetComponentInChildren<Image>().color = Color.blue;
            }
            else
            {
                daysOnGrid[i].GetComponentInChildren<Image>().color = Color.white;
            }
        }



    }

    private void CheckForEvent()
    {
        for (int i = 0; i < eventObjects.Length; i++)
        {
            if (eventObjects[i].day == TimeSystem.dayNumber && eventObjects[i].month == TimeSystem.month)
            {
                //Trigger Event
            }
        }
    }

}
