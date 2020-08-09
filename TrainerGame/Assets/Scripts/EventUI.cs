using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    // Start is called before the first frame update
    
        public TextMeshProUGUI playerTimeText;

    private Event eventTimes;

    void Awake()
    { 
        eventTimes = FindObjectOfType<Event>();
    }

    public void UpdateEventUI()
    {
        playerTimeText.text = eventTimes.timeRan.ToString();
    }
}

