using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoBreak : MonoBehaviour
{
    private int numBroke;
    private int totalNum;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] B_Objects = GameObject.FindGameObjectsWithTag("Breakable");
        totalNum = B_Objects.Length;
        numBroke = 0;

        int numToBreak = 3;
        for(int i = 0; i<numToBreak; i++)
        {
            int itterator = Random.Range(0, B_Objects.Length);
            BreakableObjectScript breakable= B_Objects[itterator].GetComponent<BreakableObjectScript>();
            breakable.damage();
            addBroke();
        }

        this.gameObject.GetComponent<TimerScript>().startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBroke()
    {
        numBroke += 1;
    }

    public void addFixed()
    {
        numBroke -= 1;
    }

    public bool isMoreBroke()
    {
        if(brokeRatio() > 0.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float brokeRatio()
    {
        return numBroke / totalNum;
    }
}
