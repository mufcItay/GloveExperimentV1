using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;

namespace TestGame
{
    public sealed class ConfigurationManager
    {
        private const string DEFAULT_CONF_FILE_NAME = "Configuration.xml";

        private static readonly ConfigurationManager sInstance = new ConfigurationManager();

        private FileRepository mConfigurationFile;
        private ExperimentConfiguration mConfigurationObject;

        public ExperimentConfiguration Configuration { get { return mConfigurationObject; }  }

        static ConfigurationManager()
        {
        }
        private ConfigurationManager()
        {
            mConfigurationFile = new FileRepository();
            mConfigurationFile.Connect(DEFAULT_CONF_FILE_NAME);

            mConfigurationObject = mConfigurationFile.GetObject<ExperimentConfiguration>();
        }

        public static ConfigurationManager Instance
        {
            get
            {
                return sInstance;
            }
        }
    }
}
