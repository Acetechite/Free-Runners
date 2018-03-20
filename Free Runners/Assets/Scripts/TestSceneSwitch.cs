using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TestSceneSwitch : MonoBehaviour {

    public Button button;
    // Use this for initialization
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Settings);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Settings() {
        SceneManager.LoadScene("Controls",LoadSceneMode.Additive);
    }

}
