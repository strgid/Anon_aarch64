using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitBreakUI : MonoBehaviour
{
    public Sprite[] sprites;
    public AudioClip[] clips;
    public Image content;
    public void Show(int index)
    {
        index = Mathf.Clamp(index, 0, sprites.Length-1);
        content.sprite = sprites[index];
        SoundManager.Instance.PlaySound(clips[index]);
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
