using System.Collections;
using System.Collections.Generic;
using CommonTools;
using FDTGloveUltraCSharpWrapper;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using JasHandExperiment.Configuration;
using System;

namespace JasHandExperiment
{

    public class textManager : MonoBehaviour
    {
		public Text squence;
		public Text stars;
        CSVFile mReadFile;
        private bool flag;
        private float timer;
        string lastDTUpdated;

        //file
        BaseHandMovementFileDevice mDevice;

        // Use this for initialization
        void Start()
        {
            lastDTUpdated = DateTime.MinValue.ToLongTimeString();
            squence.text = ConfigurationManager.Instance.Configuration.Squence;
            timer =  ConfigurationManager.Instance.Configuration.SubRuns[0].BlockDuration;
			stars.text = "";

            //file
            var exType = ConfigurationManager.Instance.Configuration.ExperimentType;
            if (exType == ExperimentType.PassiveSimulation)
            {
                mDevice = HandMovemventDeviceFactory.GetOrCreate(exType) as SimulationFileDevice;
                mDevice.Open();
            }
            if (exType == ExperimentType.PassiveWatchingReplay)
            {
                mDevice = HandMovemventDeviceFactory.GetOrCreate<KeyBoardSimulationFileDevice>();
                mDevice.Open();
            }
        }


        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("restScene");
            }

            if (needToUpdateText())
            {
				stars.text += "*";
            }
            
        }

        public void OnDestroy()
        {
            if (mDevice !=null)
            {
                mDevice.Close();
            }
        }

        bool needToUpdateText()
        {
            switch (ConfigurationManager.Instance.Configuration.ExperimentType)
            {
                case ExperimentType.Active:
                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
                  Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
                        return true;

                    break;
                case ExperimentType.PassiveSimulation:
                case ExperimentType.PassiveWatchingReplay:
                    KeyPressedData key = mDevice.GetHandData() as KeyPressedData;
                    if (key != null && !string.IsNullOrEmpty(key.KeyPressed))
                    {
                        if (key.TimeStamp.Equals(lastDTUpdated))
                        {
                            return false;
                        }
                        lastDTUpdated = key.TimeStamp;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}