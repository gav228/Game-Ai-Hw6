using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InteractablesManager : MonoBehaviour
{
    public int hour;
    public int minute;
    public int waiting;
    public static InteractablesManager instance;
    public Text timetext;
    public Text logtext;
    public bool started;
    public int foodBowl;
    public bool work;
    public bool walk;
    public bool leave;
    public bool sleeping;
    public bool playing;
    public bool sound;
    public int treats;
    public bool petting;

    private void Awake() {
        treats = 0;
        sound = false; 
        playing = false;
        started = false;
        work = false;
        walk = false;
        hour = 7;
        minute = 0;
        waiting = 0;
        instance = this;
        timetext = GameObject.Find("TimeText").GetComponent<Text>();
        logtext = GameObject.Find("LogContent").GetComponent<Text>();
        petting = false;
    }

    void Update()
    {
        if (started == true)
        {
            if (waiting > 4)
            {
                minute += 1;
                waiting = 0;
                sound = false;
            }
            if (minute >= 60)
            {
                hour += 1;
                minute = 0;
            }
            if (hour == 0)
            {
                timetext.text = string.Format("12:{0:00} AM", minute);
            }
            if (hour > 0 && hour < 12)
            {
                timetext.text = string.Format("{0}:{1:00} AM", hour, minute);
            }
            if (hour == 12)
            {
                timetext.text = string.Format("12:{0:00} PM", minute);
            }
            if (hour > 12)
            {
                timetext.text = string.Format("{0}:{1:00} PM", hour - 12, minute);
            }
            
            if (hour == 24)
            {
                hour = 0;
            }
            waiting += 1;
        } else
        {
            if (Input.GetKeyDown("space"))
            {
                started = true;
            }
        }
    }

    public void AddToLog(string message)
    {
        string[] lines = logtext.text.Split('\n').Skip(1).ToArray();
        logtext.text = string.Join("\n", lines);
        

        if (hour == 0)
        {
            logtext.text += string.Format("12:{0:00} AM", minute) + " - " + message;
        }
        if (hour > 0 && hour < 12)
        {
            logtext.text += string.Format("{0}:{1:00} AM", hour, minute) + " - " + message;
        }
        if (hour == 12)
        {
            logtext.text += string.Format("12:{0:00} PM", minute) + " - " + message;
        }
        if (hour > 12)
        {
            logtext.text += string.Format("{0}:{1:00} PM", hour - 12, minute) + " - "+ message;
        }
    }

    
}
