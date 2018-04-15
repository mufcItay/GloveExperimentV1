
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
    HandType handToAnimate; //side of hand show on screen
    HandType activeHand = HandType.Left;// side of hand the participent uses (on active mode only), set left as default
    int pressedInput;
    string lastDTUpdated;  

	// Use this for initialization
	void Start () {
        // get keyboard component from unity
        keyBoard = GetComponent<Animator>();
        //ask configuration which hand will show up on screnn 
        handToAnimate = ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;

        var exType = ConfigurationManager.Instance.Configuration.ExperimentType;
        if (exType == ExperimentType.PassiveSimulation)
        {
            //read from input file as passive simulatiom
            mDevice = HandMovemventDeviceFactory.GetOrCreate(exType) as SimulationFileDevice;
            mDevice.Open();
        }
        else if (exType == ExperimentType.PassiveWatchingReplay)
        {
            //read from input file as passive watching replay
            mDevice = HandMovemventDeviceFactory.GetOrCreate<KeyBoardSimulationFileDevice>();
            mDevice.Open();
        }
        else if (exType == ExperimentType.Active)
        {
            //ask configuration which hand is activly typing right now
            activeHand = HandType.Left; ///////////ADVA- CHANGE IT TOCODE THAT ASKS THE CONFIGURATION
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
            if (key == null || string.IsNullOrEmpty(key.KeyPressed)|| key.TimeStamp.Equals(lastDTUpdated))
            {
                SetAllButtonsOf(); // no data to update according to file
            }
            else
            {
                lastDTUpdated = key.TimeStamp;
                pressedInput = int.Parse(key.KeyPressed);
                if (handToAnimate.Equals(HandType.Right))
                {
                   //we swiched the numbers on the phisical keyBoard
                   SetPressedButton();
                }
                else if (handToAnimate.Equals(HandType.Left)) // just to avoid the 'none' hand type case
                {
                    SetPressedButton();
                }
            }
        }
        else if (ConfigurationManager.Instance.Configuration.ExperimentType == ExperimentType.Active)
        // getting info directly from keyboard
        {
            SetUpButtonsOf();
            SetPressedButton();
        }
    }


    private void SetPressedButton()
    {
        string pressedFinger = string.Empty;
       // SetUpButtonsOf();
        //the diffrence between handeling right hand and left hand is only 
        //in the data that been writing to file, so it is relavent only to active mode
        if (activeHand.Equals(HandType.Left))
        {
            pressedFinger = setUsingLeftHand(pressedFinger);
        }
        else if (activeHand.Equals(HandType.Right))
        {
            pressedFinger = setUsingRightHand(pressedFinger);
        }
        // writing to file
        if (!string.IsNullOrEmpty(pressedFinger) && ConfigurationManager.Instance.Configuration.ExperimentType == ExperimentType.Active)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);
            string line = string.Format("{0},{1}", timeStamp,pressedFinger);
            mWriteFile.WriteLine(line);
        }
    }

    private string setUsingRightHand(string pressedFinger)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || pressedInput == 1)
        {
            pressedFinger = "4";
            keyBoard.SetInteger("bluePressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || pressedInput == 2)
        {
            pressedFinger = "3";
            keyBoard.SetInteger("yellowPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || pressedInput == 3)
        {
            pressedFinger = "2";
            keyBoard.SetInteger("greenPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || pressedInput == 4)
        {
            pressedFinger = "1";
            keyBoard.SetInteger("redPressed", 1);
        }

        return pressedFinger;
    }

    private string setUsingLeftHand(string pressedFinger)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || pressedInput == 1)
        {
            pressedFinger = "1";
            keyBoard.SetInteger("bluePressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || pressedInput == 2)
        {
            pressedFinger = "2";
            keyBoard.SetInteger("yellowPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || pressedInput == 3)
        {
            pressedFinger = "3";
            keyBoard.SetInteger("greenPressed", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || pressedInput == 4)
        {
            pressedFinger = "4";
            keyBoard.SetInteger("redPressed", 1);
        }

        return pressedFinger;
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
