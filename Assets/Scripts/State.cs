using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public int life{get;protected set;}=1;
    public float interval{get;protected set;}=1;
    public string nameOfState;

    public GameObject[] moles;

    public State Next()
    {
        if(life==0){
            return GetNextState();
        }
        life--;
        Generate();
        return null;
    }

    public abstract void Generate();

    public virtual void Init(GameManager gm)
    {
        gameManager=gm;
    }
    public virtual void Hit(int id)
    {
        gameManager.Hit();
    }
    public virtual void Miss(int id)
    {
        gameManager.Miss();
    }
    public virtual State GetNextState()
    {
        return this;
    }

    protected GameManager gameManager;

}
