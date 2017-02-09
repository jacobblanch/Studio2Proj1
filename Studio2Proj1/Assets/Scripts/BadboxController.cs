using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadboxController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aaron")
        {
            Debug.Log("You Lose");
        }
        if (collision.gameObject.tag == "Travis")
        {
            Debug.Log("You Lose");
        }
        if (collision.gameObject.tag == "Wayne")
        {
            Debug.Log("You Lose");
        }
    }
}
