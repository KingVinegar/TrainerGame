using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingScreenMessageHandler : MonoBehaviour
{
    private bool calendarOpen;

    void OpenCalendar()
    {
        calendarOpen = true;
    }

    void CloseCalendar()
    {
        calendarOpen = false;
    }
}
