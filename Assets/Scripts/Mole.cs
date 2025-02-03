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
    private void Update()
    {
        DisappearTimer += Time.deltaTime;
        if (DisappearTimer > DisappearTime)
        {
            DisappearTimer = -10;
            Disappear();
        }
    }
    protected GameManager gameManager;
    public virtual void Init(int sortingOrder,GameManager gm)
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = sortingOrder;
        gameManager=gm;
    }
    public virtual void Click()
    {
        OnClick?.Invoke();
        hitted = true;
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
            Hit();
        }
        else
        {
            Miss();
        }
    }
    protected virtual void Hit()
    {
        gameManager.Hit();
    }
    protected virtual void Miss()
    {
        gameManager.Miss();
    }
}
