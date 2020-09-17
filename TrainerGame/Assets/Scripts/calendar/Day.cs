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
    private int dayOfTheMonth;

    [SerializeField]
    private Image eventImage;

    private void Start()
    {
        dayText.text = dayOfTheMonth.ToString();


    }

}
