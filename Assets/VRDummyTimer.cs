using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VRDummyTimer : MonoBehaviour
{
    
   public TMP_Text uiText;           // For time and result
    public TMP_Text uiDummyCountText;  // For dummy kill count// For the dummy kill count

    private int dummyKillCount = 0;
    private int totalDummies = 5;      // Set this to the total number of dummies
    private float timeLimit = 60f;     // Set the time limit
    private bool isGameOver = false;

    private void Start()
    {
        // Initialize the UI
        uiText.text = "Time Left: " + timeLimit.ToString("F2");
        uiDummyCountText.text = "Dummies Killed: 0";
        
        // Start the timer countdown
        StartCoroutine(TimerCountdown());
    }

    // Method to call when a dummy is killed
    public void DummyKilled()
    {
        if (!isGameOver)
        {
            dummyKillCount++;
            uiDummyCountText.text = "Dummies Killed: " + dummyKillCount.ToString();

            // Check if all dummies are killed
            if (dummyKillCount >= totalDummies)
            {
                GameOver(true);
            }
        }
    }

    // Timer countdown coroutine
    private IEnumerator TimerCountdown()
    {
        while (timeLimit > 0 && !isGameOver)
        {
            timeLimit -= Time.deltaTime;
            uiText.text = "Time Left: " + timeLimit.ToString("F2");
            yield return null;
        }

        if (!isGameOver)
        {
            GameOver(false);
        }
    }

    // Handle game over scenario
    private void GameOver(bool allDummiesKilled)
    {
        isGameOver = true;
        
        if (allDummiesKilled)
        {
            uiText.text = "You Win! All Dummies Killed!";
        }
        else
        {
            uiText.text = "You Lose! Time's Up!";
        }
    }
}
