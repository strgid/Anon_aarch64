using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelay : BaseMonoManager<TimeDelay>
{
    public void Delay(float delayTime,Action action)
    {
        StartCoroutine(DelayLogic(delayTime,action));
    }
    public IEnumerator DelayLogic(float delayTime, Action action)
    {
        yield return new WaitForSeconds(delayTime);
        action?.Invoke();
    }
}
