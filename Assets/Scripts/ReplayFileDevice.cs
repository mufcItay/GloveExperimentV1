using CommonTools;
using System;

namespace JasHandExperiment
{
    /// <summary>
    /// the cass represents the device of reading from saved glove data (a replay of previous Active experiment)
    /// </summary>
    public class ReplayFileDevice : BaseHandMovementFileDevice
    {
        #region Data Members

        /// <summary>
        /// saves last datetime of updated coordinates to stay insync with file
        /// </summary>
        DateTime mLastCoordinatesUpdated = DateTime.MinValue;

        /// <summary>
        /// how many milli seconds to wait for applying line read to hand coordinates
        /// </summary>
        double mTimeToWaitTillApplyingUpdateMsec = 0;

        /// <summary>
        /// stores next line to be read when time is right and update coordinates
        /// </summary>
        string[] mNextLineToUpdate;

        /// <summary>
        /// stores the datetime for the next update of coordinates
        /// </summary>
        DateTime mNextLineDateTime;

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

        public override IHandData GetHandData()
        {
            DateTime lastDT;
            string[] currentLine;
            // calculate if it's time for new read line
            double timeSinceLastUpdateMsec = (DateTime.Now - mLastCoordinatesUpdated).TotalMilliseconds;
            if (timeSinceLastUpdateMsec > mTimeToWaitTillApplyingUpdateMsec)
            {
                // if first read, actually read otherwise get next line the was previously read
                currentLine = (mNextLineToUpdate == null) ? mCSVFile.ReadLine() : mNextLineToUpdate;
                // if end of file
                if (currentLine == null)
                {
                    base.GetHandData();
                }
                lastDT = DateTime.Parse(currentLine[CommonConstants.TIME_COL_INDEX]);
                OnCoordinatesUpdate(currentLine);
                mNextLineToUpdate = mCSVFile.ReadLine();
                mNextLineDateTime = DateTime.Parse(mNextLineToUpdate[CommonConstants.TIME_COL_INDEX]);
                mTimeToWaitTillApplyingUpdateMsec = (mNextLineDateTime - lastDT).TotalMilliseconds;
                mLastCoordinatesUpdated = DateTime.Now;
            }
            return base.GetHandData();
        }


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