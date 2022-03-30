using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// timer countdown 
public class TimerCountdown : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    
    //contdown system 
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            
            //if time is run out game stop
            else
            {
                Debug.Log("Time has run out!");
                Time.timeScale = 0;
                timeRemaining = 0;
                timerIsRunning = false;

            }
        }
    }
    
    //display countdown system through UI
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
}
