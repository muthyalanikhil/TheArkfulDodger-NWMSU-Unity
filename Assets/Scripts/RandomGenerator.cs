using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    public GameObject ground;
    float width = 0;
    public GameObject[] meteors = new GameObject[3];
    public float secondsBetweenSpawns;
    float nextSpawnTime;

    Vector2 screenHalfSize;

    // Use this for initialization
    void Start()
    {
        width = ground.GetComponent<BoxCollider2D>().size.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawnTime)
        {
           
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x,transform.position.x + width),transform.position.y);
            int index = Random.Range(0, 3);
            Instantiate(meteors[index],spawnPosition,Quaternion.identity);
        }
	}
}
