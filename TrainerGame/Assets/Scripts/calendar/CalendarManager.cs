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

    //Next Meet info
    private EventObject nextRace;
    [SerializeField]
    private TextMeshProUGUI NextMeetText;

    private void SortEventObjectsByDate()
    {
        eventObjects = eventObjects.OrderBy(a => a.month).ThenBy(a => a.day).ToArray();
    }

    private void SortMonths()
    {
        months = months.OrderBy(a => a.monthNumber).ToArray();
    }

    private void PopulateCalendarDays()
    {
        ClearCalendarDays();
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
                    Debug.Log("new event called");
                }

            }
            daysOnGrid[i].GetComponent<Day>().UpdateDayText();
        }
        NextEvent();
    }

    private void ClearCalendarDays()
    {
        for (int i = 0;  i < daysOnGrid.Length ; i++)
        {
            daysOnGrid[i].GetComponent<Day>().eventImage.sprite = null;
        }
    }

    private void Start()
    {
        GetComponent<Canvas>().enabled = false;
        TimeSystem.Instance.updateDay += TrackCalendarDay;
        currentMonth = months[0];
        currentMonthText.text = currentMonth.nameOfMonth;
        SortEventObjectsByDate();
        SortMonths();
        PopulateCalendarDays();
        TrackCalendarDay();
        
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
        CheckForEvent();
        NextEvent();

    }

    private void CheckForEvent()
    {
        for (int i = 0; i < eventObjects.Length; i++)
        {
            if (eventObjects[i].day == TimeSystem.dayNumber && eventObjects[i].month == TimeSystem.month)
            {
                //Trigger Event
                eventObjects[i].hasHappened = true;
            }
        }
    }

    private void NextEvent()
    {
        for (int i = 0; i < eventObjects.Length; i++)
        {
            if(eventObjects[i].GetType() == typeof(RaceMeet) && eventObjects[i].month >= currentMonth.monthNumber)
            {
                if (eventObjects[i].hasHappened == false)
                {
                    nextRace = eventObjects[i];
                    Debug.Log("Next race is at " + eventObjects[i].month + "-" + eventObjects[i].day);
                    NextMeetText.text = eventObjects[i].title + " " + eventObjects[i].month.ToString() + "-" + eventObjects[i].day.ToString();
                    return;
                }
            }
        }
    }

    public void ToggleCanvas()
    {
        if (GetComponent<Canvas>().enabled)
        {
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GetComponent<Canvas>().enabled = true;
        }
    }

}
