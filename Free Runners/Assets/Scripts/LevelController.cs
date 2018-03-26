using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public string tempCSV;
    public Vector3 startPos;
    public float spacing;

    public GameObject[] prefabPaths;
    public GameObject[] levelObj;
    public GameObject nullObj;
    public GameObject hurdle;
    public GameObject pylon;

	// Use this for initialization
	void Start () {
        tempCSV = "0,1";
        string[] tempCSVSplit = tempCSV.Split(',');
        levelObj = new GameObject[tempCSVSplit.Length];

        startPos = new Vector3(0.71f, -0.305f, 0f);


        prefabPaths = new GameObject[] { hurdle, nullObj, pylon };
        /*
        int count = 0;
        foreach(string s in tempCSVSplit)
        {
            levelObj[count] = prefabPaths[Int32.Parse(s)];
        }
        */

        int i = 0;
        
        foreach (GameObject s in prefabPaths)
        {
            if (s.name != "Null")
            {
                GameObject item = (GameObject)Instantiate(s, new Vector3(startPos.x + (spacing * i), startPos.y, startPos.z), transform.rotation);
            }
            i++;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
