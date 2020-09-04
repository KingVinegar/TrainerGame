using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingScreenParameterProvider : MonoBehaviour
{
    private static readonly int calendarOpenId = Animator.StringToHash("CalendarOpen");

    [SerializeField] private Animator animator;

    private bool calendarOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(calendarOpen == false)
            {
                calendarOpen = true;
            }else if(calendarOpen == true)
            {
                calendarOpen = false;
            }
        }

        animator.SetBool(calendarOpenId, calendarOpen);
    }

    void OpenCalendar()
    {
        calendarOpen = true;
    }

    void CloseCalendar()
    {
        calendarOpen = false;
    }
}
