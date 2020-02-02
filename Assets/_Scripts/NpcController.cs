using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    Transform[] rooms;
    [SerializeField]
    Transform destination;
    int roomIndex = 0;

    [SerializeField]
    bool isRoaming = true;
    [SerializeField]
    bool isSearching = false;
    [SerializeField]
    bool isDestroying = false;

    [SerializeField]
    int damageRate = 0; // damage to deal to object per second

    NavMeshAgent agent;

    GameObject targetObject;

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
        print(Vector3.Distance(transform.position, destination.position)); // OMIT

        // NPC reached target (and is not currently destroying one)
        if (!isDestroying && Vector3.Distance(destination.position, transform.position) < 0.5)
        {
            print("Reached target"); // OMIT

            // roaming house
            if (isRoaming)
            {
                SetDestination(); // continue roaming
            }
            // searching object to destroy (moving towards one)
            else if (isSearching)
            {
                isSearching = false;
                isDestroying = true;

                // BreakObject(); // break object NPC was "hunting"
                print("Break object");

                SetDestination(); // move to a room
            }
        }
    }

    private void SetDestination(Transform dest = null)
    {
        print("Set destination");

        // go to given position
        if (dest != null)
        {
            destination = dest;
        }
        else
        {
            // choose random room to navigate to
            int randomRoom = 0;
            do
            {
                randomRoom = Random.Range(0, rooms.Length - 1);
            }
            while (randomRoom == roomIndex);

            destination = rooms[randomRoom];
            roomIndex = randomRoom;

            print(randomRoom);
        }

        agent.SetDestination(destination.position);

        print(destination.position);
    }

    private IEnumerator BreakObject()
    {
        // break object code
        print("Start breaking object"); // OMIT

        yield return StartCoroutine("BreakingObject");

        isDestroying = false;
        isRoaming = true;
    }

    private IEnumerator BreakingObject()
    {
        BreakableObjectScript breakObj = targetObject.GetComponent<BreakableObjectScript>();

        while (!breakObj.isDestroyed())
        {
            breakObj.damage(damageRate);

            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // interactable item in range
        if (other.tag == "Breakable")
        {
            print("Detected object"); // OMIT
            BreakableObjectScript breakableObj = other.GetComponent<BreakableObjectScript>();

            // check if item is not yet broken
            if (!breakableObj.isDestroyed() && isRoaming)
            {
                print("Going to break object"); // OMIT
                SetDestination(other.transform);

                targetObject = other.gameObject;
                isSearching = true;
            }
        }
    }
}
