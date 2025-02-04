using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBreakUI : MonoBehaviour
{
    
    public void Show()
    {
        gameObject.SetActive(true);
      
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void PlaySound(AudioClip clip)
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
