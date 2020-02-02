using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [SerializeField]
    Transform[] breakableObjects;
    [SerializeField]
    Transform target;

    int lastTarget = 0;

    GameObject gameObj;

    bool isDestroying;

    [SerializeField]
    int damageRate = 0; // damage to deal to object per second

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            SetDestination();
        }
        isDestroying = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SetDestination(Transform dest = null)
    {
        print("Set Destination"); // OMIT

        // pick random, unbroken object
        int randomObj;
        do
        {
            randomObj = Random.Range(0, breakableObjects.Length);
        }
        while (randomObj == lastTarget);

        target = breakableObjects[randomObj];
        lastTarget = randomObj;
        agent.SetDestination(target.position);
    }

    IEnumerator BreakObject()
    {
        // break object code
        print("Start breaking object"); // OMIT

        BreakableObjectScript breakObj = gameObj.GetComponent<BreakableObjectScript>();
        if (!breakObj.isDestroyed())
        {
            yield return StartCoroutine("BreakingObject");
        }

        isDestroying = false;

        SetDestination();
    }

    IEnumerator BreakingObject()
    {
        BreakableObjectScript breakObj = gameObj.GetComponent<BreakableObjectScript>();

        while (!breakObj.isDestroyed())
        {
            breakObj.damage(damageRate);
            print("Hit"); // OMIT

            yield return new WaitForSeconds(1);
        }
        print("Destroyed"); // OMIT
    }

    private void OnTriggerEnter(Collider other)
    {
        // interactable item in range
        if (!isDestroying && other.gameObject.tag == "Breakable")
        {
            if (gameObj == null || other.gameObject != gameObj)
            {
                isDestroying = true;
                gameObj = other.gameObject;

                print("Detected object"); // OMIT

                StartCoroutine("BreakObject");
            }
        }
    }
}
