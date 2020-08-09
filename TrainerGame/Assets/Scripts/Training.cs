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
        playerStats.powerLevel += changePowerBy;
        playerStats.techniqueLevel += changeTechniqueBy;
        playerStats.enduranceLevel += changeEnduranceBy;
        playerStats.conditioningLevel += changeConditioningBy;
    }

}
