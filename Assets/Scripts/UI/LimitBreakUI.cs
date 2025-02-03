using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBreakUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        //Time.timeScale = 0f;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        //Time.timeScale = 1f;
    }
    public void PlaySound(AudioClip clip)
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
