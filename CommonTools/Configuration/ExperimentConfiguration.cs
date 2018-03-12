using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;

namespace CommonTools
{
    #region Enums
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

    #endregion

    /// <summary>
    /// The class encapsulates all of the configurable values of an experiment
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ExperimentConfiguration
    {
        #region Constants
        private const string DEFAULT_SEQUENCE = "41324";
        private const ExperimentType DEFAULT_EXPERIMENT_TYPE = ExperimentType.Active;
        private const string DEFAULT_REPLAY_FILE = @"UserPresses\Replay.csv";
        private const uint DEFAULT_PRESS_FREQ = 1;
        #endregion

        #region Properties
        /// <summary>
        /// The seuquene subject need to type
        /// </summary>
        [ConfigurationProperty("Squence", DefaultValue = DEFAULT_SEQUENCE)]
        [Validator(IsRequiered = true)]
        public string Squence { get; set; }

        /// <summary>
        /// contains all of the sub runs in the experiment
        /// </summary>
        public SubRunCollection SubRuns { get; set; }

        /// <summary>
        /// all of the data about the subject being experimented
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ParticipantConfiguration ParticipantConfiguration { get; set; }

        /// <summary>
        /// data about all of the sessions that were made in the experiment
        /// </summary>
        public List<SessionConfiguration> SessionsConfiguration { get; set; }

        /// <summary>
        /// all of the paths of output files in the experiment.
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OutputFilesConfiguration OutputFilesConfiguration { get; set; }

        /// <summary>
        /// data about the VR hand in the experiment
        /// </summary>
        public VRHandConfiguration VRHandConfiguration { get; set; }

        /// <summary>
        /// the type of the experiment
        /// </summary>
        [ConfigurationProperty("Experiment Type", DefaultValue = DEFAULT_EXPERIMENT_TYPE)]
        public ExperimentType ExperimentType { get; set; }

        /// <summary>
        /// replay file path, relevant for passive experiment types
        /// </summary>
        [ConfigurationProperty("Replay File Path", DefaultValue = DEFAULT_REPLAY_FILE)]
        public string ReplayFilePath { get; set; }

        /// <summary>
        /// the frequency of key presses in simlatino experiment type
        /// </summary>
        [ConfigurationProperty("Replay File Path", DefaultValue = DEFAULT_PRESS_FREQ)]
        [Validator(IsRequiered = true, MaxValue = 200, MinValue = 1)]
        public uint PressFrequency { get; set; }

        #endregion

        #region Ctor
        public ExperimentConfiguration()
        {
            ParticipantConfiguration = new ParticipantConfiguration();
            SessionsConfiguration = new List<SessionConfiguration>();
            OutputFilesConfiguration = new OutputFilesConfiguration();
            VRHandConfiguration = new VRHandConfiguration();
            SubRuns = new SubRunCollection();

            ConfiguartionUtilities.SetDefaultValues(this);
        } 
        #endregion
    }
}
