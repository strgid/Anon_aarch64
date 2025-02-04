using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideManager : MonoBehaviour
{
    public VideoClip[] clips;
    public VideoPlayer player;
    public void Play(int Index)
    {
        if (Index < 0 || Index >= clips.Length) return;

        player.clip = clips[Index];
        gameObject.SetActive(true);
    }
}
