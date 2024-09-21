using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;
    public float scoreInterval = 0.05f;

    private float timer = 0f;
    private bool isGameActive = true;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateScoreText();
        UpdateHighScoreText();
    }

    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;

            if (timer >= scoreInterval)
            {
                AddScore(1);
                timer = 0f;
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        score = 0;
        timer = 0f;
        UpdateScoreText();

        isGameActive = true;
    }

    public int GetScore()
    {
        return score;
    }

    public void StopScore()
    {
        isGameActive = false;
    }

    public void StartScore()
    {
        isGameActive = true;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
