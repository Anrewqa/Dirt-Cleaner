using System.Collections.Generic;
using UnityEngine;

public class LevelSequence : MonoBehaviour
{
    [SerializeField] private int startLevelNumber = 1;
    [Tooltip("Number of level, that start endless cycle")]
    [SerializeField] private int cycleFrom = 25;
    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private LevelBuilder builder;


    private void Awake()
    {
        SendLevelForBuild();
    }

    public void SendLevelForBuild()
    {
        if (levels.Count > startLevelNumber - 1)
        {
            builder.BuildLevel(startLevelNumber, levels[startLevelNumber - 1]);
            if (startLevelNumber > levels.Count) startLevelNumber = cycleFrom;
            else startLevelNumber++;            
        }
    }
}
