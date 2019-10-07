using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform enter;
    [SerializeField] private Transform exit;
    public Vector3 ExitPosition { get { return exit.position; } }
    [SerializeField] private Transform checkpoint;
    public Vector3 CheckpointPosition { get { return checkpoint.position; } }

    public Vector3 GetChunkCenter()
    {
        return (exit.position - enter.position)/2;
    }

    public Vector3 GetChunkLength()
    {
        return (exit.position - enter.position);
    }


}
