using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatUI : MonoBehaviour
{
    public TextMeshProUGUI powerStat;
    public TextMeshProUGUI techniqueStat;
    public TextMeshProUGUI enduranceStat;
    public TextMeshProUGUI conditioningStat;

    private PlayerStats playerStats;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        RefreshStatBlock();
    }

    public void RefreshStatBlock()
    {
        powerStat.text = playerStats.power.ToString();
        techniqueStat.text = playerStats.technique.ToString();
        enduranceStat.text = playerStats.endurance.ToString();
        conditioningStat.text = playerStats.conditioning.ToString();
    }
}

