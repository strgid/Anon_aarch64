using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
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
            hole.Init();
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
        Hole h = holes[Random.Range(0, holes.Count)];
        if (!h.GenerateAnon(molePool[(counter++)%4]))
        {
            GenerateNext();
        }
       
    }
    public void InitHole()
    {

    }
   
}
