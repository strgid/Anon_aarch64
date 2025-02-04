using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextFlicker : MonoBehaviour
{
    public Text text;
    private bool isShow = true;
    private string content;
    public float FlickerInterval = 1f;

    private void Start()
    {
        content = text.text;
        InvokeRepeating(nameof(Switch), 0, FlickerInterval);
    }
    private void Switch()
    {
        isShow = !isShow;
        if (isShow) text.text = content;
        else text.text = "";
    }
}
