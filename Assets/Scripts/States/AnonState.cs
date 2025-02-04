using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnonState : State
{
    public LightManager LightManager;
    int counter;
    int totalCounter=-1;

    int totalHit = 0;

    public State[] States;
    public LimitBreakUI breakUI;
    public override void Init(GameManager gm)
    {
        base.Init(gm);
        counter = 0;
        Life = 4;
        LightManager.DisableColorMode();
        missed.Clear();
    }

    private List<int> missed=new();

    public override void Generate()
    {
        bool success = false;
        while (!success)
        {
            Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
            success = h.GenerateAnon(moles[counter % 4], counter, this);
        }

        // 0.5 ¸ÅÂÊÉú³Ésaki
        if (Random.Range(0, 1f) < 0.5f)
        {
            success = false;
            while (!success)
            {
                Hole h = gameManager.holes[Random.Range(0, gameManager.holes.Count)];
                success = h.GenerateAnon(moles[4], counter, this);
            }
        }
        counter++;
    }

    public int HitOverThanSwitch = 8;

    public override State GetNextState()
    {
        if (totalHit >= HitOverThanSwitch)
        {
            totalHit = 0;
            breakUI.Show();
            LightManager.EnableColorMode();
            totalCounter++;
            return States[totalCounter% States.Length];
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

    public override void Miss(int id)
    {
        if(missed.Contains(id)) return;

        missed.Add(id);
        base.Miss(id);
    }
}
