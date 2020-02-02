using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectScript : MonoBehaviour
{
    // HitPoints for object to break
    private int health;
    public int maxHealth;
    /*
    // Total time to fully repair object
    public float fixTime;
    */
    // Boolean for the state of the object
    private bool isBroken;

    private GameObject gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isBroken = false;
        // Assumption object has broken mesh as 1st child of the object. Make sure it's off
        this.transform.GetChild(0).gameObject.SetActive(false);

        gameStateManager = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public function players can call in order to damage the object, given an amount that defaults to 1
    public int damage(int amount = 1)
    {
        health -= amount;
        if(health <= 0)
        {
            health = 0;
            isBroken = true;
            switchStates();
        }
        return health;
    }
    //getter for health
    public int GetHealth()
    {
        return health;
    }
    // Public function players can call in order to heal the object
    public void heal(int amount = 1)
    {
        if(health <= 0)
        {
            isBroken = false;
            switchStates();
        }
        // Only heal if it needs healed
        if(health < maxHealth)
        {
            health += amount;
        }
        // Cap heal to maxHealth
        if(health > maxHealth)
        {
            health = maxHealth;
        }

    }

    public bool isDestroyed()
    {
        return isBroken;
    }

    // Switching between the visual states of the object between together and broken.
    // This assumes the broken mesh is a child, and the fixed mesh is the mesh component of this
    private void switchStates()
    {
        if(isBroken)
        {
            this.transform.GetComponent<MeshRenderer>().enabled = false;
            this.transform.GetChild(0).gameObject.SetActive(true);
            gameStateManager.gameObject.GetComponent<autoBreak>().addFixed();
        }
        else
        {
            this.transform.GetComponent<MeshRenderer>().enabled = true;
            this.transform.GetChild(0).gameObject.SetActive(false);
            gameStateManager.gameObject.GetComponent<autoBreak>().addBroke();
        }
    }
}
