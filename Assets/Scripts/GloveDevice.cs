using CommonTools;
using FDTGloveUltraCSharpWrapper;
using JasHandExperiment.Configuration;
using System;
using System.Globalization;
using System.IO;
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
        
        /// <summary>
        /// the name of the port glove port to connect to.
        /// </summary>
        private const string GLOVE_PORT_NAME = "USB0";

        // right hand calibration values
        private readonly ushort[] RIGHT_CALIB_UPPER_VALS = { 3386, 3173, 3538, 3661, 3758, 3944, 3839, 3778, 3561, 3277, 3848, 3933, 3530, 3733, 0, 0, 2048, 2048 };
        private readonly ushort[] RIGHT_CALIB_LOWER_VALS = { 3274, 3100, 3294, 3524, 3237, 3847, 3774, 3505, 3406, 3217, 3531, 3882, 3454, 3497, 0, 0, 2048, 2048 };
        
        // left glove calibration values
        private readonly ushort[] LEFT_CALIB_UPPER_VALS = { 3689, 3380, 3705, 3347, 3964, 3857, 3779, 3716, 3920, 3278, 3964, 3931, 3637, 3350, 0, 0, 2048, 2048 };
        private readonly ushort[] LEFT_CALIB_LOWER_VALS = { 3487, 3146, 3370, 3114, 3451, 3449, 3628, 3222, 3789, 3096, 3559, 3759, 3390, 3200, 0, 0, 2048, 2048 };
        
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
            mCoordinates.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);
            mCoordinates.SetHandMovementData(scaledSensors);
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
                mGlove.Open(GLOVE_PORT_NAME);
                CalibrateGlove(CommonUtilities.GetGloveSide());
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
            mWriteFile.Init(path, FileMode.Create,',', columns, settings);
            return false;
        }

        /// <summary>
        /// The function sets aclibration values to glove
        /// </summary>
        private void CalibrateGlove(HandType gloveSide)
        {
            if (gloveSide == HandType.Left)
            {
                mGlove.SetCalibrationAll(LEFT_CALIB_UPPER_VALS, LEFT_CALIB_LOWER_VALS);
            }
            else
            {
                mGlove.SetCalibrationAll(RIGHT_CALIB_UPPER_VALS, RIGHT_CALIB_LOWER_VALS);
            }
        }
    #endregion
}
}