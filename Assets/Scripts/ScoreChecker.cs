using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChecker : MonoBehaviour
{
    public static int HighestScore = 0;
    [SerializeField] private Text HighestScoreText;
    private void Start()
    {
        HighestScoreText.text = HighestScore.ToString();
    }
}
