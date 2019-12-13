﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Main loop where we are going to accept input
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            print("Loading up the dog dish with food");
        }
        if (Input.GetKeyDown("t"))
        {
            print("Giving the dog a treat");
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
