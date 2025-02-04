using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Hole> holes = new();

    private float GenerateTimer;
    public State NowState;
    #region 计分相关
    public int MaxLife = 5;
    public int Life { get; private set; } = 5;//生命值
    public int ContinuousHitCount { get; private set; } = 0;
    public int ContinuousMissCount { get; private set; } = 0;
    public int TotalHitCount { get; private set; } = 0;

    public ScoreDisplay chc, cmc, thc;
    #endregion
    public LimitBreakUI breakUI;
    public HPBar hpBar;

    #region 失败视频
    public GameObject videoPlayer;
    
    private bool isLose;
    #endregion
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
        if (isLose) return;

        GenerateTimer += Time.deltaTime;
        if (GenerateTimer > NowState.Interval)
        {
            GenerateTimer = 0;
            GenerateNext();
        }
    }
    public void GenerateNext()
    {
        if (NowState == null) return;
          NowState.Generate();
        //获取下一个状态
        State s = NowState.Next();
        if (s != null)
        {
            NowState = s;
            NowState.Init(this);
        }
      

    }


    public void Miss()
    {
        Life--;
        hpBar.SetHP(Life/(float)MaxLife);
        if(Life == 0) LoseGame();

        SoundManager.Instance.PlaySound("Sounds/error");
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
    public void LoseGame()
    {
        isLose = true;
        videoPlayer.gameObject.SetActive(true);
        SoundManager.Instance.MuteSound();
        SoundManager.Instance.MuteMusic();
    }
}
