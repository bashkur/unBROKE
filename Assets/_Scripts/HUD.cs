using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject gameMgr;
    public GameObject canvas;
    Text timeText;
    TimerScript timerScript;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("HUD");
        timerScript = gameMgr.GetComponent<TimerScript>();
        timeText = canvas.transform.GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "" + timerScript.minLeft() + ":" + timerScript.secLeft();
    }

    public void UpdateDamage(float ratio)
    {
        var bar = canvas.transform.GetChild(0).localScale;
        bar.y = ratio;
        canvas.transform.GetChild(0).localScale = bar;
    }
}
