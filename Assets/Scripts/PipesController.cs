using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float baseSpeed = 2.5f;
    public float destroyXPosition = -60f;
    public float speedIncreaseAmount = 0.1f;
    public int scoreThreshold = 10;

    private float currentSpeed;
    private ScoreManager scoreManager;
    private int lastScoreCheckpoint = 0;

    void Start()
    {
        currentSpeed = baseSpeed;

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        CheckForSpeedIncrease();

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        if (transform.position.x <= destroyXPosition)
        {
            DestroyPipe();
        }
    }

    void CheckForSpeedIncrease()
    {
        if (scoreManager != null)
        {
            int currentScore = scoreManager.GetScore();

            if (currentScore >= lastScoreCheckpoint + scoreThreshold)
            {
                currentSpeed += speedIncreaseAmount;
                lastScoreCheckpoint += scoreThreshold;
                //Debug.Log("Speed increased! Current speed: " + currentSpeed);
            }
        }
    }

    void DestroyPipe()
    {
        Destroy(gameObject);
    }
}
