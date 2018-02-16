using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isPlayerMoving;
    SpriteRenderer playerFlip;
    Animator animatorObject;
    public float moveSpeed;
    Rigidbody2D rigidBodyObject;
    public float jump;
    public bool isOnGround = false;
    public int health = 3;
    int countRefill = 0;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        if (health == 0 || health < 0)
        {
            Destroy(gameObject);
        }
        animatorObject = gameObject.GetComponent<Animator>();
        rigidBodyObject = GetComponent<Rigidbody2D>();
        playerFlip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (hori > 0.0f)
        {
            playerFlip.flipX = false;
            animatorObject.SetBool("isMoving", true);
        }

        if (hori < 0.0f)
        {
            playerFlip.flipX = true;
            animatorObject.SetBool("isMoving", true);
        }

        if (hori == 0.0f)
        {
            animatorObject.SetBool("isMoving", false);
        }

        if (gameObject.transform.position.y + 3 < GameObject.Find("ground").transform.position.y)
        {
            GameObject.Find("dodger").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverAudio").GetComponent<AudioSource>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidBodyObject.AddForce(Vector3.right * moveSpeed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rigidBodyObject.AddForce(Vector3.left * moveSpeed);
        }


        if (Input.GetKey(KeyCode.W) && isOnGround)
        {
            rigidBodyObject.AddForce(Vector3.up * jump);
            isOnGround = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isOnGround = true;
        }
        if (collision.collider.tag == "refill")
        {
            Destroy(collision.gameObject);
            if (countRefill == 0 && health < 3)
            {
                GameObject.Find("life" + health).GetComponent<Image>().enabled = true;
                health++;
                countRefill++;
            }
        }
        if (collision.collider.tag == "meteor")
        {
            Destroy(collision.gameObject);
            Destroy(Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity), 1);
            GameObject.Find("life" + health).GetComponent<Image>().enabled = false;
            health = health - 1;
            if (health == 0)
            {
                GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
                GameObject.Find("GameOverAudio").GetComponent<AudioSource>().enabled = true;
            }
        }
    }
}
