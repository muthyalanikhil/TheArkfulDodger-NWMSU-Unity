using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {
        GameObject textObj = GameObject.FindGameObjectWithTag("score");
        txt = textObj.GetComponent<Text>();
        txt.text = currentscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.collider.tag == "meteor")
        {
            txt.text = Convert.ToInt32(currentscore++).ToString();
        }
    }
}
