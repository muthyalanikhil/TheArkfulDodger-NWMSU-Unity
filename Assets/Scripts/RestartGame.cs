using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RestartGame : MonoBehaviour {

    // Use this for initialization
    public void onClick()
    {
        // Save game data

        // Close game
        Debug.Log("Application Paused");
        Application.LoadLevel(0);
    }
}
