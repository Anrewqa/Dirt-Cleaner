using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public void ResetLevel()
    {
        for (int i = 0; i < ObjectsForReset.objects.Count; i++)
        {
            ObjectsForReset.objects[i].GetComponent<TransformReset>().ResetTransform();
            ObjectsForReset.objects[i].GetComponent<DisableTimer>().ResetTimer();
            ObjectsForReset.objects[i].GetComponent<ObjectLauncher>().ResetLauncher();
        }

        ObjectsForReset.objects.Clear();
    }

    public void ClearResetList()
    {
        ObjectsForReset.objects.Clear();
    }
}
