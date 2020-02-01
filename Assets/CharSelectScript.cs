using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectScript : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    public int player;
    private bool canMove;

    void Start()
    {
        canMove = true;
        index = PlayerPrefs.GetInt("P"+player+"CharacterSelected");

        characterList = new GameObject[this.transform.childCount];

        // Fill the array with the Prefabs
        for (int i = 0; i < this.transform.childCount; i++)
        {
            characterList[i] = this.transform.GetChild(i).gameObject;
        }

        // We toggle all of them to inactive
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // Toggle first one on
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }

    }

    public void ToggleLeft()
    {
        if(canMove)
        {
            // Toggle off cur model
            characterList[index].SetActive(false);

            // Update Index
            index--;
            if (index < 0)
            {
                index = characterList.Length - 1;
            }

            // Toggle on cur model
            characterList[index].SetActive(true);

            // Set PlayerPrefs Int, and int that can save across scenes and plays
            PlayerPrefs.SetInt("P" + player + "CharacterSelected", index);

            // Players can't be same character
            if (player == 1)
            {
                if(index == PlayerPrefs.GetInt("P" + (player+1) + "CharacterSelected"))
                {
                    this.ToggleLeft();
                }
            }
            else
            {
                if (index == PlayerPrefs.GetInt("P" + (player - 1) + "CharacterSelected"))
                {
                    this.ToggleLeft();
                }
            }
        }
    }

    public void ToggleRight()
    {
        if(canMove)
        {
            // Toggle off cur model
            characterList[index].SetActive(false);

            // Update Index
            index++;
            if (index >= characterList.Length)
            {
                index = 0;
            }

            // Toggle on cur model
            characterList[index].SetActive(true);

            // Set PlayerPrefs Int, and int that can save across scenes and plays
            PlayerPrefs.SetInt("P" + player + "CharacterSelected", index);

            // Players can't be same character
            if (player == 1)
            {
                if (index == PlayerPrefs.GetInt("P" + (player + 1) + "CharacterSelected"))
                {
                    this.ToggleRight();
                }
            }
            else
            {
                if (index == PlayerPrefs.GetInt("P" + (player - 1) + "CharacterSelected"))
                {
                    this.ToggleRight();
                }
            }
        }
    }

    public void StartButton()
    {
        canMove = false;
        PlayerPrefs.SetInt("P"+player+"CharacterSelected", index);
        //SceneManager.LoadScene(1);
    }
}
