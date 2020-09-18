using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Month", menuName = "Month")]
public class Month : ScriptableObject
{
    public int firstDayOfTheMonth = 1;

    public int monthNumber = 1;

    public string nameOfMonth = "January";

    public int daysInMonth = 31;
}
