using CommonTools;

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
        #endregion
    }
}