using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    
    // Main loop where we are going to accept input
    void Update()
    {
        // Make sure the game has started before we accept input
        if (InteractablesManager.instance.started == true)
        {
            if (Input.GetKeyDown("f"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    if (InteractablesManager.instance.foodBowl != 1)
                    {
                        InteractablesManager.instance.AddToLog("Filled up doggy bowl with food\n");
                        InteractablesManager.instance.foodBowl = 1;
                    }
                    else
                    {
                        InteractablesManager.instance.AddToLog("The food bowl is already full, do something else\n");
                    }
                } else
                {
                    InteractablesManager.instance.AddToLog("You cant add food, you're at work! \n");
                }
                
            }
            if (Input.GetKeyDown("t"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Giving diego a treat\n");
                    InteractablesManager.instance.treats += 1;
                }
                else
                {
                    InteractablesManager.instance.AddToLog("You cant give a treat, you're at work! \n");
                }
            }
            if (Input.GetKeyDown("k"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Throwing a stick to diego \n");
                    InteractablesManager.instance.playing = true;
                } else {
                    InteractablesManager.instance.AddToLog("You cant throw a sitck, you're at work! \n");
                }
            }
            if (Input.GetKeyDown("p"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Petting diego \n");
                    InteractablesManager.instance.petting = true;
                } else
                {
                    InteractablesManager.instance.AddToLog("You cant pet diego you're at work! \n");
                }
            }
            if (Input.GetKeyDown("b"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Belly rubbing diego \n");
                    InteractablesManager.instance.petting = true;
                } else
                {
                    InteractablesManager.instance.AddToLog("You cant rub his belly, you're at work!\n");
                }
            }
            if (Input.GetKeyDown("w"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Going for a walk \n");
                    InteractablesManager.instance.walk = true;
                }
                else
                {
                    InteractablesManager.instance.AddToLog("You cant go for a walk, you're at work!\n");
                }
            }
            if (Input.GetKeyDown("l"))
            {
                InteractablesManager.instance.AddToLog("Leaving the dog alone \n");
            }
            if (Input.GetKeyDown("g"))
            {
                if (InteractablesManager.instance.work == false)
                {
                    InteractablesManager.instance.AddToLog("Going to work \n");
                    InteractablesManager.instance.work = true;
                } else
                {
                    InteractablesManager.instance.AddToLog("You're already a work\n");
                }
            }
            if (Input.GetKeyDown("a"))
            {
                if (InteractablesManager.instance.work == true)
                {
                    InteractablesManager.instance.AddToLog("Ariving from work \n");
                    InteractablesManager.instance.work = false;
                } else
                {
                    InteractablesManager.instance.AddToLog("You're already home\n");
                }
            }
            if (Input.GetKeyDown("i"))
            {
                InteractablesManager.instance.AddToLog("Idling \n");
                InteractablesManager.instance.minute += 15;
                for (int i = 0; i < 30; i++)
                {
                    GameObject.Find("Doggie").GetComponent<UnitTask>().Update();
                }

            }
            if (Input.GetKeyDown("h"))
            {
                InteractablesManager.instance.AddToLog("Waiting for an hour \n");
                InteractablesManager.instance.hour += 1;
                for (int i = 0; i < 120; i++)
                {
                    GameObject.Find("Doggie").GetComponent<UnitTask>().Update();
                }
            }
            if (Input.GetKeyDown("d"))
            {
                InteractablesManager.instance.AddToLog("Starting a new day \n");
                int difference = 0;
                if(InteractablesManager.instance.hour >= 7)
                {
                    difference = Mathf.Abs(InteractablesManager.instance.hour - 31);
                } else
                {
                    difference = Mathf.Abs(InteractablesManager.instance.hour - 7);
                }
                Debug.Log(difference);
                InteractablesManager.instance.hour = 7;
                InteractablesManager.instance.minute = 0;
                for (int i = 0; i < difference * 120; i++)
                {
                    GameObject.Find("Doggie").GetComponent<UnitTask>().Update();
                }
            }
            if (Input.GetKeyDown("s"))
            {
                InteractablesManager.instance.AddToLog("A mysterious sound was heard \n");
                InteractablesManager.instance.sound = true;
            }
        }
    }
}
