using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestGame
{
    public abstract class BaseHandMovementFileDevice : IHandMovementDevice
    {
        protected string mFileName;
        protected CSVFile mCSVFile;
        protected object mLock;

        protected IHandData mData;

        public BaseHandMovementFileDevice()
        {
            mLock = new object();
        }

        public void Close()
        {
            mCSVFile.Close();
        }

        public IHandData GetHandData()
        {
            lock (mLock)
            {
                return mData.Clone() as IHandData;
            }
        }

        public abstract string GetFileName();
        public abstract IHandData CreateHandMovementData();
        
        public void Open()
        {
            mFileName = GetFileName();
            mData = CreateHandMovementData();
            mCSVFile = new CSVFile();
            BatchCSVRWSettings settings = new BatchCSVRWSettings();
            settings.ReadBatchDelayMsec = 120; // ????
            //settings.ReadBatchDelayMsec = (1 / ConfigurationManager.Instance.Configuration.PressFrequency); // ????
            settings.ReadBatchSize = 1;
            try
            {
                mCSVFile.Init(mFileName, CommonConstants.CSV_SEPERATOR, CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType),settings);
            }            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                return;
            }
            mCSVFile.OnLinesReady += OnLinesReady;
            mCSVFile.ReadLines();
        }

        private void OnLinesReady(IEnumerable<string[]> obj)
        {
            lock (mLock)
            {
                OnCoordinatesUpdate(obj.First());
            }
        }

        protected virtual void OnCoordinatesUpdate(string[] lines)
        {
            mData.SetHandMovementData(lines);
        }
    }
}
