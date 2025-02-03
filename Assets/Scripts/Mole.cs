using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mole : MonoBehaviour
{

    public Action OnClick;
    public Action OnDisappear;
    public float DisappearTime = 0.4f;
    private float DisappearTimer;
    public SpriteRenderer spriteRenderer;
    public bool IsQuit;
    public int id{get;private set;}
    private void Update()
    {
        DisappearTimer += Time.deltaTime;
        if (DisappearTimer > DisappearTime)
        {
            DisappearTimer = -10;
            Disappear();
        }
    }
    protected State state;
    public virtual void Init(int sortingOrder,State gm,int id)
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = sortingOrder;
        state=gm;
        this.id=id;
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

    bool hitted = false;

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
        state.Hit(id);
    }
    protected virtual void Miss()
    {
        state.Miss(id);
    }
}
