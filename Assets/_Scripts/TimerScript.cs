using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    private int timeTotalMinutes;
    private float timeInSeconds;
    private bool StartTimer;
    private bool TimerDone;

    private GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        timeTotalMinutes = PlayerPrefs.GetInt("TimerMinutes");
        timeInSeconds = timeTotalMinutes * 60;
        TimerDone = false;
        StartTimer = true;

        // Get HUD in order to call functions there to set time
        hud = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        if(!TimerDone && StartTimer)
        {
            timeInSeconds -= Time.deltaTime;
            /*
            //GUI.transform.GetChild(MIN_TEXT_CHILD).GetComponent<Text>().text = minLeft();

            //GUI.transform.GetChild(SECONDS_TEXT_CHILD).GetComponent<Text>().text = secLeft();

            SEND MESSAGE TO HUD TO UPDATE TIME!
            */
            if (timeInSeconds <= 0)
            {
                TimerDone = true;
                // Check if whether or not there are more broken things in the house than non-broken
                if(this.gameObject.GetComponent<autoBreak>().isMoreBroke())
                {
                    print("YOU LOST");
                    //hud.transform.GetChild(2).GetComponent<Text>().text = "YOU LOST"
                    PlayerPrefs.SetInt("DID I WIN?", 0);
                    SceneManager.LoadScene(0);
                }
                else
                {
                    print("YOU WON");
                    PlayerPrefs.SetInt("DID I WIN?", 1);
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void startTimer()
    {
        StartTimer = true;
    }

    // Public Function to Set Timer in Minutes, the Options menu need to call on this and it will save the minutes across scenes
    public void setTimer(float minutes)
    {
        PlayerPrefs.SetInt("TimerMinutes", (int)minutes);
        timeTotalMinutes = (int)minutes;

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
