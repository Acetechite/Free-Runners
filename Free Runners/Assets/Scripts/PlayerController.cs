using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public AudioSource audioSrc;
	public SpriteRenderer playerSprite;
	public Animator playerAnimator;

	public SpriteRenderer spriteRen;
	public Sprite late;
	public Sprite perfect;
	public Sprite early;
	public string state;
	AudioClip earlySound;
	AudioClip perfectSound;
	AudioClip lateSound;
	Sprite playerWalk;
	Sprite playerMiss;
	RuntimeAnimatorController playerWalkAnim;
	RuntimeAnimatorController playerMissAnim;

	// Use this for initialization
	void Start () {
		state = "null";

		earlySound = (AudioClip)Resources.Load("sounds/EarlySound");
		perfectSound = (AudioClip)Resources.Load("sounds/PerfectSound");
		lateSound = (AudioClip)Resources.Load("sounds/LateSound");

		playerWalk = Resources.Load<Sprite> ("sprites/PlayerWalk");
		playerMiss = Resources.Load<Sprite> ("sprites/PlayerMiss");

		playerWalkAnim = Resources.Load<RuntimeAnimatorController> ("sprites/PlayerWalkAnim");
		playerMissAnim = Resources.Load<RuntimeAnimatorController> ("sprites/PlayerMissAnim");
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
			audioSrc.PlayOneShot (lateSound);
			playerSprite.sprite = playerMiss;
			playerAnimator.runtimeAnimatorController = playerMissAnim;
			spriteRen.sprite = late;
			break;
		case "perfect":
			audioSrc.PlayOneShot (perfectSound);
			spriteRen.sprite = perfect;
			break;
		case "early":
			audioSrc.PlayOneShot (earlySound);
			playerSprite.sprite = playerMiss;
			playerAnimator.runtimeAnimatorController = playerMissAnim;
			spriteRen.sprite = early;
			break;
		}
		StartCoroutine (ShowState());
	}

	IEnumerator ShowState(){
		yield return new WaitForSeconds (0.8f);
		playerSprite.sprite = playerWalk;
		playerAnimator.runtimeAnimatorController = playerWalkAnim;
		spriteRen.sprite = null;
	}
}
