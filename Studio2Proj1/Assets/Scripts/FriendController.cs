using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject target;
    public float annoyance;
    private float nextTarget;
    public GameObject mygameObject;
    public Rigidbody rb;
    public float thrust = -500f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("P1");
        Patrolling();
    }
	
	// Update is called once per frame
	void Update () {
        Annoyed();
        Patrolling();
        agent.SetDestination(target.transform.position);
    }

    private void OnBecameInvisible()
    {
        target = GameObject.FindGameObjectWithTag("Bad");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.AddForce(transform.forward * thrust);
                if (mygameObject.tag == "Aaron")
                {
                    target = GameObject.FindGameObjectWithTag("P3");
                    if (agent.remainingDistance <= 0.5)
                    {
                        Patrolling();
                    }
                } else if (mygameObject.tag == "Travis")
                {
                    target = GameObject.FindGameObjectWithTag("P2");
                    if (agent.remainingDistance <= 0.5)
                    {
                        Patrolling();
                    }
                } else if (mygameObject.tag == "Wayne")
                {
                    target = GameObject.FindGameObjectWithTag("P1");
                    if (agent.remainingDistance <= 0.5)
                    {
                        Patrolling();
                    }
                }
                annoyance += 1;
            }
        } if (other.gameObject.tag == "Bad")
        {
            Debug.Log("You Lose");
        }
    }

    public void Annoyed()
    {
        if (annoyance >= 20)
        {
            target = GameObject.FindGameObjectWithTag("PL");
            if (agent.remainingDistance <= 0.5)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Patrolling()
    {
        if (agent.remainingDistance < 2)
        {
            if (mygameObject.tag == "Aaron")
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
            if (mygameObject.tag == "Travis")
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
            if (mygameObject.tag == "Wayne")
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
