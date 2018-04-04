using CommonTools;
using System;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// the cass represents the device of reading from saved glove data (a replay of previous Active experiment)
    /// </summary>
    public class ReplayFileDevice : BaseHandMovementFileDevice
    {
        #region Data Members
        /// <summary>
        /// reader for the file to read in sync with file
        /// </summary>
        TimedCSVReader mTimedReader;
        #endregion

        #region Functions
        /// <summary>
        /// creates the IHandData relevant to glove data
        /// </summary>
        /// <returns>initial emty data of hand movement </returns>
        public override IHandData CreateHandMovementData()
        {
            return new HandCoordinatesData(new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH]);
        }

        /// <summary>
        /// the Replay confguration element to read from
        /// </summary>
        /// <returns>path to replay file</returns>
        public override string GetFileName()
        {
            return ConfigurationManager.Instance.Configuration.ReplayFilePath;
        }
        
        /// <summary>
        /// override to add tiem stampe
        /// </summary>
        /// <param name="line">the lines read from file</param>
        protected override void OnCoordinatesUpdate(string[] line)
        {
            // trim off the date time
            string[] trimmedLine = new string[line.Length - 1];
            Array.Copy(line, CommonConstants.TIME_COL_INDEX + 1, trimmedLine, 0,trimmedLine.Length);

            // invoke data handler
            mData.SetHandMovementData(trimmedLine);
            var coordinatesData = mData as HandCoordinatesData;
            if (coordinatesData != null)
            {
                coordinatesData.TimeStamp = line[CommonConstants.TIME_COL_INDEX]; ;
            }
            else
            {
                //error
            }
        }

        public override void Init()
        {
            base.Init();

            mTimedReader = new TimedCSVReader(mCSVFile, CommonConstants.TIME_COL_INDEX, 50);
        }

        DateTime firstDT = DateTime.MinValue;
        DateTime firstFileDT = DateTime.MinValue;

        public override IHandData GetHandData()
        {
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

            //if (mTimedReader.mCsvLines.Count == mTimedReader.mCurrentLineIndex && diff.Equals(string.Empty))
            //{
            //        double real = (DateTime.Now - firstDT).TotalMilliseconds;
            //        double file = (DateTime.Parse((mData as HandCoordinatesData).TimeStamp) - firstFileDT).TotalMilliseconds;
            //        diff = (real - file).ToString();
            //    Debug.Log("END Time difference (msec) from beginnig REAL - " + diff);
            //}

            return base.GetHandData();
        }
        string diff = string.Empty;

        /// <summary>
        /// see abstract class for documentation
        /// </summary>
        /// <returns>the read settings for the file</returns>
        public override BatchCSVRWSettings GetReadSettings()
        {
            BatchCSVRWSettings settings = new BatchCSVRWSettings();
            // don't read a batch one line at a time, user dictates speed
            settings.ReadBatchDelayMsec = BatchCSVRWSettings.DEFAULT_READ_DELAY_MSEC; 
            settings.ReadBatchSize = 1;
            return settings;
        }
        #endregion
    }
}