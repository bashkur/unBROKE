using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       int thing = PlayerPrefs.GetInt("DID I WIN?");
       if (thing==1)
        {
            this.transform.GetChild(4).GetComponent<Text>().enabled = true;

        }
       else
        {
            this.transform.GetChild(4).GetComponent<Text>().enabled = false;
        }
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
