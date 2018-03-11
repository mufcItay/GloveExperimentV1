using System.ComponentModel;
using System.Configuration;

namespace CommonTools
{
    public class OutputFilesConfiguration
    {

        [ConfigurationProperty("User Presses Log Path", DefaultValue = @"UserPresses\Presses.csv")]
        public string UserPressesLogPath { get; set; }

        public string ConfigurationFilePath { get; set; }

        [ConfigurationProperty("Glove Movement Log Path", DefaultValue = @"GloveMovements\Movemenvts.csv")]
        public string GloveMovementLogPath { get; set; }

        public OutputFilesConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        }
    }
}