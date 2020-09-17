using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeEventManager : MonoBehaviour
{
    public EventObject eventObject;


    public GameObject eventExample;
    public Image eventImage;

    // Update is called once per frame
    void Update()
    {
        if(eventObject.day == TimeSystem.dayNumber && eventObject.month == TimeSystem.month)
        {
            eventExample.SetActive(true);
            eventImage.sprite = eventObject.icon;
        }
    }
}
