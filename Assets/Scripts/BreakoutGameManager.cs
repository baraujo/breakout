using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutGameManager : MonoBehaviour
{
    // UI
    [Header("UI")]
    public GameObject titleCanvas;
    public GameObject victoryCanvas;
    public GameObject gameOverCanvas;

    // Game objects
    [Header("Game objects")]
    public PlayerController playerController;
    public BallController ballController;
    public BrickWallController brickWallController;

    [Header("Game parameters")]
    public int lives;

    private int currentLives;
    private bool isGameRunning;

    void Start()
    {
        SetupTitleScreen();
        currentLives = lives;
        isGameRunning = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            if (!isGameRunning) {
                titleCanvas.SetActive(false);
                isGameRunning = true;
                playerController.isGameRunning = true;
                ballController.isGameRunning = true;
            }
            else 
            {
                SceneManager.LoadScene(0);
            }
        }

        // Detect if ball passed the bottom of the screen
        if (ballController.transform.position.y < ballController.bottomScreenLimit) {
            ballController.ResetBallPosition();
            currentLives -= 1;
        }

        // Defeat condition
        if(currentLives == 0) {
            playerController.isGameRunning = false;
            ballController.isGameRunning = false;
            SetupGameOverScreen();
        }

        // Victory condition
        if(ballController.destroyedBricks == brickWallController.brickCount)
        {
            playerController.isGameRunning = false;
            ballController.isGameRunning = false;
            SetupVictoryScreen();
        }
    }

    private void SetupVictoryScreen()
    {
        titleCanvas.SetActive(false);
        victoryCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    private void SetupTitleScreen()
    {
        titleCanvas.SetActive(true);
        victoryCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    private void SetupGameOverScreen()
    {
        titleCanvas.SetActive(false);
        victoryCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
