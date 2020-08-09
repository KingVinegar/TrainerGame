using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private PlayerStats playerStats;

    private float timeRan;
    public float eventMaxTime;
    public float eventMinTime;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    
    }

    public void RunEvent()
    {
        float statsFactor = (((1.0f / playerStats.power) + (1.0f / playerStats.technique)) / 2.0f) + 1.0f;
        float fatigueFactor = 1.0f + (playerStats.fatigue / 100.0f);
        timeRan = eventMinTime * statsFactor * fatigueFactor;

        Debug.Log("Stats Factor equals " + statsFactor);
        Debug.Log("Fatigue Factor equals " + fatigueFactor);
        Debug.Log("Time ran = " + timeRan);

    }
}
