using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Training : MonoBehaviour
{
    public string trainingModality = "Training Modality";

    public float changePowerBy = 0;
    public float changeTechniqueBy = 0;
    public float changeEnduranceBy = 0;
    public float changeConditioningBy = 0;

    public int changeFatigueBy = 0;

    private PlayerStats playerStats;
    private PlayerStatUI playerStatUI;

    public bool trainingComplete = false;

    [SerializeField]
    private PlayableDirector playableDirector;

    [SerializeField]
    private PlayableAsset trainingTimeline;

    void Awake()
    {
        playerStats = PlayerStats.Instance;
        playerStatUI = FindObjectOfType<PlayerStatUI>();
    }

    public void Train()
    {
        if(trainingComplete == false)
        {
            playerStats.powerLevel += changePowerBy;
            if(playerStats.powerLevel >= 100)
            {
                playerStats.power += 1;
                playerStats.powerLevel = 0;
            }
            playerStats.techniqueLevel += changeTechniqueBy;
            if (playerStats.techniqueLevel >= 100)
            {
                playerStats.technique += 1;
                playerStats.techniqueLevel = 0;
            }

            playerStats.enduranceLevel += changeEnduranceBy;
            if (playerStats.enduranceLevel >= 100)
            {
                playerStats.endurance += 1;
                playerStats.enduranceLevel = 0;
            }

            playerStats.conditioningLevel += changeConditioningBy;
            if (playerStats.conditioningLevel >= 100)
            {
                playerStats.conditioning += 1;
                playerStats.conditioningLevel = 0;
            }

            playerStats.fatigue += changeFatigueBy;

            playerStatUI.RefreshStatBlock();

            //trainingComplete = true;
            playableDirector.playableAsset = trainingTimeline;
            playableDirector.Play();
            //TODO open dialogue box that prompts player to move onto the next day
        }
        else
        {
            Debug.Log("Training already complete for today.");
        }



    }

}
