using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] B_Objects = GameObject.FindGameObjectsWithTag("Breakable");
        for(int i = 0; i<3; i++)
        {
            int itterator = Random.Range(0, B_Objects.Length);
            BreakableObjectScript breakable= B_Objects[itterator].GetComponent<BreakableObjectScript>();
            breakable.damage(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
