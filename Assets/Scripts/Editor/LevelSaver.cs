using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelBuilder))]
public class LevelSaver : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelBuilder level = (LevelBuilder)target;
        if(GUILayout.Button("Save level"))
        {
            GameObject goToPrefab = level.GetLevel();
            string localPath = "Assets/Levels/" + goToPrefab.name + ".prefab";
            Debug.Log(localPath);
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(goToPrefab, localPath, InteractionMode.UserAction);
        }


        if (GUILayout.Button("Build level"))
        {
            level.BuildLevel();
        }
    }

}
