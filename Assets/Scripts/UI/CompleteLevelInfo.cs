using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompleteLevelInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private LevelInfo info;

    public void ShowText()
    {
        text.text = string.Format("Level {0} complete!", info.Information.number);
    }
}
