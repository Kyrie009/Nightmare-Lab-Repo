using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventText : ScriptableObject
{
    [TextArea(8, 10)] public string eventText;
    public EventText[] NextText;

    public string GetEventText()
    {
        return eventText;
    }
}
