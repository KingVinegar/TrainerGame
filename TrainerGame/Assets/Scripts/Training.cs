using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public string trainingModality = "Training Modality";

    public int changePowerBy = 0;
    public int changeTechniqueBy = 0;
    public int changeEnduranceBy = 0;
    public int changeConditioningBy = 0;

    private PlayerStats playerStats;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Train()
    {
        playerStats.AddToStat(playerStats.power, changePowerBy, playerStats.powerStat);
        playerStats.AddToStat(playerStats.technique, changeTechniqueBy, playerStats.techniqueStat);
        playerStats.AddToStat(playerStats.endurance, changeEnduranceBy, playerStats.enduranceStat);
        playerStats.AddToStat(playerStats.conditioning, changeConditioningBy, playerStats.conditioningStat);

    }

}
