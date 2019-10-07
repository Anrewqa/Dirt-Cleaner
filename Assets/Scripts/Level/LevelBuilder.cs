using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private bool buildRandomLevel;
    [SerializeField] private Chunk firstChunk;
    [SerializeField] private List<Chunk> otherChunks = new List<Chunk>();
    [SerializeField] private Chunk lastChunk;
    [SerializeField] private int chunksCount;

    [SerializeField] private LevelInfo levelInfo;

    [SerializeField] private ProgressTracker tracker;

    Vector3 previousChunkExit;
    Vector3 startPos;
    Vector3 finishPos;

    public void BuildRandomLevel(int midChunksCount)
    {
        Chunk currentChunck;
        currentChunck = Instantiate(firstChunk, levelInfo.transform);
        startPos = currentChunck.CheckpointPosition;
        previousChunkExit = firstChunk.ExitPosition;
        if (otherChunks.Count > 0)
        {
            for (int i = 0; i < midChunksCount; i++)
            {
                int r = Random.Range(0, otherChunks.Count);
                currentChunck = Instantiate(otherChunks[r], previousChunkExit + otherChunks[r].GetChunkLength() / 2, Quaternion.identity, levelInfo.transform);
                previousChunkExit = currentChunck.ExitPosition;
            }
        }
        currentChunck = Instantiate(lastChunk, previousChunkExit + lastChunk.GetChunkLength()/2, Quaternion.identity, levelInfo.transform);
        finishPos = currentChunck.CheckpointPosition;
    }

    public void ClearLevel()
    {
        foreach (Transform child in levelInfo.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void BuildLevel()
    {
        ClearLevel();
        BuildRandomLevel(chunksCount);
        SendInfoAboutLevel(1, startPos, finishPos);
        tracker.SignLevelInfo(levelInfo);
    }

    public void BuildLevel(int number,int level)
    {
        ClearLevel();
        BuildRandomLevel(level);
        SendInfoAboutLevel(number, startPos, finishPos);
        tracker.SignLevelInfo(levelInfo);
    }

    public void SendInfoAboutLevel(int number, Vector3 startPos, Vector3 finishPos)
    {
        levelInfo.Information = new LevelInfo.Info(number ,startPos, finishPos);
    }

}
