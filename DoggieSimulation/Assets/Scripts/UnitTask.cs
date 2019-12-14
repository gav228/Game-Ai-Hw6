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
    public int lonelyness;
    public bool barking;
    public int bathroom;
    public bool sleeping;
    public int update_delay;

    private void Awake()
    {
        hunger = 800;
        boredom = 0;
        exhaustion = 0;
        happyness = 10000;
        bellyBoredom = 0;
        stickBoredom = 0;
        sadness = 0;
        walking = false;
        barking = false;
        bathroom = 500;
        sleeping = false;
        update_delay = 0;
        lonelyness = 0;
    }

    public void Update()
    {
        if (InteractablesManager.instance.started == true)
        {
            hunger += 1;
            bathroom += 1;
            if (InteractablesManager.instance.playing == false)
            {
                boredom += 1;
                happyness -= 1;
            }
            if (InteractablesManager.instance.work == true)
            {
                lonelyness += 1;
            }
            exhaustion += 1;
            update_delay += 1;
        }
    }


    [Task]
    public void EatFood()
    {
        if(InteractablesManager.instance.foodBowl > 0 && hunger > 1400)
        {
            InteractablesManager.instance.foodBowl -= 1;
            InteractablesManager.instance.AddToLog("Diego ate out of the doggie bowl\n");
            hunger = 0;
            Task.current.Succeed();
        } else if (hunger > 1400 )
        {
            if (update_delay > 200)
            {
                InteractablesManager.instance.AddToLog("Diego begins to pat at the doggie bowl\n");
                update_delay = 0;
            }
            Task.current.Fail();
        } else if (InteractablesManager.instance.treats > 0 && hunger < 200)
        {
            if (update_delay > 200)
            {
                InteractablesManager.instance.AddToLog("Diego doesnt really want a treat\n");
                update_delay = 0;
            }
            Task.current.Fail();
        }
        else if (InteractablesManager.instance.treats > 0 && hunger > 200)
        {
            if (update_delay > 200)
            {
                InteractablesManager.instance.AddToLog("Diego eats the treat happily\n");
                hunger -= 500;
                InteractablesManager.instance.treats -= 1;
                update_delay = 0;
            }
            Task.current.Fail();
        } else
        {
            Task.current.Fail();
        }
    }

    [Task]
    public void Rest()
    {
        if (exhaustion > 1500 && InteractablesManager.instance.hour < 21 && InteractablesManager.instance.hour > 7 && InteractablesManager.instance.walk == false)
        {
            InteractablesManager.instance.AddToLog("Diego is taking a short nap\n");
            exhaustion = 0;
            Task.current.Succeed();
        } else
        {
            Task.current.Fail();
        }
    }

    [Task]
    public void Bark()
    {
        if(InteractablesManager.instance.sound == true && barking == false)
        {
            InteractablesManager.instance.AddToLog("Diego began barking loudly \n");
            barking = true;
            Task.current.Succeed();
            
        }
        else if (InteractablesManager.instance.sound == true && barking == true)
        {
            InteractablesManager.instance.AddToLog("Diego continues to bark loudly \n");
            Task.current.Succeed();
        } else if (barking == true)
        {
            InteractablesManager.instance.AddToLog("Diego calms down and stops barking \n");
            barking = false;
            Task.current.Fail();
        } else
        {
            Task.current.Fail();
        }
        
    }

    [Task]
    public void Lonely()
    {
        if (lonelyness > 400 && InteractablesManager.instance.petting == false)
        {
            if (update_delay > 200 && InteractablesManager.instance.work == false)
            {
                InteractablesManager.instance.AddToLog("Diego is nuzzling your leg\n");
                update_delay = 0;
            }
            Task.current.Fail();
        } else if (InteractablesManager.instance.petting == true && bellyBoredom < 4)
        {
            InteractablesManager.instance.AddToLog("Diego smiles happily at the contact\n");
            update_delay = 0;
            lonelyness = 0;
            bellyBoredom += 1;
            InteractablesManager.instance.petting = false;
            Task.current.Succeed();
        }
        else if (InteractablesManager.instance.petting == true && bellyBoredom >= 4)
        {
            InteractablesManager.instance.AddToLog("Diego is bored of this\n");
            bellyBoredom += 1;
            InteractablesManager.instance.petting = false;
            Task.current.Succeed();
        } else
        {
            if (update_delay > 200)
            {
                bellyBoredom-= 1;
                update_delay = 0;
            }
            Task.current.Fail();
        }
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
        if(boredom > 800 && InteractablesManager.instance.playing == false )
        {
            if (update_delay > 200 && InteractablesManager.instance.work == false)
            {
                InteractablesManager.instance.AddToLog("Diego is biting at your leg, looks like he wants to play\n");
                update_delay = 0;
            }
            Task.current.Fail();
        } else if (InteractablesManager.instance.playing == true && stickBoredom < 4)
        {
            InteractablesManager.instance.AddToLog("Diego brings the stick back to you happily\n");
            stickBoredom += 1;
            boredom -= 1000;
            InteractablesManager.instance.playing = false;
            Task.current.Succeed();
        } else if(InteractablesManager.instance.playing == true && stickBoredom >= 4)
        {
            InteractablesManager.instance.AddToLog("Diego is bored of fetching the stick\n");
            InteractablesManager.instance.playing = false;
            Task.current.Fail();
        } else
        {
            if(update_delay > 200)
            {
                stickBoredom -= 1;
                update_delay = 0;
            }
            Task.current.Fail();
        }
    }

    [Task]
    public void Sleeping()
    {
        if (exhaustion > 1200 && InteractablesManager.instance.hour > 21 || InteractablesManager.instance.hour < 7 && sleeping == false)
        {
            InteractablesManager.instance.AddToLog("Diego is sleeping\n");
            exhaustion -= 900;
            sleeping = true;
            Task.current.Succeed();
        } else if (sleeping == true && InteractablesManager.instance.hour >= 7 && InteractablesManager.instance.hour < 21)
        {
            InteractablesManager.instance.AddToLog("Diego is waking up\n");
            exhaustion = 0;
            sleeping = false;
            Task.current.Fail();
        } else if (sleeping == true)
        {
            update_delay = 0;
            Task.current.Succeed();
        } else
        {
            Task.current.Fail();
        }
    }

    [Task]
    public void Walking()
    {
        if(bathroom > 1500 && InteractablesManager.instance.walk == false)
        {
            if (update_delay > 200)
            {
                InteractablesManager.instance.AddToLog("Diego hits the front door, seems like he needs to go out\n");
                update_delay = 0;
            }
            Task.current.Fail();
        } else if (InteractablesManager.instance.walk == true && bathroom > 1500)
        {
            InteractablesManager.instance.AddToLog("Diego is doing his business outside\n");
            bathroom = 0;
            Task.current.Succeed();
        } else if (InteractablesManager.instance.walk == true)
        {
            InteractablesManager.instance.AddToLog("Diego seems satisfied with his walk\n");
            InteractablesManager.instance.walk = false;
            Task.current.Fail();
        } else
        {
            Task.current.Fail();
        }
    }

}
