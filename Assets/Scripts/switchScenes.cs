using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScenes : MonoBehaviour {
    private int counter;
	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            counter++;
        }
		if (Input.GetKeyDown (KeyCode.R) || counter == 30) {
            counter = 0;
			SceneManager.LoadScene ("restScene");
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			SceneManager.LoadScene ("testRoom");
		}

	}
}
