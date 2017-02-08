using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject target;
    public float speedincrease = 0.5f;
    public float dist;
    private float nextTarget;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        nextTarget = Random.Range(1, 3);
        Patrolling();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(agent.remainingDistance);
        Patrolling();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            target = GameObject.FindGameObjectWithTag("ReturnPoint");
            agent.speed += speedincrease;
            Debug.Log("Player");
        }
    }

    private void OnBecameInvisible()
    {
        if (true)
        {
            target = GameObject.FindGameObjectWithTag("Bad");
        }
    }

    private void Patrolling()
    {
        Debug.Log(nextTarget);
        if (agent.remainingDistance < 1)
        {
             if (nextTarget == 1)
             {
                 nextTarget = 2;
                 target = GameObject.FindGameObjectWithTag("P1");
                agent.SetDestination(target.transform.position);
            }
            else if (nextTarget == 2)
             {
                nextTarget = 3;
                target = GameObject.FindGameObjectWithTag("P2");
                agent.SetDestination(target.transform.position);
            } 
            else if (nextTarget == 3)
             {
                nextTarget = 1;
                target = GameObject.FindGameObjectWithTag("P3");
                agent.SetDestination(target.transform.position);
            }
        }
    }
}
