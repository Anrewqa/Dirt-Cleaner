using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private PlayerMover mover;
    [SerializeField] private TextMeshProUGUI currentLevelNumber;
    [SerializeField] private TextMeshProUGUI nextLevelNumber;
    [SerializeField] private Image progressBar;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color completeColor = Color.green;


    private float lenght;
    bool complete = false;
    float defaultFill;

    public UnityEvent levelComplete = new UnityEvent();

    private void Start()
    {
        defaultFill = progressBar.fillAmount;
    }

    void Update()
    {
        if (!complete)
        {
            progressBar.fillAmount = mover.transform.position.z / lenght + defaultFill;
        }
    }

    public void FillBar()
    {
        complete = true;
        progressBar.color = completeColor;
        progressBar.fillAmount = 1;
    }

    public void SignLevelInfo(LevelInfo info)
    {
        lenght = info.Information.lenght;
        currentLevelNumber.text = info.Information.number.ToString();
        nextLevelNumber.text = (info.Information.number+1).ToString();
        complete = false;
        progressBar.color = defaultColor;
    }
}
