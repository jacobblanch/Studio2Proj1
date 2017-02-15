using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject mygameObject;
    public Rigidbody rb;
    BadboxController badScript;
    float currFriends = 3;

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
        if (Input.GetMouseButtonDown(0))
        {
            ResetGlobalVar();
        }
    }

    public void Annoyed()
    {
        if (badScript.AaronAnnoyance >= 20)
        {
            if (mygameObject.tag == "Aaron")
            {
                target = GameObject.FindGameObjectWithTag("PL");
            }
        } else if (badScript.TravisAnnoyance >= 20)
        {
            if (mygameObject.tag == "Travis")
            {
                target = GameObject.FindGameObjectWithTag("PL");
            }
        } else if (badScript.WayneAnnoyance >= 20)
        {
            if (mygameObject.tag == "Wayne")
            {
                target = GameObject.FindGameObjectWithTag("PL");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PL")
        {
            Destroy(this.gameObject);
            currFriends--;
        }
        if(other.tag != "Player")
        {
            ResetGlobalVar();
        }
        ReturnToOrigin();
    }

    public void Patrolling()
    { 
        if(badScript.AaronAnnoyance < 20 && badScript.TravisAnnoyance < 20 && badScript.WayneAnnoyance < 20)
        {
            if (badScript.randGo == 1)
            {
                if (badScript.randFriend == 1)
                {
                    if (mygameObject.tag == "Aaron")
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
                else if (badScript.randFriend == 2)
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
                }
                else if (badScript.randFriend == 3)
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
            }
            else if (badScript.randGo > 1)
            {
                ReturnToOrigin();
            }
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

    public void ResetGlobalVar()
    {
        badScript.randGo = 100;
        badScript.randPoint = Random.Range(1, 4);
        badScript.randFriend = Random.Range(1, 4);
    }
}
