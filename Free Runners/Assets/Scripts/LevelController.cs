using System.Collections;
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
	public GameObject steelBar;
    public GameObject flag;

	GameObject item;

	// Use this for initialization
	void Start () {



        tempCSV = PlayerPrefs.GetString("ActiveLevel");
        Debug.Log(tempCSV);
        string[] tempCSVSplit = tempCSV.Split(',');

        levelObj = new GameObject[tempCSVSplit.Length];

        startPos = new Vector3(0.71f, -0.305f, 0f);

		prefabPaths = new GameObject[] { nullObj, hurdle, pylon, steelBar, flag };
        
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
