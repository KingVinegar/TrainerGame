using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
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

    private PlayerStatUI playerStatUI;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerStatUI = FindObjectOfType<PlayerStatUI>();        
    }

    public void AddToStat(int stat, int amount, float level)
    {
        Debug.Log(stat + " changed by " + amount);
        level += amount;
        CheckLevel(stat, level);
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
