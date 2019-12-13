using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class UnitTask : MonoBehaviour
{
    public int hunger;
    public int boredom;
    public int exhaustion;
    public int happyness;
    public int bellyBoredom;
    public int stickBoredom;
    public int sadness;
    public bool walking;

    private void Awake()
    {
        hunger = 0;
        boredom = 0;
        exhaustion = 0;
        happyness = 10000;
        bellyBoredom = 0;
        stickBoredom = 0;
        sadness = 0;
        walking = false;
    }

    void Update()
    {
        if (InteractablesManager.instance.started == true)
        {
            hunger += 1;
            boredom += 1;
            happyness -= 1;
            exhaustion += 1;
        }
    }


    [Task]
    public void EatFood()
    {
        if(InteractablesManager.instance.foodBowl > 0 && hunger > 900)
        {
            InteractablesManager.instance.foodBowl -= 1;
            InteractablesManager.instance.AddToLog("Diego ate out of the doggie bowl\n");
            hunger -= 900;
            Task.current.Succeed();
        } else
        {
            Task.current.Fail();
        }
    }

    [Task]
    public void Rest()
    {
        if (exhaustion > 1200 && InteractablesManager.instance.hour < 22 && InteractablesManager.instance.hour > 7)
        {
            InteractablesManager.instance.AddToLog("Diego is taking a short nap\n");
            exhaustion -= 900;
            Task.current.Succeed();
        } else
        {
            Task.current.Fail();
        }
    }

    [Task]
    public void Bark()
    {
        Task.current.Fail();
    }


    [Task]
    public void Whimper()
    {
        if (sadness > 40)
        {
            InteractablesManager.instance.AddToLog("Diego is whimpering\n");
            Task.current.Fail();
        }
        Task.current.Fail();
    }

    [Task]
    public void Playing()
    {
        InteractablesManager.instance.AddToLog("Diego is playing\n");
        Task.current.Fail();
    }

    [Task]
    public void Sleeping()
    {
        if (exhaustion > 1200 && InteractablesManager.instance.hour > 22 && InteractablesManager.instance.hour < 7)
        {
            InteractablesManager.instance.AddToLog("Diego is sleeping\n");
            exhaustion -= 900;
            Task.current.Succeed();
        }
        Task.current.Fail();
    }

    [Task]
    public void Walking()
    {
        if (walking == true)
        {
            InteractablesManager.instance.AddToLog("Diego is walking\n");
            Task.current.Fail();
        }
        Task.current.Fail();
    }

}
