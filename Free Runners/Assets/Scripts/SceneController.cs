﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneSwitch(string sceneName)
    {
        if(sceneName == "PlayGame")
        {
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if(sceneName == "Settings")
        {

        }
    }
}