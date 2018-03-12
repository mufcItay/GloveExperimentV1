using System.ComponentModel;
using System.Configuration;

namespace CommonTools
{
    /// <summary>
    /// class that contains data for the output files in an experiment
    /// </summary>
    public class OutputFilesConfiguration
    {
        #region Properties
        /// <summary>
        /// path for the file where user presses data is saved
        /// </summary>
        [ConfigurationProperty("User Presses Log Path", DefaultValue = @"UserPresses\Presses.csv")]
        public string UserPressesLogPath { get; set; }

        /// <summary>
        /// path for the file where configuration data is saved
        /// </summary>
        public string ConfigurationFilePath { get; set; }

        /// <summary>
        /// path for the file where glove movement data is saved
        /// </summary>
        [ConfigurationProperty("Glove Movement Log Path", DefaultValue = @"GloveMovements\Movemenvts.csv")]
        public string GloveMovementLogPath { get; set; }

        #endregion

        #region Ctor
        public OutputFilesConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        } 
        #endregion
    }
}