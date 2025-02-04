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
        Life = 12;
        Interval = 1;
    }

    public override void Generate()
    {
        bool success = false;
        while (!success)
        {
            Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
            success = h.GenerateAnon(moles[counter % 4], 0, this);
        }
        if (counter % 4 == 3&&Life>0)
        {
            Interval = 2;
        }
        else
        {
            Interval = 1;
        }
        counter++;
    }

    public override State GetNextState()
    {
        return NextState;
    }
}
