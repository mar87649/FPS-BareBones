using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public TMP_Text ScoreText { get => scoreText; private set => scoreText = value; }
    public int Score { get; set; }
    private void Start()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
    }

    public int SetScore(int score)
    {
        Score = score;
        ScoreText.text = Score.ToString();
        GameManager.Instance.Score = Score;
        return Score;
    }
    public int IncrementScore(int amount)
    {
        Score += amount;
        ScoreText.text = Score.ToString();
        GameManager.Instance.Score = Score;
        return Score;
    }

    public int ResetScore()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
        GameManager.Instance.Score = Score;
        return Score;
    }



}
