using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mole : MonoBehaviour
{

    public Action OnClick;
    public Action OnDisappear;
    public float DisappearTime = 0.8f;
    private float DisappearTimer;
    public SpriteRenderer spriteRenderer;
    public bool IsQuit; 
    public int ID{get;private set;}
    
    bool hitted = false;
    protected State state;
   
    private void Update()
    {
        DisappearTimer += Time.deltaTime * GameManager.Multiplier;
        if (DisappearTimer > DisappearTime)
        {
            DisappearTimer = -10;
            Disappear();
        }
    }
    
    public virtual void Init(int sortingOrder,State gm,int id)
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = sortingOrder;
        state=gm;
        this.ID=id;
    }
    public virtual void Click()
    {
        OnClick?.Invoke();
        if(hitted) return;
        hitted = true;
        Hit();
    }
    public virtual void Disappear()
    {
        OnDisappear?.Invoke();
    }

    

    protected virtual void OnDestroy()
    {
        if (hitted)
        {
            //Hit();
        }
        else
        {
            Miss();
        }
    }
    protected virtual void Hit()
    {
        state.Hit(ID);
    }
    protected virtual void Miss()
    {
        state.Miss(ID);
    }
}
