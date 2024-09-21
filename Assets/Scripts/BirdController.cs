using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapStrength = 5f;
    public float maxPitchDownAngle = -75f;
    public float maxPitchUpAngle = 75f;
    public float pitchSpeed = 3f;

    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool gameIsOver = false;

    public AudioSource jumpSound;
    public GameObject gameOverPanel;

    private PipeSpawner pipeSpawner;
    private ScoreManager scoreManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;

        pipeSpawner = FindObjectOfType<PipeSpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();

        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Flap();
            }

            RotateBird();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.up * flapStrength;

        jumpSound.Play();
    }

    void RotateBird()
    {
        float velocityY = rb.velocity.y;

        float pitchAngle = Mathf.Lerp(maxPitchDownAngle, maxPitchUpAngle, Mathf.InverseLerp(-15f, 5f, velocityY * 2.0f));

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, pitchAngle), pitchSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameIsOver = true;

            //ResetGame();

            scoreManager.StopScore();

            gameOverPanel.SetActive(true);
        }
    }

    public void ResetGame()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;

        pipeSpawner.ResetPipes();

        scoreManager.ResetScore();

        gameOverPanel.SetActive(false);

        gameIsOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }
}
