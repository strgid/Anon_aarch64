using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonChorus : State
{
    int counter;
    public State next;

    public AudioClip[] tgw;
    List<Mole> generate = new();

    int countlast = 0;
    bool isMissed = false;
    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        Life = 12;
        hitted = false;
        isMissed = false;
        Interval = 1.5f;
    }

    public override State GetNextState()
    {
        return next;
    }

    bool hitted;

    public override void Generate()
    {
        hitted = false;
        isMissed = false;
        generate.Clear();
        StartCoroutine(GenerateAnon(counter));
        SoundManager.Instance.PlaySound(tgw[counter % 4]);
        if (counter % 4 == 3)
        {
            Interval = 2f;
        }
        else
        {
            Interval = 1.5f;
        }
        counter++;
    }

    IEnumerator GenerateAnon(int counter)
    {
        countlast = 3;
        Interval = 1.5f;
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            int x = UnityEngine.Random.Range(0, 4);
            for (int y = 0; y < 3; y++)
            {
                Hole h = gameManager.holes[x + y * 4];
                Mole m = h.GenerateAnon(moles[counter % 4], x, this, true);
                if (m != null)
                {
                    generate.Add(m);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            int x = UnityEngine.Random.Range(0, 4);
            for (int y = 2; y >= 0; y--)
            {
                Hole h = gameManager.holes[x + y * 4];
                Mole m = h.GenerateAnon(moles[counter % 4], x, this, true);
                if (m != null)
                {
                    generate.Add(m);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }



   
    public override void Hit(int id)
    {
        countlast--;
        if (countlast == 0)
        {
            if (hitted) return;
            hitted = true;
            gameManager.Hit();
        }
    }
   

    public override void Miss(int id)
    {
        if (countlast > 0)
        {
            if (isMissed) return;
            isMissed = true;
            if (!hitted)
            {
                gameManager.Miss();
            }
        }
    }
}
