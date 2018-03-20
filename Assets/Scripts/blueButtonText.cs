using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasHandExperiment.Configuration;

public class blueButtonText : MonoBehaviour {

    HandType handSide;

	// Use this for initialization
	void Start () {
        handSide = HandType.Right;//ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;
        string num = "0";
        if (handSide.Equals(HandType.Left))
        {
            num = "1";
        }
        else if (handSide.Equals(HandType.Right))
        {
            num = "4";
        }
        TextMesh blueText = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        blueText.text = num;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
