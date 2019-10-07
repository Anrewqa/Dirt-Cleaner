using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    void Update()
    {
        scoreText.text = ScoreTracker.Score.ToString();
    }
}
