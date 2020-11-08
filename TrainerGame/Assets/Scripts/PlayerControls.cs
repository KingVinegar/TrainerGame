using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    GameObject Calendar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Calendar.GetComponent<Canvas>().enabled)
            {
                Calendar.GetComponent<Canvas>().enabled = false;
            }
            else
            {
                Calendar.GetComponent<Canvas>().enabled = true;

            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TimeSystem.Instance.CalculateDay();
        }
    }
}
