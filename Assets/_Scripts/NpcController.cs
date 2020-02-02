using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    Transform[] rooms;
    Transform destination;

    bool isSearching = true;
    bool isHunting = false;
    bool isBreaking = false;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            SetDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDestination(Transform dest = null)
    {
        // go to given position
        if (dest != null)
        {
            destination = dest;
            agent.SetDestination(destination.position);
        }
        else
        {
            // choose random room to navigate to
            destination = rooms[Random.Range(0, rooms.Length - 1)];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // interactable item in range
        if (other.tag == "Breakable")
        {
            // check if item is not yet broken
            /*
            if (!broken && isSearching) // FIXME
            {
                // break item
            }
            */
        }
    }
}
