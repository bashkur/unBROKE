using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    private Transform playerTransform;
    public int player;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.transform.GetChild(0).GetChild(PlayerPrefs.GetInt("P"+player+"CharacterSelected"));

        playerTransform.parent = null;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
