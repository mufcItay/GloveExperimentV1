using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasHandExperiment.Configuration;

public class redButtonText : MonoBehaviour {

    HandType handSide;

    // Use this for initialization
    void Start()
    {
        handSide = HandType.Right;//ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;
        string num = "0";
        if (handSide.Equals(HandType.Left))
        {
            num = "4";
        }
        else if (handSide.Equals(HandType.Right))
        {
            num = "1";
        }
        TextMesh yelloeText = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        yelloeText.text = num;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
