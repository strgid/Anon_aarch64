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
        life = 12;
        hitted.Clear();
        missed.Clear();
    }

    public float[] intervals;

    Dictionary<int, List<Mole>> generated = new();

    public override void Generate()
    {
        int count = counter / 4;

        interval = intervals[count];

        if (counter % 4 == 3)
        {
            interval *= 2;
        }

        if (!generated.ContainsKey(counter)) generated[counter] = new();
        generated[counter].Clear();

        for (int i = 0; i < 2 * (count + 1); i++)
        {
            bool success = false;

            while (!success)
            {
                Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
                (bool s, Mole mole) = h.GenerateAnonAndGet(moles[counter % 4], counter, this);
                success = s;

                if (mole == null) continue;
                generated[counter].Add(mole);
            }
        }
        counter++;
    }

    public override State GetNextState()
    {
        return NextState;
    }

    List<int> hitted = new();
    List<int> missed = new();

    public bool DownTogether = false;

    public override void Hit(int id)
    {
        if (!hitted.Contains(id))
        {
            hitted.Add(id);
            if (DownTogether)
            {
                foreach (var i in generated[id])
                {
                    Debug.Log(1);
                    i.Disappear();
                }
            }
            base.Hit(id);
        }
    }

    public override void Miss(int id)
    {
        if (!hitted.Contains(id))
        {
            if (!missed.Contains(id))
            {
                missed.Add(id);
                base.Miss(id);
            }
        }
    }
}
