using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventObject : ScriptableObject
{

    public string title;
    public Sprite icon;
    public int month;
    public int day;

}
