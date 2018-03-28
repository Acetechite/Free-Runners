using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {


    public string activeLevel;
    public string walkInPark;
    public string constAhead;
    public string hurdleHell;

	// Use this for initialization
	void Start () {
        walkInPark = "0,2,3,2,2,3,3,2,3,3,3,2,2,4";
        constAhead = "3,2,1,2,2,2,1,1,3,2,1,3,1,4";
        hurdleHell = "0,1,1,0,1,1,1,2,1,0,1,1,1,4";

        PlayerPrefs.SetInt("Pause", 0);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneSwitch(string sceneName)
    {
		Debug.Log (sceneName);
        if (sceneName == "PlayGame")
        {
            PlayerPrefs.SetString("ActiveLevel", walkInPark);
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if (sceneName == "LevelSelect")
        {
            SceneManager.LoadScene("LevelSelectScene", LoadSceneMode.Single);
        }
        else if (sceneName == "Settings")
        {

        }
        else if (sceneName == "Back")
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        else if (sceneName == "WalkInThePark")
        {
            PlayerPrefs.SetString("ActiveLevel", walkInPark);
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if (sceneName == "ConstructionAhead")
        {
            PlayerPrefs.SetString("ActiveLevel", constAhead);
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if (sceneName == "HurdleHell")
        {
            PlayerPrefs.SetString("ActiveLevel", hurdleHell);
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if (sceneName == "Resume")
        {

        }
        else if (sceneName == "Restart")
        {
            SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
        }
        else if (sceneName == "StartMenu") {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}
