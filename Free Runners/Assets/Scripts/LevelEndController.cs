using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{

    public SceneController sceneManager;
    public Text completeText;

    // Use this for initialization
    void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneController>();
        completeText = GameObject.FindGameObjectWithTag("Complete").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(BlinkText());
        StartCoroutine(EndLevel());
    }

    IEnumerator BlinkText() {
        while (true)
        {
            completeText.text = "Complete!";
            yield return new WaitForSeconds(0.2f);
            completeText.text = "";
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator EndLevel() {
        yield return new WaitForSeconds(2.5f);
        sceneManager.SceneSwitch("LevelSelect");
    }
}
