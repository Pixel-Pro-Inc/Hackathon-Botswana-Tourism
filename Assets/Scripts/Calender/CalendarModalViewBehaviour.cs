using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarModalViewBehaviour : MonoBehaviour
{
    public Text eventName;
    public Text londDescription;
    public Text Time;    
    public void OnStart(EventObject e)
    {
        eventName.text = e.eventName;
        londDescription.text = e.eventLongDescriiption;
        Time.text = e.scheduledTime.ToString();
    }
}
