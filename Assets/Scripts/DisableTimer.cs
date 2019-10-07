using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTimer : MonoBehaviour
{
    private bool timerStarted;
    [SerializeField] private float timeBeforeDisable;
    private float timePassed;

    [SerializeField] private TransformReset transformReset;

    void Update()
    {
        if(timerStarted)
        {
            timePassed += Time.deltaTime;

            if(timePassed >= timeBeforeDisable)
            {
                transformReset.ResetTransform();
                ResetTimer();
                gameObject.SetActive(false);                
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void StartTimer(float time)
    {
        timerStarted = true;
        timeBeforeDisable = time;
    }

    public void ResetTimer()
    {
        timerStarted = false;
        timePassed = 0;
    }
}
