using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment
{
    /// <summary>
    /// Singletine class that provides services for reading from congiguration 
    /// </summary>
    public sealed class ConfigurationManager
    {
        /// <summary>
        /// the path to configuration file
        /// </summary>
        private const string DEFAULT_CONF_FILE_NAME = "Configuration.xml";

        #region Data Members
        /// <summary>
        /// the instance of the singletone
        /// </summary>
        private static readonly ConfigurationManager sInstance = new ConfigurationManager();

        /// <summary>
        /// the configuratino file
        /// </summary>
        private FileRepository mConfigurationFile;

        /// <summary>
        /// The configuration object we are currently working with
        /// </summary>
        private ExperimentConfiguration mConfigurationObject;

        #endregion

        #region Props


        /// <summary>
        /// static Singletne getter - first get will create the manager
        /// </summary>
        public static ConfigurationManager Instance
        {
            get
            {
                return sInstance;
            }
        }

        /// <summary>
        /// getter for configuration object
        /// </summary>
        public ExperimentConfiguration Configuration { get { return mConfigurationObject; } }

        #endregion

        #region Ctors

        // singletone implementation
        static ConfigurationManager()
        {
        }
        private ConfigurationManager()
        {
            mConfigurationFile = new FileRepository();
            mConfigurationFile.Connect(DEFAULT_CONF_FILE_NAME);

            mConfigurationObject = mConfigurationFile.GetObject<ExperimentConfiguration>();
        } 
        #endregion
    }
}
