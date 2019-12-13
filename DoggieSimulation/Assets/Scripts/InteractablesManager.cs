using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    public int hour;
    public int minute;
    public static InteractablesManager instance;

    private void Awake()
    {
        instance = this;
    }
}
