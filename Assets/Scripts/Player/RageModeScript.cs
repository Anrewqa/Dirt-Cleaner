using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RageModeScript : MonoBehaviour
{

    private bool rageModeOn = false;
    [SerializeField] private float duration;
    private float timeInRage;

    [SerializeField] private UnityEvent ActivateRageModeEvent = new UnityEvent();
    [SerializeField] private UnityEvent DeactivateRageModeEvent = new UnityEvent();

    void Start()
    {
        ScoreTracker.ActivateRageMode += ActivateRageMode;
    }

    private void OnDestroy()
    {
        ScoreTracker.ActivateRageMode -= ActivateRageMode;
    }


    void Update()
    {
        if (rageModeOn)
        {
            timeInRage += Time.deltaTime;
            if (timeInRage > duration)
            {
                DeactivateRageMode();
            }
        }
    }

    private void ActivateRageMode()
    {
        rageModeOn = true;
        ActivateRageModeEvent?.Invoke();
    }
    private void DeactivateRageMode()
    {
        timeInRage = 0;
        rageModeOn = false;
        DeactivateRageModeEvent?.Invoke();
    }
}
