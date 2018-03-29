using CommonTools;
using FDTGloveUltraCSharpWrapper;
using System;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// The class represents the device that reads from 5DT glove.
    /// the clas writes read data to a CSV file
    /// </summary>
    public class GlovesDevice : IHandMovementDevice
    {
        #region Constants

        //commented out old calibratino values
        // dfault calibration values, taken from GloveManager app came with 5DT gloves
        //private readonly ushort[] CALIB_UPPER_VALS = { 3261, 2933, 3237, 3120, 3005, 3503, 3444, 3376, 3618, 3126, 3702, 3880, 3884, 3762, 0, 0, 2048, 2048 };
        //private readonly ushort[] CALIB_LOWER_VALS = { 3255, 2924, 3221, 3110, 2996, 3474, 63429, 3367, 3607, 3119, 3696, 3877, 3881, 3758, 0, 0, 2048, 2048 };
        private readonly ushort[] CALIB_UPPER_VALS = { 3334, 3014, 3375, 3135, 3292, 3576, 3449, 3490, 3598, 3126, 3828, 3902, 3778, 3677, 0, 0, 2048, 2048 };
        private readonly ushort[] CALIB_LOWER_VALS = { 3164, 2851, 3146, 3021, 2874, 3277, 3347, 3309, 3333, 3065, 3477, 3828, 3756, 3534, 0, 0, 2048, 2048 };

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
            mWriteFile.Close();
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public IHandData GetHandData()
        {
            float[] scaledSensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            mGlove.GetSensorScaledAll(ref scaledSensors);

            // set current state
            mCoordinates.TimeStamp = DateTime.Now.ToLongTimeString();
            mCoordinates.SetHandMovementData(scaledSensors);
            // attach time stampt to sensors
            string[] fullLine = new string[scaledSensors.Length + 1];
            int valueIndex = 0;
            fullLine[valueIndex] = DateTime.Now.ToLongTimeString();
            foreach (var sensorValue in scaledSensors)
            {
                valueIndex++;
                fullLine[valueIndex] = sensorValue.ToString();
            }
            //write to file
            mWriteFile.WriteLine(fullLine);
            return mCoordinates;
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public bool Open()
        {
            // avoid re creating glove if it is already creted
            if (mGlove != null)
            {
                // error
                return false;
            }

            // try to open glove
            mGlove = new CfdGlove();
            try
            {
                // check for connected USBS and search for the glove port
                mGlove.Open("USB0");//CommonUtilities.GetGloveUSBPort());
                //CalibrateGlove();
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
                return false;
            }
            mCoordinates = new HandCoordinatesData();
            mWriteFile = new CSVFile();
            string path = CommonUtilities.GetParticipantCSVFileName(ConfigurationManager.Instance.Configuration.OutputFilesConfiguration.GloveMovementLogPath);
            var columns = CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType);
            var settings = new BatchCSVRWSettings();
            settings.WriteBatchSize = 1000;
            // interval?
            settings.WriteBatchDelayMsec = 1000 * 5;
            // init the file to write to
            mWriteFile.Init(path, ',', columns, settings);
            return false;
        }

        /// <summary>
        /// The function sets aclibration values to glove
        /// </summary>
        private void CalibrateGlove()
        {
            mGlove.SetCalibrationAll(CALIB_UPPER_VALS, CALIB_LOWER_VALS);
        }
        #endregion
    }
}