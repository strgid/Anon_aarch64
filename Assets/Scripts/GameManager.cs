using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> molePool = new();
    public List<Hole> holes = new();
    public float Interval = 0.5f;
    private float GenerateTimer;
    int counter;
    private void Start()
    {
        foreach (Hole hole in holes)
        {
            hole.Init(this);
        }
    }
    private void Update()
    {
        GenerateTimer += Time.deltaTime;
        if (GenerateTimer > Interval)
        {
            GenerateTimer = 0;
            GenerateNext();

        }
    }
    public void GenerateNext()
    {
        bool success = false;
        while (!success)
        {
            Hole h = holes[Random.Range(0, holes.Count)];
            success = h.GenerateAnon(molePool[counter % 4]);
        }
        counter++;

        // 0.5 ¸ÅÂÊÉú³Ésaki
        if (Random.Range(0, 1f) < 0.5f)
        {
            success = false;
            while (!success)
            {
                Hole h = holes[Random.Range(0, holes.Count)];
                success = h.GenerateAnon(molePool[4]);
            }
        }
    }
    public void InitHole()
    {

    }

    public int ContinuousHitCount{get;private set;}=0;
    public int ContinuousMissCount{get;private set;}=0;
    public int TotalHitCount{get;private set;}=0;

    public ScoreDisplay chc,cmc,thc;

    public void Miss()
    {
        ContinuousHitCount=0;
        ContinuousMissCount++;
        DisplayScore();
    }

    public void Hit()
    {
        ContinuousHitCount++;
        TotalHitCount++;
        ContinuousMissCount=0;
        DisplayScore();
    }

    private void DisplayScore(){
        chc.SetScore(ContinuousHitCount);
        cmc.SetScore(ContinuousMissCount);
        thc.SetScore(TotalHitCount);
    }

}
