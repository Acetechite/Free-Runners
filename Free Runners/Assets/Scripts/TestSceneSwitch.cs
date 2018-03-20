using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TestSceneSwitch : MonoBehaviour {

    public Button settings;
    // Use this for initialization
    void Start () {
		//Button settings = settingsButton.GetComponent<Button> ();
		settings.onClick.AddListener(Settings);
		Debug.Log ("Hellodsdsdsd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Settings() {
		Debug.Log ("Hello");
    }

}
