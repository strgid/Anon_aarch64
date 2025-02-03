using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonChorus : State
{
    int counter;
    public State next;

    public AudioClip[] tgw;

    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        life = 12;
        hitted = false;
        missed = false;
        interval = 1.5f;
    }

    public override State GetNextState()
    {
        return next;
    }

    bool hitted;

    public override void Generate()
    {
        hitted = false;
        missed = false;
        generate.Clear();
        StartCoroutine(GenerateAnon(counter));
        SoundManager.Instance.PlaySound(tgw[counter % 4]);
        counter++;
    }

    IEnumerator GenerateAnon(int counter)
    {
        if (false)//UnityEngine.Random.Range(0, 2) == 0)
        {
            countlast=4;
            interval=2f;
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                int y = UnityEngine.Random.Range(0, 3);
                for (int x = 0; x < 4; x++)
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
                int y = UnityEngine.Random.Range(0, 3);
                for (int x = 3; x >= 0; x--)
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
        else
        {
            countlast=3;
            interval=1.5f;
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
    }

    List<Mole> generate = new();

    int countlast = 0;

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
    bool missed = false;

    public override void Miss(int id)
    {
        if (countlast > 0)
        {
            if (missed) return;
            missed = true;
            if (!hitted)
            {
                gameManager.Miss();
            }
        }
    }
}
