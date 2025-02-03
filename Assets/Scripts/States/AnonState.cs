using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonState : State
{
    int counter;

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        Life = 4;
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
}
