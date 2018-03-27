﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasHandExperiment.Configuration;
using JasHandExperiment;
using System;

public class KeyBoardConroller : MonoBehaviour {

    Animator keyBoard;
    string input;
    int pressedInput;
    int lastPressedInput;
    HandType handSide;

    //itay
    SimulationFileDevice mDevice;
	// Use this for initialization
	void Start () {

        //itay
        var exType = ConfigurationManager.Instance.Configuration.ExperimentType;
        if (exType == ExperimentType.PassiveSimulation)
        {
            mDevice = HandMovemventDeviceFactory.GetOrCreate(exType) as SimulationFileDevice;
            mDevice.Open();
        }
        

        ///////////////ADVA//////////////// remove the comeent after sinchronize with itays code
        // check wich animated hand we would like to move
        keyBoard = GetComponent<Animator>();
        handSide = HandType.Left;//ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;

    }

// Update is called once per frame
   void Update () {
        //input = Input.inputString;
        //if (keyBoard.GetInteger("pressedButton")== lastPressedInput)
        //{
        //    keyBoard.SetInteger("pressedButton", -1);
        //}
        if (ConfigurationManager.Instance.Configuration.ExperimentType == ExperimentType.PassiveSimulation)
        {
            KeyPressedData key = mDevice.GetHandData() as KeyPressedData;
            int pressedInput = int.Parse(key.KeyPressed);
            if (handSide.Equals(HandType.Right))
            {
                //we swiched the numbers on the phisical keyBoard
                pressedInput = 4 - pressedInput + 1;
                keyBoard.SetInteger("pressedButton", pressedInput);
                lastPressedInput = pressedInput;

                Debug.Log(DateTime.Now.Second + ":" + DateTime.Now.Millisecond + " KEYBOARD");
            }
            else if (handSide.Equals(HandType.Left)) // just to avoid the 'none' hand type case
            {
                keyBoard.SetInteger("pressedButton", pressedInput);
                lastPressedInput = pressedInput;

                Debug.Log(DateTime.Now.Second + ":" + DateTime.Now.Millisecond + " KEYBOARD");
            }
            return;
        }
        input = Input.inputString;
        if (input != "")
        {
            int inputNum;
            if (int.TryParse(input,out inputNum))
            {
                pressedInput = inputNum;
                if (pressedInput >= 1 && pressedInput <= 4)
                {
                    if (handSide.Equals(HandType.Right))
                    {
                        //we swiched the numbers on the phisical keyBoard
                        pressedInput = 4 - pressedInput + 1;
                        keyBoard.SetInteger("pressedButton", pressedInput);
                        lastPressedInput = pressedInput;
                        Debug.Log("right hand, pressed input = " + pressedInput.ToString());
                    }
                    else if (handSide.Equals(HandType.Left)) // just to avoid the 'none' hand type case
                    {
                        keyBoard.SetInteger("pressedButton", pressedInput);
                        lastPressedInput = inputNum;

                        Debug.Log("right hand, pressed input = " + pressedInput.ToString());
                    }
                }
            }
        }
        //else
        //{
        //    pressedInput = -1;
        //    keyBoard.SetInteger("pressedButton", pressedInput);
        //    if (lastPressedInput != pressedInput)
        //    {

        //        Debug.Log("nothink pressed, pressed input = " + pressedInput.ToString());
        //    }
        //    lastPressedInput = pressedInput;
            
        //}
        //else
        //{
        //    keyBoard.SetInteger("pressedButton", -1);
        //}
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using JasHandExperiment.Configuration;
//using JasHandExperiment;
//using System;

//public class KeyBoardConroller : MonoBehaviour {

//    Animator keyBoard;
//    string input;
//    int pressedInput;
//    int lastPressedInput;
//    HandType handSide;

//    // Use this for initialization
//	void Start () {
//        ///////////////ADVA//////////////// remove the comeent after sinchronize with itays code
//        // check wich animated hand we would like to move
//        keyBoard = GetComponent<Animator>();
//        handSide = HandType.Left;//ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;

//    }

//// Update is called once per frame
//   void Update () {
//        //input = Input.inputString;
//        //if (keyBoard.GetInteger("pressedButton")== lastPressedInput)
//        //{
//        //    keyBoard.SetInteger("pressedButton", -1);
//        //}
//        input = Input.inputString;
//        if (input != "")
//        {
//            int inputNum;
//            if (int.TryParse(input,out inputNum))
//            {
//                pressedInput = inputNum;
//                if (pressedInput >= 1 && pressedInput <= 4)
//                {
//                    if (handSide.Equals(HandType.Right))
//                    {
//                        //we swiched the numbers on the phisical keyBoard
//                        pressedInput = 4 - pressedInput + 1;
//                        keyBoard.SetInteger("pressedButton", pressedInput);
//                        lastPressedInput = pressedInput;
//                        Debug.Log("right hand, pressed input = " + pressedInput.ToString());
//                    }
//                    else if (handSide.Equals(HandType.Left)) // just to avoid the 'none' hand type case
//                    {
//                        keyBoard.SetInteger("pressedButton", pressedInput);
//                        lastPressedInput = inputNum;

//                        Debug.Log("right hand, pressed input = " + pressedInput.ToString());
//                    }
//                }
//            }
//        }
//        //else
//        //{
//        //    pressedInput = -1;
//        //    keyBoard.SetInteger("pressedButton", pressedInput);
//        //    if (lastPressedInput != pressedInput)
//        //    {

//        //        Debug.Log("nothink pressed, pressed input = " + pressedInput.ToString());
//        //    }
//        //    lastPressedInput = pressedInput;
            
//        //}
//        //else
//        //{
//        //    keyBoard.SetInteger("pressedButton", -1);
//        //}
//    }
//}
