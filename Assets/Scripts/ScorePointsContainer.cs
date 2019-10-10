using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsContainer : MonoBehaviour
{
    [SerializeField] private int points;
    bool isUsed;
    public int Points { get { return points; } }

    public int UseContainer()
    {
        isUsed = true;
        return points;
    }

    public void ResetContainer()
    {
        isUsed = false;
    }
}
