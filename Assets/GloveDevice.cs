using CommonTools;
using FDTGloveUltraCSharpWrapper;
using UnityEngine;

namespace TestGame
{
    public class GlovesDevice : IHandMovementDevice
    {
        CfdGlove mGlove;
        HandCoordinates mCoordinates;
        CSVFile mWriteFile;

        public void Close()
        {
            mGlove.Close();
            mWriteFile.Close();
        }

        public IHandData GetHandData()
        {
            float[] scaledSensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            mGlove.GetSensorScaledAll(ref scaledSensors);

            mCoordinates.SetHandMovementData(scaledSensors);

            mWriteFile.WriteLine(scaledSensors);
            return mCoordinates;
        }

        public void Open()
        {
            mGlove = new CfdGlove();
            try
            {
                mGlove.Open(CommonUtilities.GetGloveUSBPort());
                //mGlove.Open("USB0");

            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
            mCoordinates = new HandCoordinates();
            mWriteFile = new CSVFile();
            string path = ConfigurationManager.Instance.Configuration.OutputFilesConfiguration.GloveMovementLogPath;
            var columns = CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType);
            var settings = new BatchCSVRWSettings();
            settings.WriteBatchSize = 1000;
            settings.WriteBatchDelayMsec = 1000 * 20;
            mWriteFile.Init(path, ',', columns, settings);
        }
    }
}