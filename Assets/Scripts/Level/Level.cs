using UnityEngine;

[System.Serializable]
public struct Level
{
    public GameObject prefab;
    public int chunksCount;
    public bool isRandom;

    public Level(int midChunksCount, bool isRandomLevel, GameObject levelPrefab)
    {
        chunksCount = midChunksCount;
        isRandom = isRandomLevel;
        prefab = levelPrefab;
    }
}

