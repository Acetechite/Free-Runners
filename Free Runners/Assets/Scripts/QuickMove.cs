﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMove : MonoBehaviour {

	public float speed;
	public int points;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(PlayerPrefs.GetInt("Pause") == 0)
		    transform.position = new Vector3 (transform.position.x - 1f*Time.deltaTime, transform.position.y, transform.position.z);
	}
}
