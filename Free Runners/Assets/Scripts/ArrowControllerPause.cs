using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowControllerPause : MonoBehaviour {

    public GameObject resume;
    public GameObject restart;
    public GameObject levelSelect;
    public GameObject startMenu;

    public GameObject pauseMenu;

    GameObject[] buttonArray;
    public AudioSource audioSrc;

    int arrayPosition;
    bool changePos;
    bool isWaiting;
    GameObject sceneTemp;
    SceneController sceneCtrl;
    Image arrowRender;

    //Sounds
    AudioClip menuMove;
    AudioClip menuSelect;

    // Use this for initialization
    void Start()
    {
        arrayPosition = 0;
        changePos = false;
        isWaiting = false;
        buttonArray = new GameObject[] { resume, restart, levelSelect, startMenu };
        sceneTemp = GameObject.FindGameObjectWithTag("SceneManager");
        sceneCtrl = sceneTemp.GetComponent("SceneController") as SceneController;
        arrowRender = gameObject.GetComponent<Image>();

        transform.position = new Vector2(transform.position.x, buttonArray[0].transform.position.y);

        //Sounds
        menuMove = (AudioClip)Resources.Load("sounds/MenuMove");
        menuSelect = (AudioClip)Resources.Load("sounds/MenuSelect");
    }

    // Update is called once per frame
    void Update()
    {

        if (isWaiting)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrayPosition--;
            changePos = true;
            if (arrayPosition < 0)
                arrayPosition = buttonArray.Length - 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrayPosition++;
            changePos = true;
            if (arrayPosition >= buttonArray.Length)
                arrayPosition = 0;
        }

        if (changePos)
        {
            transform.position = new Vector2(transform.position.x, buttonArray[arrayPosition].transform.position.y);
            changePos = false;
            audioSrc.PlayOneShot(menuMove);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            audioSrc.PlayOneShot(menuSelect);
            if (buttonArray[arrayPosition].name != "Resume")
            {
                StartCoroutine(Flicker());
                StartCoroutine(SelectWait());
            }
            else
            {
                PlayerPrefs.SetInt("Pause", 0);
                pauseMenu.SetActive(false);
            }


        }


    }

    IEnumerator SelectWait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);
        isWaiting = false;
        PlayerPrefs.SetInt("Pause", 0);
        sceneCtrl.SceneSwitch(buttonArray[arrayPosition].name);
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (arrowRender.enabled == true)
            {
                arrowRender.enabled = false;
            }
            else if (arrowRender.enabled == false)
            {
                arrowRender.enabled = true;
            }
        }
    }
}
