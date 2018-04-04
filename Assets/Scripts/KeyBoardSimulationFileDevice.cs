using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// the class represents a simulation file device for the keyboard , 
    /// reads from a simulation file the keys that need to be simulated
    /// here as opposed to regular simulation file device we read accordign to timestamps
    /// </summary>
    public class KeyBoardSimulationFileDevice : SimulationFileDevice
    {
        #region Data Members
        /// <summary>
        /// reader for the file to read in sync with file
        /// </summary>
        TimedCSVReader mTimedReader;
        #endregion
        
        /// <summary>
        /// overrides cols function to set columns to passive simulation although we are in Replay cause keyboard needs presses.
        /// </summary>
        public override IEnumerable<string> GetCSVColumns()
        {
            return CommonUtilities.CreateGlovesDataFileColumns(ExperimentType.PassiveSimulation);
        }

        public override void Init()
        {
            base.Init();
            mTimedReader = new TimedCSVReader(mCSVFile, CommonConstants.TIME_COL_INDEX, 0);
        }

        /// <summary>
        /// the simulation confguration element to read from
        /// </summary>
        /// <returns>path to simulation file</returns>
        public override string GetFileName()
        {
            return ConfigurationManager.Instance.Configuration.ReplayUserPressesFilePath;
        }
        
        public override IHandData GetHandData()
        {

            DateTime firstDT = DateTime.MinValue;
            DateTime firstFileDT = DateTime.MinValue;


            string[] line = mTimedReader.ReadLine();
            if (line != null)
            {
                if (firstDT == DateTime.MinValue)
                {
                    firstDT = DateTime.Now;
                }
                if (firstFileDT == DateTime.MinValue)
                {
                    firstFileDT = DateTime.Parse(line[0]);
                }
                OnCoordinatesUpdate(line);
            }
            if (mTimedReader.mCsvLines.Count - 1 == mTimedReader.mCurrentLineIndex && diff.Equals(string.Empty))
            {
                double real = (DateTime.Now - firstDT).TotalMilliseconds;
                double file = (DateTime.Parse((mData as KeyPressedData).TimeStamp) - firstFileDT).TotalMilliseconds;
                diff = (real - file).ToString();
                Debug.Log("END Time difference (msec) from beginnig REAL - " + diff);
            }
            return base.GetHandData();
        }
        string diff = string.Empty;


        /// <summary>
        /// see abstract class for documentation
        /// </summary>
        /// <returns>the read settings for the file</returns>
        public override BatchCSVRWSettings GetReadSettings()
        {
            // here we need to read line by line and not according to press freq
            BatchCSVRWSettings settings = new BatchCSVRWSettings();
            settings.ReadBatchDelayMsec = BatchCSVRWSettings.DEFAULT_READ_DELAY_MSEC;
            settings.ReadBatchSize = 1;
            return settings;
        }
    }
}