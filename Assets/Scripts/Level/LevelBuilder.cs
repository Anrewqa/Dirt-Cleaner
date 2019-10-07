using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private bool buildRandomLevel;
    [SerializeField] private Chunk firstChunk;
    [SerializeField] private List<Chunk> otherChunks = new List<Chunk>();
    [SerializeField] private Chunk lastChunk;
    [SerializeField] private int chunksCount;
    [Tooltip("Start of level must be at (0,0,0)")]
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private LevelInfo levelInfo;
    [SerializeField] private GameObject parentForChunks;
    private GameObject currentLevelHolder;

    [SerializeField] private ProgressTracker tracker;

    Vector3 previousChunkExit;
    Vector3 startPos;
    Vector3 finishPos;

    public void BuildRandomLevel(int midChunksCount)
    {
        Chunk currentChunck;
        currentChunck = Instantiate(firstChunk, currentLevelHolder.transform);
        startPos = currentChunck.CheckpointPosition;
        previousChunkExit = firstChunk.ExitPosition;
        if (otherChunks.Count > 0)
        {
            for (int i = 0; i < midChunksCount; i++)
            {
                int r = Random.Range(0, otherChunks.Count);
                currentChunck = Instantiate(otherChunks[r], previousChunkExit + otherChunks[r].GetChunkLength() / 2, Quaternion.identity, currentLevelHolder.transform);
                previousChunkExit = currentChunck.ExitPosition;
            }
        }
        currentChunck = Instantiate(lastChunk, previousChunkExit + lastChunk.GetChunkLength()/2, Quaternion.identity, currentLevelHolder.transform);
        finishPos = currentChunck.CheckpointPosition;
    }

    public void BuildLevelFromPrefab(GameObject levelPrefab)
    {
        foreach (Transform chunk in levelPrefab.transform)
        {
            Instantiate(chunk.gameObject, currentLevelHolder.transform);
        }
    }

    public GameObject GetLevel()
    {
        return parentForChunks;
    }

    public void SetLevelPrefab(GameObject prefab)
    {
        levelPrefab = prefab;
    }

    public void ClearLevel()
    {
        DestroyImmediate(currentLevelHolder);
    }

    public void BuildLevel()
    {
        ClearLevel();
        currentLevelHolder = Instantiate(parentForChunks, transform);
        if (buildRandomLevel)
        {
            BuildRandomLevel(chunksCount);
        }
        else
        {
            if (levelPrefab != null)
            {
                BuildLevelFromPrefab(levelPrefab);
            }
            else
            {
                BuildRandomLevel(chunksCount);
                Debug.LogError("Prefab must be assigned in inspector!");
            }
        }
        levelInfo.GetComponent<LevelInfo>().Information = new LevelInfo.Info(1,startPos, finishPos, chunksCount);
        tracker.SignLevelInfo(currentLevelHolder.GetComponent<LevelInfo>());
    }

    public void BuildLevel(int number,Level level)
    {
        ClearLevel();
        currentLevelHolder = Instantiate(parentForChunks, transform);
        if (level.isRandom)
        {
            BuildRandomLevel(level.chunksCount);
        }
        else
        {
            if (levelPrefab != null)
            {
                BuildLevelFromPrefab(level.prefab);
            }
            else
            {
                BuildRandomLevel(level.chunksCount);
                Debug.LogError("Prefab must be assigned in inspector!");
            }
        }
        
        tracker.SignLevelInfo(currentLevelHolder.GetComponent<LevelInfo>());
    }

    public void SendInfoAboutLevel(int number, Vector3 startPos, Vector3 finishPos, int chunksCount)
    {
        levelInfo.Information = new LevelInfo.Info(number ,startPos, finishPos, chunksCount);
    }

}
