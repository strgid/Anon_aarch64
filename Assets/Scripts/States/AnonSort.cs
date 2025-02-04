using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnonSort : State
{

    public State NextState;

    private List<int> hitted = new();

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        Life = 3;
        Interval = 1;
        count = 0;
        missed.Clear();
    }

    private List<Mole> generated = new();

    public override void Generate()
    {
        if (count != 0 && !missed.Contains(count - 1) && (hitted.Count() > 0 && hitted.Max() != 3 || hitted.Count() == 0))
        {
            missed.Add(count - 1);
            base.Miss(0);
        }

        Interval = 2.5f;
        foreach (var v in generated)
        {
            if (v != null)
            {
                v.Disappear();
            }
        }
        generated.Clear();

        bool success;
        hitted.Clear();
        for (int i = 0; i < 4; i++)
        {
            success = false;
            while (!success)
            {
                Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
                (bool s, Mole mole) = h.GenerateAnonAndGet(moles[i], i + count * 4, this);
                success = s;
                generated.Add(mole);
            }
        }

        count++;
    }
    int count = 0;

    public override State GetNextState()
    {
        return NextState;
    }

    List<int> missed = new();

    public override void Hit(int id)
    {
        if (hitted.Count() == 0)
        {
            if (id % 4 == 0)
            {
                hitted.Add(id % 4);
                base.Hit(id);
                if (id % 4 == 3)
                {
                    missed.Add(id / 4);
                    Interval = gameManager.GetNowTimer() + 1;
                }
            }
            else
            {
                if (missed.Contains(id / 4)) return;
                missed.Add(id / 4);
                foreach (var v in generated)
                {
                    if (v != null)
                    {
                        v.Disappear();
                    }
                }
                Interval = gameManager.GetNowTimer() + 1;
                generated.Clear();
                base.Miss(id);
            }
        }
        else
        {
            if (hitted.Max() != id % 4 - 1)
            {
                if (missed.Contains(id / 4)) return;
                missed.Add(id / 4);
                foreach (var v in generated)
                {
                    if (v != null)
                    {
                        v.Disappear();
                    }
                }
                Interval = gameManager.GetNowTimer() + 1;
                generated.Clear();
                base.Miss(id);
            }
            else
            {
                hitted.Add(id % 4);
                base.Hit(id);
                if (id % 4 == 3)
                {
                    missed.Add(id / 4);
                    Interval = gameManager.GetNowTimer() + 1;
                }
            }
        }
    }

    public override void Miss(int id)
    {
        if (missed.Contains(id / 4)) return;
        missed.Add(id / 4);
        base.Miss(id);
    }
}
