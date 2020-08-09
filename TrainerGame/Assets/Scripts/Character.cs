using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{

    public string CharacterName = "Linguini Spaghetti";

    public int startingPower = 1;
    public int startingTechnique = 1;
    public int startingEndurance = 1;
    public int startingConditioning = 1;

    public TextMeshProUGUI characterNameText;
   

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI techniqueText;
    public TextMeshProUGUI enduranceText;
    public TextMeshProUGUI conditioningText;

    void Awake()
    {
        characterNameText.text = CharacterName;

        powerText.text = startingPower.ToString();
        techniqueText.text = startingTechnique.ToString();
        enduranceText.text = startingEndurance.ToString();
        conditioningText.text = startingConditioning.ToString();
    }


    public void SelectCharacter()
    {

        PlayerStats.Instance.power = startingPower;
        PlayerStats.Instance.technique = startingTechnique;
        PlayerStats.Instance.endurance = startingEndurance;
        PlayerStats.Instance.conditioning = startingConditioning;



    }

}
