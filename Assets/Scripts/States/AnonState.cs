using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonState : State
{
    int counter;

    int totalHit = 0;

    public State[] States;

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        life = 4;
    }

    public override void Generate()
    {
        bool success = false;
        while (!success)
        {
            Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
            success = h.GenerateAnon(moles[counter % 4], 0, this);
        }
        counter++;

        // 0.5 ¸ÅÂÊÉú³Ésaki
        if (Random.Range(0, 1f) < 0.5f)
        {
            success = false;
            while (!success)
            {
                Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
                success = h.GenerateAnon(moles[4], 0, this);
            }
        }
    }

    public int HitOverThanSwitch = 8;

    public override State GetNextState()
    {
        if (totalHit >= HitOverThanSwitch)
        {
            totalHit = 0;
            return States[Random.Range(0, States.Length)];
        }
        else
        {
            return this;
        }
    }

    public override void Hit(int id)
    {
        base.Hit(id);
        totalHit++;
    }
}
