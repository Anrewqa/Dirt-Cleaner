using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreTracker
{
    private static int score;
    public static int Score { get { return score; } }

    public static System.Action ActivateRageMode;

    public static void AddPoints(int points)
    {
        score += points;
        if(score % 500 == 0) ActivateRageMode();
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
