using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Event : Singleton<Event>
{
    public TMP_Text textComponent;

    public EventText[] eventText;
    EventText currentEvent;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        NewText();
    }

    // Update is called once per frame
    public void GetNewEvent()
    {
        index = Random.Range(1, eventText.Length);
        NewText();
    }

    public void NewText()
    {
        currentEvent = eventText[index];
        GetText();
    }

    public void GetText()
    {
        textComponent.text = currentEvent.GetEventText();
    }
}
