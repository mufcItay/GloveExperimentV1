﻿using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// abstract calss the represents hand movement information from a file.
    /// implements IHandMovementDevice by assuming the data is from a file.
    /// </summary>
    public abstract class BaseHandMovementFileDevice : IHandMovementDevice
    {
        #region Data Members
        /// <summary>
        /// The name of the fie to read data from
        /// </summary>
        protected string mFileName;

        /// <summary>
        /// the CSVFile to read hand data from
        /// </summary>
        protected CSVFile mCSVFile;

        /// <summary>
        /// lock for synchronizatino between file reader thread and other functions.
        /// </summary>
        protected object mLock;

        /// <summary>
        /// saves current hand data
        /// </summary>
        protected IHandData mData;
        #endregion

        #region Ctors
        public BaseHandMovementFileDevice()
        {
            mLock = new object();
        }

        #endregion

        #region Functions
        /// <summary>
        /// see interface for documentation
        /// </summary>
        public void Close()
        {
            mCSVFile.Close();
        }

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public IHandData GetHandData()
        {
            lock (mLock)
            {
                // clone to avoid conflicts with other threads
                return mData.Clone() as IHandData;
            }
        }

        /// <summary>
        /// abstract function to get the relevant file name
        /// </summary>
        /// <returns>the path to the file to read from</returns>
        public abstract string GetFileName();

        /// <summary>
        /// The function creates a specific IHandData structure,
        /// that is relevant to this specific hand movement file device
        /// </summary>
        /// <returns>IDandData struncture with data to apply hand movement</returns>
        public abstract IHandData CreateHandMovementData();

        /// <summary>
        /// see interface for documentation
        /// </summary>
        public void Open()
        {
            // save the file params, and open it
            mFileName = GetFileName();
            mData = CreateHandMovementData();
            mCSVFile = new CSVFile();
            BatchCSVRWSettings settings = new BatchCSVRWSettings();
            //settings.ReadBatchDelayMsec = 120; // ????
            settings.ReadBatchDelayMsec = (uint)((1.0 / ConfigurationManager.Instance.Configuration.PressFrequency) * 1000); // ????
            settings.ReadBatchSize = 1;
            try
            {
                mCSVFile.Init(mFileName, CommonConstants.CSV_SEPERATOR, CommonUtilities.CreateGlovesDataFileColumns(ConfigurationManager.Instance.Configuration.ExperimentType), settings);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                return;
            }
            // subscribe to lines ready
            mCSVFile.OnLinesReady += OnLinesReady;
            // start reading from file
            mCSVFile.ReadLines();
        }

        /// <summary>
        /// handler for lines ready event
        /// </summary>
        /// <param name="obj">the lines read from file</param>
        private void OnLinesReady(IEnumerable<string[]> obj)
        {
            lock (mLock)
            {
                // lines are ready, react to them according to implementation of absract function OnCoordinatesUpdate
                // we take first cause we read one line at a time in this device
                OnCoordinatesUpdate(obj.First());
            }
        }

        /// <summary>
        /// virutal function with basic lines ready reaction
        /// </summary>
        /// <param name="lines">the lines read from file</param>
        protected virtual void OnCoordinatesUpdate(string[] lines)
        {
            // invoke data handler
            mData.SetHandMovementData(lines);
        } 
        #endregion
    }
}