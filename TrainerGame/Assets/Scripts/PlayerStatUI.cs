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

    public Image currentEmoji;

    private PlayerStats playerStats;

    void Awake()
    {
        playerStats = PlayerStats.Instance;

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

        CheckFatigueLeve();

    }

    public void CheckFatigueLeve()
    {
        int fatigue = playerStats.fatigue;

        if(fatigue <= 0)
        {
            fatigue = 0;
        }
        if(fatigue >= 10)
        {
            fatigue = 10;
        }

        fatigueStat.text = fatigue.ToString();

        currentEmoji.sprite = emojis[fatigue];
    }
}

