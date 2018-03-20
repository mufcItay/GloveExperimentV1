using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textManager : MonoBehaviour {
	public Text text;

	private int i = 1;
	private string st ;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       // text.text = (i++).ToString();
		if (Input.GetKeyDown (KeyCode.Space))
			text.text = (i++).ToString ();
 
    }

	void getKeyBoardInput(bool flag,int input){
		if (flag == true)
			text.text += input.ToString ();
	}
}
