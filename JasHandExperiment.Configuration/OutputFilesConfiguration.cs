using CommonTools;
using System.ComponentModel;
using System.Configuration;

namespace JasHandExperiment.Configuration
{
    /// <summary>
    /// class that contains data for the output files in an experiment
    /// </summary>
    public class OutputFilesConfiguration
    {
        #region Consts

        /// <summary>
        /// the name of the folder to store user presses logs at
        /// </summary>
        public const string USER_PRESSES_FOLDER = "UserPresses";

        /// <summary>
        /// the name of the folder to store glove movements logs at
        /// </summary>
        public const string GLOVE_MOVEMENTS_FOLDER = "GloveMovements";
        
        #endregion

        #region Properties
        /// <summary>
        /// path for the file where user presses data is saved
        /// </summary>
        [ConfigurationProperty("User Presses Log Path", DefaultValue = USER_PRESSES_FOLDER  + @"\Presses.csv")]
        public string UserPressesLogPath { get; set; }

        /// <summary>
        /// path for the file where configuration data is saved
        /// </summary>
        public string ConfigurationFilePath { get; set; }

        /// <summary>
        /// path for the file where glove movement data is saved
        /// </summary>
        [ConfigurationProperty("Glove Movement Log Path", DefaultValue = GLOVE_MOVEMENTS_FOLDER + @"\Movemenvts.csv")]
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