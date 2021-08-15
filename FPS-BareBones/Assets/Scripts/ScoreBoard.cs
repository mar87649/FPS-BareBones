using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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


    public int UpdateScore(int amount)
    {
        Score += amount;
        ScoreText.text = Score.ToString();
        GameManager.Instance.Score = Score;
        return Score;
    }

}
