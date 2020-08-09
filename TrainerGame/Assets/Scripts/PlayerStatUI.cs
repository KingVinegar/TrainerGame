using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
    [Header("Stat numbers")]
    public TextMeshProUGUI powerStat;
    public TextMeshProUGUI techniqueStat;
    public TextMeshProUGUI enduranceStat;
    public TextMeshProUGUI conditioningStat;

    [Header("Stat Level Gauges")]
    public Image powerGauge;
    public Image techniqueGauge;
    public Image enduranceGauge;
    public Image conditionGauge;


    [Header("Fatigue")]
    public TextMeshProUGUI fatigueStat;
    public Sprite[] emojis;

    private Image currentEmoji;

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

        powerGauge.fillAmount = playerStats.powerLevel / 100;
        techniqueGauge.fillAmount = playerStats.techniqueLevel / 100;
        enduranceGauge.fillAmount = playerStats.enduranceLevel / 100;
        conditionGauge.fillAmount = playerStats.conditioningLevel / 100;      

    }

    public void CheckFatigueLeve()
    {
        int fatigue = playerStats.fatigue;

        fatigueStat.text = fatigue.ToString();

        currentEmoji.sprite = emojis[fatigue - 1];
    }
}

