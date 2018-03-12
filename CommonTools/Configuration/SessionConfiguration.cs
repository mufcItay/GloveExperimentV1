using System.Configuration;

namespace CommonTools
{
    /// <summary>
    /// the class contains data of a session in the experiment
    /// </summary>
    public class SessionConfiguration
    {
        #region Consts
        private const uint DEFAULT_NUMBER = 1;

        #endregion

        #region Properties
        /// <summary>
        /// the number of the session
        /// </summary>
        [ConfigurationProperty("Session Number", DefaultValue = DEFAULT_NUMBER)]
        [Validator(IsRequiered = true)]
        public uint Number { get; set; }

        /// <summary>
        /// the amout of sleep hours before current session
        /// </summary>
        public uint SleepHours { get; set; }

        #endregion

        #region Ctor
        public SessionConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        } 
        #endregion
    }
}