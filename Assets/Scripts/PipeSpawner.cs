using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float minSpawnRate = 0.8f;
    public float spawnRateDecreaseAmount = 0.1f;
    public int scoreThreshold = 100;
    public float pipeMinHeight = -1f;
    public float pipeMaxHeight = 3f;
    public float pipeSpawnXPosition = 10f;
    public float pipeGap = 2f;

    private float timer = 0f;
    private List<GameObject> pipes = new List<GameObject>();

    private ScoreManager scoreManager;
    private int lastScoreCheckpoint = 0;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        CheckForSpawnRateIncrease();

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void CheckForSpawnRateIncrease()
    {
        if (scoreManager != null)
        {
            int currentScore = scoreManager.GetScore();

            if (currentScore >= lastScoreCheckpoint + scoreThreshold)
            {
                if (spawnRate > minSpawnRate)
                {
                    spawnRate -= spawnRateDecreaseAmount;
                    spawnRate = Mathf.Max(spawnRate, minSpawnRate);
                    Debug.Log("Spawn rate increased! Current spawn rate: " + spawnRate);
                }

                lastScoreCheckpoint += scoreThreshold;
            }
        }
    }

    void SpawnPipe()
    {
        float randomYPosition = Random.Range(pipeMinHeight, pipeMaxHeight);

        GameObject newPipe = Instantiate(pipePrefab, new Vector3(pipeSpawnXPosition, randomYPosition, 0), Quaternion.identity);

        pipes.Add(newPipe);
    }

    public void ResetPipes()
    {
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }

        pipes.Clear();
    }
}
