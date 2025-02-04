using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    public Image hpImage;
    public Image hpbufferImage;
    private const float bufferSpeed = 2;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        hpbufferImage.fillAmount = Mathf.Lerp(hpbufferImage.fillAmount, hpImage.fillAmount, bufferSpeed * Time.deltaTime);
    }
    public void SetHP(float value)
    {
        if (hpImage == null) return;
        value = Mathf.Clamp01(value);
        hpImage.fillAmount = value;
        animator.Play("Shake");
    }
}
