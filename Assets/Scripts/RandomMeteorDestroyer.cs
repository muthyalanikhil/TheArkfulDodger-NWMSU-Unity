using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMeteorDestroyer : MonoBehaviour {

    public GameObject meteorDestroyPoint;

	// Use this for initialization
	void Start () {
        meteorDestroyPoint = GameObject.Find("randomMeteorDestroyer");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < meteorDestroyPoint.transform.position.x || transform.position.y < meteorDestroyPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
