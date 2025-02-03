using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anon : Mole
{
    public Animator animator;
    public AudioClip AppearSound;
    public override void Init(int sortingOrder,GameManager gm)
    {
        base.Init(sortingOrder,gm);
        SoundManager.Instance.PlaySound(AppearSound);
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    public override void Click()
    {
        base.Click();
        Disappear();
    }
    public override void Disappear()
    {
        if (IsQuit) return;
        IsQuit = true;
        base.Disappear();
        animator.Play("Quit");
        TimeDelay.Instance.Delay(0.2f, () => Destroy(gameObject));
    }
}
