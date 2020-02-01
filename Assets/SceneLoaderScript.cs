using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    private bool isLeft;
    private bool isRight;
    public void leftReady()
    {
        isLeft = true;
        if(isRight)
        {
            bothReady();
        }
    }

    public void rightReady()
    {
        isRight = true;
        if(isLeft)
        {
            bothReady();
        }
    }

    private void bothReady()
    {

    }
}
