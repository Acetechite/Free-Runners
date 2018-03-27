﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public string tempCSV;
    public Vector3 startPos;
    public float spacing;

	public Text scoreValue;
	int scoreValueInt;

    public GameObject[] prefabPaths;
    public GameObject[] levelObj;
    public GameObject nullObj;
    public GameObject hurdle;
    public GameObject pylon;

	GameObject item;

	// Use this for initialization
	void Start () {
        tempCSV = "0,1,1,2,1,2,2";
        string[] tempCSVSplit = tempCSV.Split(',');

        levelObj = new GameObject[tempCSVSplit.Length];

        startPos = new Vector3(0.71f, -0.305f, 0f);

		prefabPaths = new GameObject[] { nullObj, hurdle, pylon };
        
        int count = 0;
        foreach(string s in tempCSVSplit)
        {
            levelObj[count] = prefabPaths[int.Parse(s)];
			count++;
        }


        int i = 0;
        
        foreach (GameObject s in levelObj)
        {
            if (s != null)
            {
				item = (GameObject)Instantiate(s, new Vector3(startPos.x + (spacing * i), startPos.y, startPos.z), transform.rotation);
            }
            i++;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GainPoints(int value){
		int temp = int.Parse (scoreValue.text);
		scoreValue.text = (temp + value).ToString ();
	}
}
