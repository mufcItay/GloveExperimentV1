using CommonTools;
using FDTGloveUltraCSharpWrapper;
using JasHandExperiment.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using static HandController;
using static JasHandExperiment.ExperimentManager;

namespace JasHandExperiment
{
    /// <summary>
    /// The class represents the device that reads from 5DT glove.
    /// the clas writes read data to a CSV file
    /// </summary>
    public class GlovesDevice : IHandMovementDevice
    {
        #region Constants
        
        /// <summary>
        /// the name of the port glove port to connect to.
        /// </summary>
        private const string GLOVE_PORT_NAME = "USB0";
        
        #endregion

        #region Data Members
        /// <summary>
        /// the glove instance to read from
        /// </summary>
        CfdGlove mGlove;

        /// <summary>
        /// the current coordinates of the hand according to the glove sensors
        /// </summary>
        HandCoordinatesData mCoordinates;

        /// <summary>
        /// the file to write the data to
        /// </summary>
        CSVFile mWriteFile;

        #endregion

        #region Functions

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public void Close()
        {
            mGlove.Close();
            mGlove = null;
            if (mWriteFile != null)
            {
                mWriteFile.Close();
            }
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public IHandData GetHandData()
        {
            float[] scaledSensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            mGlove.GetSensorScaledAll(ref scaledSensors);

            // set current state
            mCoordinates.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);
            mCoordinates.SetHandMovementData(scaledSensors);
            if (CalibrationManager.Mode == HandPlayMode.RealTime)
            {
                WriteCoordinatesToFile(scaledSensors, mCoordinates.TimeStamp);
            }
            
            return mCoordinates;
        }


        /// <summary>
        /// The function performs in place scaling of sensors
        /// </summary>
        /// <param name="rawSensors">the raw sensor values</param>
        /// <param name="max">the maximum sensor value of snsors to scale according to</param>
        /// <param name="min">the minimum sensor value of snsors to scale according to</param>
        private float[] ScaleRawData(ushort[] rawSensors, ushort[] max, ushort[] min)
        {
            float[] scaledSensors = new float[rawSensors.Length];
            for (int i = 0; i < rawSensors.Length; i++)
            {
                float denom = (max[i] - min[i]);
                int nominator = (rawSensors[i] - min[i]);
                if (denom == 0 || nominator < 0)
                {
                    scaledSensors[i] = 0;
                    continue;
                }

                scaledSensors[i] = (nominator / denom);
            }
            return scaledSensors;
        }

        /// <summary>
        /// The function gets timestamp and sensors and writes them to file (by mWriterFile)
        /// </summary>
        /// <param name="scaledSensors">the current sensors to write to file</param>
        /// <param name="timeStamp">the time stamp of these scaled sensors</param>
        private void WriteCoordinatesToFile(float[] scaledSensors, string timeStamp)
        {
            // attach time stampt to sensors
            string[] fullLine = new string[scaledSensors.Length + 1];
            int valueIndex = 0;
            fullLine[valueIndex] = mCoordinates.TimeStamp;
            foreach (var sensorValue in scaledSensors)
            {
                valueIndex++;
                fullLine[valueIndex] = sensorValue.ToString();
            }
            //write to file
            mWriteFile.WriteLine(fullLine);
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public bool Open()
        {
            // avoid re creating glove if it is already creted
            if (mGlove != null)
            {

                Debug.Log("trying to open glove which was already initialized");
                return false;
            };
            // try to open glove
            mGlove = new CfdGlove();
            CalibrationManager.Init(mGlove, CalibrationManager.Mode);
            // before starting the glove device we need to fill calibration values
            try
            {
                // check for connected USBS and search for the glove port
                mGlove.Open(GLOVE_PORT_NAME);
                CalibrationManager.SetCalibration();
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
                return false;
            }
            mCoordinates = new HandCoordinatesData();
            if (CalibrationManager.Mode == HandPlayMode.RealTime)
            {
                // write sensors data to file only on real time
                mWriteFile = new CSVFile();
                string path = CommonUtilities.GetParticipantCSVFileName(ConfigurationManager.Instance.Configuration.OutputFilesConfiguration.GloveMovementLogPath);
                var columns = CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType);
                var settings = new BatchCSVRWSettings();
                settings.WriteBatchSize = 1000;
                // interval?
                settings.WriteBatchDelayMsec = 1000 * 5;
                // init the file to write to
                mWriteFile.Init(path, FileMode.Create, ',', columns, settings);

            }
            return true;
        }
        
        #endregion
    }
}