using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Hole> holes = new();

    private float GenerateTimer;

    private void Start()
    {
        foreach (Hole hole in holes)
        {
            hole.Init(this);
        }
        NowState.Init(this);
    }
    private void Update()
    {
        GenerateTimer += Time.deltaTime;
        if (GenerateTimer > NowState.interval)
        {
            GenerateTimer -= NowState.interval;
            if (GenerateTimer > NowState.interval)
            {
                GenerateTimer = 0;
            }
            GenerateNext();

        }
    }
    public void GenerateNext()
    {
        if (NowState != null)
        {
            State s = NowState.Next();
            if (s != null)
            {
                NowState = s;
                NowState.Init(this);
            }
        }
    }
    public State NowState;
    public void InitHole()
    {

    }

    public int ContinuousHitCount { get; private set; } = 0;
    public int ContinuousMissCount { get; private set; } = 0;
    public int TotalHitCount { get; private set; } = 0;

    public ScoreDisplay chc, cmc, thc;

    public void Miss()
    {
        ContinuousHitCount = 0;
        ContinuousMissCount++;
        DisplayScore();
    }

    public void Hit()
    {
        ContinuousHitCount++;
        TotalHitCount++;
        ContinuousMissCount = 0;
        DisplayScore();
    }

    private void DisplayScore()
    {
        chc.SetScore(ContinuousHitCount);
        cmc.SetScore(ContinuousMissCount);
        thc.SetScore(TotalHitCount);
    }

}
