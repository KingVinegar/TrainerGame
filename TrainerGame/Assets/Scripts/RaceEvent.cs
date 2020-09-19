using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEvent : MonoBehaviour
{
    private PlayerStats playerStats;

    public float timeRan;
    public float eventMaxTime;
    public float eventMinTime;

    private EventUI eventUI;

    public delegate void UpdateEventUI();
    public UpdateEventUI updateEventUI;

    void Awake()
    {
        playerStats = PlayerStats.Instance;
        eventUI = FindObjectOfType<EventUI>();
    
    }

    public void RunEvent()
    {
        float statsFactor = (((1.0f / playerStats.power) + (1.0f / playerStats.technique)) / 2.0f) + 1.0f;
        float fatigueFactor = 1.0f + (playerStats.fatigue / 100.0f);
        timeRan = eventMinTime * statsFactor * fatigueFactor;

        Debug.Log("Stats Factor equals " + statsFactor);
        Debug.Log("Fatigue Factor equals " + fatigueFactor);
        Debug.Log("Time ran = " + timeRan);

        updateEventUI.Invoke();

    }
}
