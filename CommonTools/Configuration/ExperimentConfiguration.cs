using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;

namespace CommonTools
{
    public enum ExperimentType
    {
        Active,
        PassiveWatchingReplay,
        PassiveSimulation
    }

    public enum HandType
    {
        None,
        Left,
        Right
    }


    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ExperimentConfiguration
    {
        private const string DEFAULT_SEQUENCE = "41324";
        private const ExperimentType DEFAULT_EXPERIMENT_TYPE = ExperimentType.Active;
        private const string DEFAULT_REPLAY_FILE = @"UserPresses\Replay.csv";
        private const uint DEFAULT_PRESS_FREQ = 1;

        [ConfigurationProperty("Squence", DefaultValue = DEFAULT_SEQUENCE)]
        [Validator(IsRequiered = true)]
        public string Squence { get; set; }

        public SubRunCollection SubRuns { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ParticipantConfiguration ParticipantConfiguration { get; set; }

        public List<SessionConfiguration> SessionsConfiguration { get; set; }
        
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public HWConfiguration HWConfiguration { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OutputFilesConfiguration OutputFilesConfiguration { get; set; }

        public VRHandConfiguration VRHandConfiguration { get; set; }

        [ConfigurationProperty("Experiment Type", DefaultValue = DEFAULT_EXPERIMENT_TYPE)]
        public ExperimentType ExperimentType { get; set; }
        
        [ConfigurationProperty("Replay File Path", DefaultValue = DEFAULT_REPLAY_FILE)]
        public string ReplayFilePath { get; set; }
        
        [ConfigurationProperty("Replay File Path", DefaultValue = DEFAULT_PRESS_FREQ)]
        [Validator(IsRequiered = true, MaxValue = 200, MinValue = 1)]
        public uint PressFrequency{ get; set; }


        public ExperimentConfiguration()
        {
            HWConfiguration = new HWConfiguration();
            ParticipantConfiguration = new ParticipantConfiguration();
            SessionsConfiguration = new List<SessionConfiguration>();
            OutputFilesConfiguration = new OutputFilesConfiguration();
            VRHandConfiguration = new VRHandConfiguration();
            SubRuns = new SubRunCollection();

            ConfiguartionUtilities.SetDefaultValues(this);
        }
    }
}
