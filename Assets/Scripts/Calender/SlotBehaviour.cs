using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class SlotBehaviour : MonoBehaviour
{
    public Text eventName;
    public Text shortDescription;
    public Text time;

    public slotType _slotType;
    public EventObject _EventObject;

    public void OnStart(EventObject eventObject, int counter)
    {
        if(_slotType == slotType.filled)
        {
            eventName.text = eventObject.eventName;
            shortDescription.text = eventObject.eventShortDescription;            
        }

        time.text = counter.ToString("00") + ":" + 0.ToString("00");
    }
}
