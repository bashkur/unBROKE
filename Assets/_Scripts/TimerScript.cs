﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private int timeTotalMinutes;
    private float timeInSeconds;
    private bool StartTimer;
    private bool TimerDone;

    private GameObject GUI;
    // Start is called before the first frame update
    void Start()
    {
        timeTotalMinutes = PlayerPrefs.GetInt("TimerMinutes");
        timeInSeconds = timeTotalMinutes * 60;
        TimerDone = false;
        StartTimer = true;

        // Get HUD in order to call functions there to set time
        // GUI = GameObject.Find("GUI");
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerDone && StartTimer)
        {
            timeInSeconds -= Time.deltaTime;
            /*
            GUI.transform.GetChild(MIN_TEXT_CHILD).GetComponent<Text>().text = minLeft();

            GUI.transform.GetChild(SECONDS_TEXT_CHILD).GetComponent<Text>().text = secLeft();
            */
            if (timeInSeconds <= 0)
            {
                TimerDone = true;
            }
        }
    }

    public void startTimer()
    {
        StartTimer = true;
    }

    // Public Function to Set Timer in Minutes, the Options menu need to call on this and it will save the minutes across scenes
    public void setTimer(int minutes)
    {
        PlayerPrefs.SetInt("TimerMinutes", minutes);
        timeTotalMinutes = minutes;

    }

    // Below are clunky functions that want the GUI to check this timer and call these functions all the time
    // Would be laggy

    // Public function to get how many full minutes left
    public int minLeft()
    {
        return Mathf.FloorToInt(timeInSeconds / 60);
    }

    // Public function to get the seconds before the current minute ends
    public int secLeft()
    {
        return ((int)timeInSeconds % 60);
    }

    // Get if the Timer is Done
    public bool isTimerUp()
    {
        return TimerDone;
    }
}
