using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadboxController : MonoBehaviour {

    public float randGo;
    public float randPoint;
    public float randFriend;
    public float AaronAnnoyance;
    public float TravisAnnoyance;
    public float WayneAnnoyance;
    public float timeAway;
    public float currFriends = 3;

    // Use this for initialization
    void Start () {
        
        randPoint = Random.Range(1, 5);
        randGo = 100;
        randFriend = Random.Range(1,4);
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerAway();
        RandGoFunction();
        if (Time.timeSinceLevelLoad == 300)
        {
            SceneManager.LoadScene("YouLastedTheVisit");
        }
        if (currFriends == 0)
        {
            SceneManager.LoadScene("YouHaveNoFriends");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            SceneManager.LoadScene("YourFriendsFoundYourDadsSecret");
        }
    }

    public void RandGoFunction()
    {
        if (randGo > 1)
        {
            randGo = Random.Range(1, 1501);
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

    public void PlayerAway()
    {
        if (Vector3.Distance(GameObject.Find("PlayerAnchor").transform.position, GameObject.Find("Player").transform.position) > 2)
        {
            timeAway += Time.deltaTime;
            if (timeAway > 2)
            {
                TravisAnnoyance++;
                WayneAnnoyance++;
                AaronAnnoyance++;
                timeAway = 1;
            }
        } else
        {
            timeAway = 0;
        }
    }
}
