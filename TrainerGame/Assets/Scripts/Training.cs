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

    public bool trainingComplete = false;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Train()
    {
        if(trainingComplete == false)
        {
            playerStats.AddToStat(playerStats.power, changePowerBy, playerStats.powerLevel);
            playerStats.AddToStat(playerStats.technique, changeTechniqueBy, playerStats.techniqueLevel);
            playerStats.AddToStat(playerStats.endurance, changeEnduranceBy, playerStats.enduranceLevel);
            playerStats.AddToStat(playerStats.conditioning, changeConditioningBy, playerStats.conditioningLevel);
            trainingComplete = true;
            //TODO run training animation
            //TODO open dialogue box that prompts player to move onto the next day
        }
        else
        {
            Debug.Log("Training already complete for today.");
        }



    }

}
