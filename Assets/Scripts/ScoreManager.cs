using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public static float score = 0;
    public Text ScoreText;

    void Update()
    {
        ScoreText.text = score.ToString();
        ScoreText.text = "Score: " + Math.Round(score, 0);
    }
}