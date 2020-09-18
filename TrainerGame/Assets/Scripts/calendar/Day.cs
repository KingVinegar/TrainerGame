using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Day : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayText;

    [SerializeField]
    public int dayOfTheMonth;

    [SerializeField]
    private Image eventImage;

    private void Start()
    {
        
        if(dayOfTheMonth > 0)
        {
            dayText.text = dayOfTheMonth.ToString();
        }
        else
        {
            dayText.text = "";
        }


    }

}
