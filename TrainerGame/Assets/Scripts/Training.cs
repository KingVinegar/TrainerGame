using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public string trainingModality = "Training Modality";

    public float changePowerBy = 0;
    public float changeTechniqueBy = 0;
    public float changeEnduranceBy = 0;
    public float changeConditioningBy = 0;

    private PlayerStats playerStats;
    private PlayerStatUI playerStatUI;

    public bool trainingComplete = false;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerStatUI = FindObjectOfType<PlayerStatUI>();
    }

    public void Train()
    {
        if(trainingComplete == false)
        {
            playerStats.powerLevel += changePowerBy;
            playerStats.CheckLevel(playerStats.power, playerStats.powerLevel);
            playerStats.techniqueLevel += changeTechniqueBy;
            playerStats.CheckLevel(playerStats.technique, playerStats.techniqueLevel);

            playerStats.enduranceLevel += changeEnduranceBy;
            playerStats.CheckLevel(playerStats.endurance, playerStats.enduranceLevel);

            playerStats.conditioningLevel += changeConditioningBy;
            playerStats.CheckLevel(playerStats.conditioning, playerStats.conditioningLevel);

            playerStatUI.RefreshStatBlock();

            //trainingComplete = true;
            //TODO run training animation
            //TODO open dialogue box that prompts player to move onto the next day
        }
        else
        {
            Debug.Log("Training already complete for today.");
        }



    }

}
