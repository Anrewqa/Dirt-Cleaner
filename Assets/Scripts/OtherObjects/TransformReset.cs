using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReset : MonoBehaviour
{
    Vector3 position;
    Quaternion rotation;
    Vector3 scale;

    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;

    }

    public void ResetTransform()
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }
}
