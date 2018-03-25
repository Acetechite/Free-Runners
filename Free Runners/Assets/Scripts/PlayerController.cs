using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public SpriteRenderer spriteRen;
	public Sprite late;
	public Sprite perfect;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collisionInfo){
		spriteRen.sprite = perfect;
		if (collisionInfo.gameObject.tag == "Late") {
			spriteRen.sprite = late;
		}
			
	}
}
