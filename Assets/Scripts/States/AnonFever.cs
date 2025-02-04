using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonFever : State
{
    int counter;

    public State NextState;

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        Life = 20;
    }

    public float DefaultInterval=1 ,IntervalDiscount=0.9f;

    public override void Generate()
    {
        int count = counter;

        Interval = DefaultInterval*Mathf.Pow(IntervalDiscount,count);

        if(Interval<0.5f){
            Interval=0.5f;
        }
        if(Life==0){
            Interval=DefaultInterval;
        }

        bool success = false;

        while (!success)
        {
            Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
            (bool s, Mole mole) = h.GenerateAnonAndGet(moles[counter % 4], counter, this);
            success = s;
        }

        counter++;
    }

    public override State GetNextState()
    {
        return NextState;
    }
}
