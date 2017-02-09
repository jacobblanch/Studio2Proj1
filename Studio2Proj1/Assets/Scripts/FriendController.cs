using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject target;
    public float speedincrease = 0.1f;
    public float dist;
    private float nextTarget;
    public GameObject me;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("P1");
        Patrolling();
    }
	
	// Update is called once per frame
	void Update () {
        Patrolling();
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            target = GameObject.FindGameObjectWithTag("P3");
            agent.speed += speedincrease;
        }
    }

    private void OnBecameInvisible()
    {
        target = GameObject.FindGameObjectWithTag("Bad");
    }

    public void Patrolling()
    {
        if (agent.remainingDistance < 2)
        {
            if (me.tag == "Aaron")
            {
                if (target.tag == "P1")
                {
                    target = GameObject.FindGameObjectWithTag("P2");
                }
                else if (target.tag == "P2")
                {
                    target = GameObject.FindGameObjectWithTag("P3");
                }
                else if (target.tag == "P3")
                {
                    target = GameObject.FindGameObjectWithTag("P1");
                }
            }
            if (me.tag == "Travis")
            {
                if (target.tag == "P1")
                {
                    target = GameObject.FindGameObjectWithTag("P3");
                }
                else if (target.tag == "P2")
                {
                    target = GameObject.FindGameObjectWithTag("P1");
                }
                else if (target.tag == "P3")
                {
                    target = GameObject.FindGameObjectWithTag("P2");
                }
            }
            if (me.tag == "Wayne")
            {
                if (target.tag == "P1")
                {
                    target = GameObject.FindGameObjectWithTag("P2");
                }
                else if (target.tag == "P2")
                {
                    target = GameObject.FindGameObjectWithTag("P1");
                }
                else if (target.tag == "P3")
                {
                    target = GameObject.FindGameObjectWithTag("P3");
                }
            }
        }
    }
}
