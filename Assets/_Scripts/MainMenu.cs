﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_game()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void character_select()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void quit_game()
    {
        Application.Quit();
    }
}
