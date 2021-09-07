using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    public List<GameObject> dayColumns = new List<GameObject>();
    public List<GameObject> dayColumns2 = new List<GameObject>();
    public GameObject dayColumn;
    public GameObject day;

    public GameObject[] slots;

    public GameObject dayColumnHolder;
    public GameObject dayColumnHolder2;

    public List<List<EventObject>> eventObjects = new List<List<EventObject>>();

    public GameObject eventViewModal;

    public GameObject _Canvas;

    public Button Template;

    public void OnStart()
    {
        for (int i = 0; i < dayColumns2.Count; i++)
        {
            Destroy(dayColumns2[i]);
        }
        for (int i = 0; i < dayColumns.Count; i++)
        {
            Destroy(dayColumns[i]);
        }

        dayColumns.Clear();
        dayColumns2.Clear();

        for (int i = 0; i < 30; i++)
        {
            //
            Vector3 offset = new Vector3(400, 0, 0);
            offset *= i;

            Vector3 posStorage = dayColumn.transform.position + offset;

            dayColumns.Add(Instantiate(dayColumn, dayColumn.transform.localPosition, Quaternion.identity));
            dayColumns[i].transform.SetParent(dayColumnHolder.transform);

            dayColumns[i].transform.localPosition = posStorage;

            GameObject x = Instantiate(day, dayColumns[i].transform);

            x.GetComponent<DayBehaviour>().OnStart(i);   
        }
        for (int i = 0; i < 30; i++)
        {
            //
            Vector3 offset = new Vector3(400, 0, 0);
            offset *= i;

            Vector3 posStorage = dayColumn.transform.position + offset;

            dayColumns2.Add(Instantiate(dayColumn, dayColumn.transform.localPosition, Quaternion.identity));
            dayColumns2[i].transform.SetParent(dayColumnHolder2.transform);

            dayColumns2[i].transform.localPosition = posStorage;

            for (int si = 0; si < 24; si++)
            {

                int r = 0;
                //Checks to see if an event is scheduled at that time
                if (i <= eventObjects.Count - 1)
                    if (si < eventObjects[i].Count - 1)
                        if (eventObjects[i][si].scheduledTime.Hour == si)
                        {
                            r = 1;
                        }

                GameObject x = Instantiate(slots[r], dayColumns2[i].transform);

                x.transform.localPosition -= new Vector3(0, 250 * (si + 1), 0);

                if (r == 1)
                    x.GetComponent<SlotBehaviour>().OnStart(eventObjects[i][si], si);

                if (r == 0)
                    x.GetComponent<SlotBehaviour>().OnStart(null, si);

                if (r == 1)
                    x.GetComponent<Button>().onClick = Template.onClick;
            }
        }
    }
    public void ClickedSlot(SlotBehaviour slotBehaviour)
    {
        GameObject x = Instantiate(eventViewModal, eventViewModal.transform.position, Quaternion.identity);
        x.transform.SetParent(_Canvas.transform);

        x.GetComponent<CalendarModalViewBehaviour>().OnStart(slotBehaviour._EventObject);        
    }
}
