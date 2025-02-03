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
    private void Update()
    {
        DisappearTimer += Time.deltaTime;
        if (DisappearTimer > DisappearTime)
        {
            DisappearTimer = -10;
            Disappear();
        }
    }
    public virtual void Init(int sortingOrder)
    {
        if(spriteRenderer==null)spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = sortingOrder;
    }
    public virtual void Click()
    {
        OnClick?.Invoke();

    }
    public virtual void Disappear()
    {
        OnDisappear?.Invoke();
    }
}
