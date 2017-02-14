using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject target;
    public float annoyance;
    public GameObject mygameObject;
    public Rigidbody rb;
    public float thrust = -100f;
    BadboxController badScript;

    // Use this for initialization
    void Start () {
        GameObject theBox = GameObject.Find("BAD");
        badScript = theBox.GetComponent<BadboxController>();
        ReturnToOrigin();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        badScript.RandGoFunction();
        Annoyed();
        Patrolling();
        agent.SetDestination(target.transform.position);
    }

    public void Annoyed()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        badScript.randGo = 100;
        badScript.randFriend = Random.Range(1, 4);
        badScript.randPoint = Random.Range(1, 5);
        ReturnToOrigin();
    }

    public void Patrolling()
    { 
        if (badScript.randGo == 0.1f)
        {
            if (badScript.randFriend == 1)
            {
                if (mygameObject.tag == "Aaron")
                {
                    if (badScript.randPoint == 1)
                    {
                        target = GameObject.FindGameObjectWithTag("ToiletPoint");
                    } else if (badScript.randPoint == 2)
                    {
                        target = GameObject.FindGameObjectWithTag("FoodPoint");
                    } else if (badScript.randPoint == 3)
                    {
                        target = GameObject.FindGameObjectWithTag("DrinkPoint");
                    }
                    else if (badScript.randPoint == 4)
                    {
                        target = GameObject.FindGameObjectWithTag("Bad");
                    }
                    
                }
            } else if (badScript.randFriend == 2)
            {
                if (mygameObject.tag == "Travis")
                {
                    if (badScript.randPoint == 1)
                    {
                        target = GameObject.FindGameObjectWithTag("ToiletPoint");
                    }
                    else if (badScript.randPoint == 2)
                    {
                        target = GameObject.FindGameObjectWithTag("FoodPoint");
                    }
                    else if (badScript.randPoint == 3)
                    {
                        target = GameObject.FindGameObjectWithTag("DrinkPoint");
                    }
                    else if (badScript.randPoint == 4)
                    {
                        target = GameObject.FindGameObjectWithTag("Bad");
                    }
                }
            } else if(badScript.randFriend == 3)
            {
                if (mygameObject.tag == "Wayne")
                {
                    if (badScript.randPoint == 1)
                    {
                        target = GameObject.FindGameObjectWithTag("ToiletPoint");
                    }
                    else if (badScript.randPoint == 2)
                    {
                        target = GameObject.FindGameObjectWithTag("FoodPoint");
                    }
                    else if (badScript.randPoint == 3)
                    {
                        target = GameObject.FindGameObjectWithTag("DrinkPoint");
                    }
                    else if (badScript.randPoint == 4)
                    {
                        target = GameObject.FindGameObjectWithTag("Bad");
                    }
                }
            }
        } else if (badScript.randGo > 0.1f)
        {
            ReturnToOrigin();
        }
    }

    public void ReturnToOrigin()
    {
        if (mygameObject.tag == "Aaron")
        {
            target = GameObject.FindGameObjectWithTag("ARP");
        } else if (mygameObject.tag == "Travis")
        {
            target = GameObject.FindGameObjectWithTag("TRP");
        } else if (mygameObject.tag == "Wayne")
        {
            target = GameObject.FindGameObjectWithTag("WRP");
        }
    }
}
