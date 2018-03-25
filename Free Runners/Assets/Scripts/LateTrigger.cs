using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateTrigger : MonoBehaviour {

	public Sprite late;
	// Use this for initialization
	void Start () {
		Debug.Log ("ready");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Trigger Enter");
		col.gameObject.GetComponent<PlayerController> ().spriteRen.sprite = late;

		
	}
}
