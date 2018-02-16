using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {

    public GameObject platformDestroyPoint;

	// Use this for initialization
	void Start () {
        platformDestroyPoint = GameObject.Find("groundDestroyPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDestroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
