using CommonTools;
using FDTGloveUltraCSharpWrapper;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// The class represents the device that reads from 5DT glove.
    /// the clas writes read data to a CSV file
    /// </summary>
    public class GlovesDevice : IHandMovementDevice
    {
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
            mCoordinates.SetHandMovementData(scaledSensors);
            //write to file
            mWriteFile.WriteLine(scaledSensors);
            return mCoordinates;
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public bool Open()
        {
            if (mGlove == null)
            {
                return false;
            }
            // try to open glove
            mGlove = new CfdGlove();
            try
            {
                // check for connected USBS and search for the glove port
                mGlove.Open(CommonUtilities.GetGloveUSBPort());
                //mGlove.Open("USB0");

            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
                return false;
            }
            mCoordinates = new HandCoordinatesData();
            mWriteFile = new CSVFile();
            string path = ConfigurationManager.Instance.Configuration.OutputFilesConfiguration.GloveMovementLogPath;
            var columns = CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType);
            var settings = new BatchCSVRWSettings();
            settings.WriteBatchSize = 1000;
            // interval?
            settings.WriteBatchDelayMsec = 1000 * 20;
            // init the file to write to
            mWriteFile.Init(path, ',', columns, settings);
            return false;
        } 
        #endregion
    }
}