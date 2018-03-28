using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public AudioSource audioSrc;
	public SpriteRenderer playerSprite;
	public Animator playerAnimator;

	public LevelController levelMan;

	public SpriteRenderer spriteRen;
	public Sprite late;
	public Sprite perfect;
	public Sprite early;
	public string state;
    public bool isJumping;
	public bool canJump;
	public int pointsToAdd;
    AudioClip earlySound;
	AudioClip perfectSound;
	AudioClip lateSound;
	Sprite playerWalk;
	Sprite playerMiss;
    Sprite playerWin;
	RuntimeAnimatorController playerWalkAnim;
	RuntimeAnimatorController playerMissAnim;
    RuntimeAnimatorController playerWinAnim;

    public GameObject pauseMenu;


	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
		state = "late";
        isJumping = false;
		canJump = true;
		pointsToAdd = 0;

		earlySound = (AudioClip)Resources.Load("sounds/EarlySound");
		perfectSound = (AudioClip)Resources.Load("sounds/PerfectSound");
		lateSound = (AudioClip)Resources.Load("sounds/LateSound");

		playerWalk = Resources.Load<Sprite> ("sprites/PlayerWalk");
		playerMiss = Resources.Load<Sprite> ("sprites/PlayerMiss");
        playerWin = Resources.Load<Sprite>("sprites/PlayerWin");

		playerWalkAnim = Resources.Load<RuntimeAnimatorController> ("sprites/PlayerWalkAnim");
		playerMissAnim = Resources.Load<RuntimeAnimatorController> ("sprites/PlayerMissAnim");
        playerWinAnim = Resources.Load<RuntimeAnimatorController>("sprites/PlayerWinAnim");
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
            isJumping = true;
			if(canJump)
				Jump ();
		}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
	}

	public void Jump(){
		canJump = false;
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
			playerSprite.sprite = playerWin;
			playerAnimator.runtimeAnimatorController = playerWinAnim;
			StartCoroutine (JumpMove ());
			if (pointsToAdd > 0) {
				levelMan.GainPoints (pointsToAdd);
			}
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
        isJumping = false;
		canJump = true;
		state = "late";
		pointsToAdd = 0;
		playerSprite.sprite = playerWalk;
		playerAnimator.runtimeAnimatorController = playerWalkAnim;
		spriteRen.sprite = null;
	}
    IEnumerator JumpMove() {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.07f, transform.position.z);
        yield return new WaitForSeconds(0.8f);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.07f, transform.position.z);
    }
}
