using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text text;
        void Awake()
    {
        text=GetComponent<Text>();
    }

    public string fwd,bwd;
    public void SetScore(int score){
        if (text == null) return;
        text.text=fwd+score.ToString()+bwd;
    }
}
