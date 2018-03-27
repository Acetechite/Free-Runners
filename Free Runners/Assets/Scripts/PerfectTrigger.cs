using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectTrigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.GetComponent<PlayerController> ().pointsToAdd = gameObject.GetComponentInParent<QuickMove> ().points;
		col.gameObject.GetComponent<PlayerController> ().state = "perfect";
	}
}
