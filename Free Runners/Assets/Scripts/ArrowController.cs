using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public GameObject playGame;
	public GameObject settings;
	GameObject[] buttonArray;
	public AudioSource audioSrc;

	int arrayPosition;
	bool changePos;
	// Use this for initialization
	void Start () {
		arrayPosition = 0;
		changePos = false;
		buttonArray = new GameObject[] { playGame, settings };
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			arrayPosition--;
			changePos = true;
			if (arrayPosition < 0)
				arrayPosition = buttonArray.Length-1;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			arrayPosition++;
			changePos = true;
			if (arrayPosition >= buttonArray.Length)
				arrayPosition = 0;
		}

		if (changePos) {
			transform.position = new Vector2(transform.position.x, buttonArray [arrayPosition].transform.position.y);
			changePos = false;
			audioSrc.Play();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("Controls", LoadSceneMode.Single);
		}
			
			
	}
}
