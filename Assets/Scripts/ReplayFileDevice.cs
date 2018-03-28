using CommonTools;
using System;

namespace JasHandExperiment
{
    /// <summary>
    /// the cass represents the device of reading from saved glove data (a replay of previous Active experiment)
    /// </summary>
    public class ReplayFileDevice : BaseHandMovementFileDevice
    {
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
        /// <param name="lines">the lines read from file</param>
        protected override void OnCoordinatesUpdate(string[] lines)
        {
            
            // trim off the date time
            string[] trimmedLines = new string[lines.Length - 1];
            Array.Copy(lines, CommonConstants.TIME_COL_INDEX + 1, trimmedLines, 0,trimmedLines.Length);

            // invoke data handler
            mData.SetHandMovementData(trimmedLines);
            var coordinatesData = mData as HandCoordinatesData;
            if (coordinatesData != null)
            {
                coordinatesData.TimeStamp = lines[CommonConstants.TIME_COL_INDEX] = DateTime.Now.ToLongTimeString();
            }
            else
            {
                //error
            }
        }
        #endregion
    }
}