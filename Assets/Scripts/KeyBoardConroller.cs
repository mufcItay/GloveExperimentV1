using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasHandExperiment.Configuration;
using JasHandExperiment;
using System;
using CommonTools;
using System.IO;
using System.Globalization;

public class KeyBoardConroller : MonoBehaviour {

    Animator keyBoard;
    BaseHandMovementFileDevice mDevice;
    CSVFile mWriteFile; 
    HandType handSide;
    int pressedInput;

    //just fot debug:
    int blue = 0;
    int green = 0;
    int yellow = 0;
    int red = 0;
   

	// Use this for initialization
	void Start () {
        keyBoard = GetComponent<Animator>();
        handSide = ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;

        var exType = ConfigurationManager.Instance.Configuration.ExperimentType;
        if (exType == ExperimentType.PassiveSimulation)
        {
            mDevice = HandMovemventDeviceFactory.GetOrCreate(exType) as SimulationFileDevice;
            mDevice.Open();
        }
        else if (exType == ExperimentType.PassiveWatchingReplay)
        {
            mDevice = HandMovemventDeviceFactory.GetOrCreate<KeyBoardSimulationFileDevice>();
            mDevice.Open();
        }
        else if (exType == ExperimentType.Active)
        {
            mWriteFile = new CSVFile();
            var path = CommonUtilities.GetParticipantCSVFileName(ConfigurationManager.Instance.Configuration.OutputFilesConfiguration.UserPressesLogPath);
            // passice cause that's the columns of input n passive
            var columns = CommonUtilities.CreateGlovesDataFileColumns(ExperimentType.PassiveSimulation);
            mWriteFile.Init(new FileStream(path, FileMode.Create), ',', columns);
        }
    }

    public void OnDestroy()
    {
        if (mWriteFile != null)
        {
            mWriteFile.Close();
        }
        if (mDevice != null)
        {
            mDevice.Close();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (ConfigurationManager.Instance.Configuration.ExperimentType != ExperimentType.Active)
        // getting info from file
        {
            //check if there is some key to presse
            KeyPressedData key = mDevice.GetHandData() as KeyPressedData;
            if (key == null || string.IsNullOrEmpty(key.KeyPressed))
            {
                SetAllButtonsOf(); // no data to update according to file
            }
            else
            {
                pressedInput = int.Parse(key.KeyPressed);
                //////////////////ADVA- HAVE TO HANDLE HAND CASES LATER//////////
                if (handSide.Equals(HandType.Right))
                {
                   //we swiched the numbers on the phisical keyBoard
                   pressedInput = 4 - pressedInput + 1;
                   SetPressedButton();
                }
                else if (handSide.Equals(HandType.Left)) // just to avoid the 'none' hand type case
                {
                    SetPressedButton();
                }
            }
        }
        else if (ConfigurationManager.Instance.Configuration.ExperimentType == ExperimentType.Active)
        // getting info directly from keyboard
        {
            SetPressedButton();
        }
    }


    private void SetPressedButton()
    {
        string pressed = string.Empty;
        SetUpButtonsOf();
        if (Input.GetKeyDown(KeyCode.Alpha1) || pressedInput == 1)
        {
            pressed = "1";
            keyBoard.SetInteger("bluePressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || pressedInput == 2)
        {
            pressed = "2";
            keyBoard.SetInteger("yellowPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || pressedInput == 3)
        {
            pressed = "3";
            keyBoard.SetInteger("greenPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || pressedInput ==4)
        {
            pressed = "4";
            keyBoard.SetInteger("redPressed", 1);
        }

        if (!string.IsNullOrEmpty(pressed) && ConfigurationManager.Instance.Configuration.ExperimentType == ExperimentType.Active)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);
            string line = string.Format("{0},{1}", timeStamp,pressed);
            mWriteFile.WriteLine(line);
        }
    }

    private void SetUpButtonsOf()
    {
        pressedInput = 0;
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            keyBoard.SetInteger("bluePressed", 0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            keyBoard.SetInteger("yellowPressed", 0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            keyBoard.SetInteger("greenPressed", 0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            keyBoard.SetInteger("redPressed", 0);
        }
    }

    private void SetAllButtonsOf()
    {
        pressedInput = 0;
        keyBoard.SetInteger("bluePressed", 0);
        keyBoard.SetInteger("yellowPressed", 0);   
        keyBoard.SetInteger("greenPressed", 0);
        keyBoard.SetInteger("redPressed", 0);
    }
}
