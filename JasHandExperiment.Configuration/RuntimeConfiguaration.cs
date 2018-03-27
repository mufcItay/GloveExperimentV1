using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using CommonTools;

namespace JasHandExperiment.Configuration
{
    /// <summary>
    /// The class encapsulates all of the configurable values of an experiment
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class RuntimeConfiguration
    {
        #region Constants

        public const string DEFAULT_MAIN_DIR = "";//@"C:\GloveExperimentV1\";

        /// <summary>
        /// the path to the runtime configuration file
        /// </summary>
        public const string RUNTIME_CONF_FILE_NAME = DEFAULT_MAIN_DIR + "Configuration.xml";

        /// <summary>
        /// the name of the folderto store subject configuration in
        /// </summary>
        public const string DEFAULT_SUBJECTS_CONFIGURATIONS_FOLDER_PATH = DEFAULT_MAIN_DIR + @"Subject Configurations\";

        /// <summary>
        /// the name of the path to folder to store user presses logs at
        /// </summary>
        public const string DEFAULT_USER_PRESSES_FOLDER = DEFAULT_MAIN_DIR;

        /// <summary>
        /// the name of the path to folder to store glove movements logs at
        /// </summary>
        public const string DEFAULT_GLOVE_MOVEMENTS_FOLDER = DEFAULT_MAIN_DIR;

        #endregion

        #region Properties
        /// <summary>
        /// The path to the configuration fiel in subject directory
        /// </summary>
        public string PathToConfigurationFile { get; set; }

        /// <summary>
        /// The path to the directory where subject's configurations are stored
        /// </summary>
        public string PathToSubjectDir { get; set; }
        
        #endregion

        #region Ctor

        public RuntimeConfiguration()
        {
            PathToSubjectDir = DEFAULT_SUBJECTS_CONFIGURATIONS_FOLDER_PATH;
        }

        #endregion
    }
}
