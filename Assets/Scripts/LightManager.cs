using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D globalLight; // 2D光源
    public float fadeSpeed = 1f; // 色相变化速度

    private Coroutine colorChangeRoutine; // 记录协程，便于停止
    private bool isColorModeActive = false; // 颜色模式是否激活

    private void Update()
    {

    }

    public void EnableColorMode()
    {
        if (isColorModeActive) return;
        isColorModeActive = true;

        // 启动变色协程
        if (colorChangeRoutine != null)
            StopCoroutine(colorChangeRoutine);
        colorChangeRoutine = StartCoroutine(ChangeLightColor());
    }

    public void DisableColorMode()
    {
        isColorModeActive = false;

        // 停止变色协程
        if (colorChangeRoutine != null)
            StopCoroutine(colorChangeRoutine);

        // 颜色恢复为白色
        if (globalLight != null)
            globalLight.color = Color.white;
    }

    private IEnumerator ChangeLightColor()
    {
        float hue = 0f; // 色相初始值
        while (isColorModeActive)
        {
            hue += Time.deltaTime * fadeSpeed; // 累加色相值
            if (hue > 1f) hue -= 1f; // 循环色相

            // HSL 转换为 RGB 并应用到光源
            Color newColor = Color.HSVToRGB(hue, 0.2f, 1f);
            globalLight.color = newColor;

            yield return null; // 等待一帧
        }
    }
}
