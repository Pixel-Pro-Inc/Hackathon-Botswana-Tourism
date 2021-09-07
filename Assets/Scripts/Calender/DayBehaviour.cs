using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class DayBehaviour : MonoBehaviour
{
    public Text dateNumber;
    public Text date;
    public void OnStart(int counter)
    {

        dateNumber.text = System.DateTime.Now.AddDays(counter).Day.ToString();

        Months[] months = (Months[])(Months.GetValues(typeof(Months)));

        date.text = System.DateTime.Now.AddDays(counter).DayOfWeek.ToString() + ", " + months[System.DateTime.Now.AddDays(counter).Month - 1].ToString();
    }
}
