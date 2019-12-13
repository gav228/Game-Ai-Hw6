using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractablesManager : MonoBehaviour
{
    public int hour;
    public int minute;
    public int waiting;
    public static InteractablesManager instance;
    public Text timetext;
    public Text logtext;

    private void Awake()
    {
        hour = 0;
        minute = 0;
        waiting = 0;
        instance = this;
        timetext = GameObject.Find("TimeText").GetComponent<Text>();
        logtext = GameObject.Find("LogContent").GetComponent<Text>();
    }

    void Update()
    {
        if (hour == 0)
        {
            timetext.text = string.Format("12:{0:00} AM", minute);
        }
        if(hour > 0 && hour < 12)
        {
            timetext.text = string.Format("{0}:{1:00} AM", hour, minute);
        }
        if (hour == 12)
        {
            timetext.text = string.Format("12:{0:00} PM", minute);
        }
        if (hour > 12)
        {
            timetext.text = string.Format("{0}:{1:00} PM", hour-12, minute);
        }
        if (minute >= 60)
        {
            hour += 1;
            minute = 0;
        }
        if (waiting > 4)
        {
            minute += 1;
            waiting = 0;
        }
        if(hour == 24)
        {
            hour = 0;
        }
        waiting += 1;
    }

    public void AddToLog(string message)
    {

    }

    
}
