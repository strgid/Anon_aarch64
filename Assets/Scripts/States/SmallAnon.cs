using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAnon : State
{
    int counter;

    public State NextState;

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        life = 12;
        interval = 1;
    }

    public override void Generate()
    {
        bool success = false;
        while (!success)
        {
            Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
            success = h.GenerateAnon(moles[counter % 4], 0, this);
        }
        if (counter % 4 == 3)
        {
            interval = 2;
        }
        else
        {
            interval = 1;
        }
        counter++;
    }

    public override State GetNextState()
    {
        return NextState;
    }
}
