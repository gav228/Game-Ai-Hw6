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
                if (InteractablesManager.instance.foodBowl != 8) {
                    InteractablesManager.instance.AddToLog("Filled up doggy bowl with food\n");
                    InteractablesManager.instance.foodBowl = 8;
                } else
                {
                    InteractablesManager.instance.AddToLog("The food bowl is already full, do something else\n");
                }
                
            }
            if (Input.GetKeyDown("t"))
            {
                InteractablesManager.instance.AddToLog("Giving the dog a treat\n");
            }
            if (Input.GetKeyDown("k"))
            {
                print("Throwing a stick");
            }
            if (Input.GetKeyDown("p"))
            {
                print("Petting the dog");
            }
            if (Input.GetKeyDown("b"))
            {
                print("Belly rubbing the dog");
            }
            if (Input.GetKeyDown("w"))
            {
                print("Going for a walk");
            }
            if (Input.GetKeyDown("l"))
            {
                print("Leaving the dog alone");
            }
            if (Input.GetKeyDown("g"))
            {
                print("Going to work");
            }
            if (Input.GetKeyDown("a"))
            {
                print("Arriving from work");
            }
            if (Input.GetKeyDown("i"))
            {
                print("Idling");
            }
            if (Input.GetKeyDown("h"))
            {
                print("Waiting for an hour");
            }
            if (Input.GetKeyDown("d"))
            {
                print("Starting a new day");
            }
            if (Input.GetKeyDown("s"))
            {
                print("Making a mysterious sound");
            }
        }
    }
}
