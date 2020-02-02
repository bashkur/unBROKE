using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject gameMgr;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("HUD");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDamage(float ratio)
    {
        var bar = canvas.transform.GetChild(0).localScale;
        bar.y = ratio;
        canvas.transform.GetChild(0).localScale = bar;
    }
}
