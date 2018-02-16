using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundGenerator : MonoBehaviour {

    public GameObject ground;
    public Transform generationPoint;
    private float width;
    public float widthBetweenGrounds;
    public float secondsBetweenSpawns = 5;
    float nextSpawnTime = 0;
    public GameObject refill;
    public GameObject rocket;

    // Use this for initialization
    void Start () {
        width = ground.GetComponent<BoxCollider2D>().size.x;
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + width + widthBetweenGrounds, transform.position.y, transform.position.z);
            Instantiate(ground, transform.position, Quaternion.identity);
        }
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + 5;
            transform.position = new Vector3(transform.position.x + Random.Range(0,5), transform.position.y, transform.position.z);
            Instantiate(refill, transform.position, Quaternion.identity);
        }
        if (Time.time == 30)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(rocket, transform.position, Quaternion.identity);
            GameObject.Find("YouWon").GetComponent<Text>().enabled = true;
            GameObject.Find("WonAudio").GetComponent<AudioSource>().enabled = true;
        }
    }
}
