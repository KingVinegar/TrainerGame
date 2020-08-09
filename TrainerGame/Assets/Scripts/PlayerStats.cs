using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Instance { get; private set; }

    [Header ("Player Stats")]
    public int power = 1;
    public float powerLevel = 0;
    public int technique = 1;
    public float techniqueLevel = 0;
    public int endurance = 1;
    public float enduranceLevel = 0;
    public int conditioning = 1;
    public float conditioningLevel = 0;


    [Header("Player Conditions")]
    public int fatigue = 0;

    public int mood = 1;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void CheckLevel(int stat, float level)
    {
        if(level >= 100)
        {
            stat = stat + 1;
            level = 0;
        }


    }

}
