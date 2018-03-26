using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public SpriteRenderer spriteRen;
	public Sprite late;
	public Sprite perfect;
	public Sprite early;
	public string state;
	// Use this for initialization
	void Start () {
		state = "null";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}
	}

	void Jump(){
		switch (state) {
		case "null":
			break;
		case "late":
			spriteRen.sprite = late;
			break;
		case "perfect":
			spriteRen.sprite = perfect;
			break;
		case "early":
			spriteRen.sprite = early;
			break;
		}
		StartCoroutine (ShowState());
	}

	IEnumerator ShowState(){
		yield return new WaitForSeconds (0.5f);
		spriteRen.sprite = null;
	}
}
