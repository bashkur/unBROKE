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

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public function players can call in order to damage the object, given an amount that defaults to 1
    public void damage(int amount = 1)
    {
        health -= amount;
        if(health <= 0)
        {
            isBroken = true;
            switchStates();
        }
    }

    // Public function players can call in order to heal the object
    public void heal(int amount = 0)
    {
        if(health <= 0)
        {
            isBroken = false;
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

    private void switchStates()
    {

    }
}
