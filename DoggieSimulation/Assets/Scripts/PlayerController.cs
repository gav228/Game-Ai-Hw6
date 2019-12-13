using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Main loop where we are going to accept input
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            InteractablesManager.instance.logtext.text += "• Filled up doggy bowl with food\n";
        }
        if (Input.GetKeyDown("t"))
        {
            string[] lines = InteractablesManager.instance.logtext.text.Split('\n');

            InteractablesManager.instance.logtext.text = string.Join("\n", lines);
            InteractablesManager.instance.logtext.text += "• Giving the dog a treat\n";
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
