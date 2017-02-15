using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadboxController : MonoBehaviour {

    public float randGo;
    public float randPoint;
    public float randFriend;
    public float AaronAnnoyance;
    public float TravisAnnoyance;
    public float WayneAnnoyance;

    // Use this for initialization
    void Start () {
        randPoint = Random.Range(1, 5);
        randGo = 100;
        randFriend = Random.Range(1,4);
    }
	
	// Update is called once per frame
	void Update ()
    {
        RandGoFunction();
        if (Time.timeSinceLevelLoad == 300)
        {
            //You Win
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Lose");
    }

    public void RandGoFunction()
    {
        if (randGo > 1)
        {
            randGo = Random.Range(1, 1001);
            randPoint = Random.Range(1, 5);
            randFriend = Random.Range(1, 4);
        }
        else if (randGo <= 1)
        {
            randGo = 1;
            AnnoyFriend();
        }
    }

    public void AnnoyFriend()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(randFriend == 1)
            {
                AaronAnnoyance++;
            }
            if(randFriend == 2)
            {
                TravisAnnoyance++;
            }
            if(randFriend == 3)
            {
                WayneAnnoyance++;
            }
        }
    }
}
