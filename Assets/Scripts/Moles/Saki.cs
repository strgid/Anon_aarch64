using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saki : Mole
{
    public Animator animator;
    public AudioClip DisappearSound;
    public override void Init(int sortingOrder,State gm,int id)
    {
        base.Init(sortingOrder,gm,id);
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    bool clicked=false;
    public override void Click()
    {
        if (clicked) return;
        clicked=true;
        base.Click();
        Disappear();
        SoundManager.Instance.PlaySound(DisappearSound);
    }
    public override void Disappear()
    {
        if (IsQuit) return;
        IsQuit = true;
        base.Disappear();
        animator.Play("Quit");
        TimeDelay.Instance.Delay(0.2f, () => Destroy(gameObject));
    }
    protected override void Hit()// ÇÃµ½¼ÆÎªmiss
    {
        base.Miss();
    }
    protected override void Miss()
    {
    }
}
