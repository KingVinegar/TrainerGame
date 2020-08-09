using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header ("Player Stats")]
    public int power = 1;
    public int powerLevel = 0;
    public int technique = 1;
    public int techniqueLevel = 0;
    public int endurance = 1;
    public int enduranceLevel = 0;
    public int conditioning = 1;
    public int conditioningLevel = 0;

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

    public void AddToStat(int stat, int amount)
    {
        stat += amount;
        playerStatUI.RefreshStatBlock();
    }



}
