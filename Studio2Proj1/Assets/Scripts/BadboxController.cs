using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadboxController : MonoBehaviour {

    public float randGo;
    public float randPoint;
    public float randFriend;

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
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Lose");
    }

    public void RandGoFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            randGo = 100;
            randPoint = Random.Range(1, 5);
            randFriend = Random.Range(1, 4);
        }
        if (randGo >= 0.2)
        {
            randGo = Random.Range(0.1f, 100f);
        }
        else if (randGo < 0.2)
        {
            randGo = 0.1f;
        }
    }
}
