using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    // Start is called before the first frame update
    
        public TextMeshProUGUI playerTimeText;

    private RaceEvent eventTimes;

    void Awake()
    { 
        eventTimes = FindObjectOfType<RaceEvent>();
        eventTimes.updateEventUI += UpdateEventUI;
    }

    public void UpdateEventUI()
    {
        playerTimeText.text = eventTimes.timeRan.ToString("0.000");
    }
}

