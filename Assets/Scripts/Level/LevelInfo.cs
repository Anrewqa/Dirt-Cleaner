using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Info information;
    public Info Information { get { return information; } set { information = value; } }

    public struct Info
    {
        public int number;
        Vector3 startPos;
        Vector3 finishPos;
        int chunksCount;
        public float lenght;

        public Info(int levelNumber,  Vector3 start, Vector3 finish, int chunksCountInt)
        {
            number = levelNumber;
            startPos = start;
            finishPos = finish;
            chunksCount = chunksCountInt;
            lenght = finishPos.z - startPos.z;
        }
    }
}
