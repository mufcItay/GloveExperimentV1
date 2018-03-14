using CommonTools;
using System.Configuration;

namespace JasHandExperiment.Configuration
{
    #region Enums
    public enum GenderType
    {
        Female,
        Male
    } 
    #endregion

    /// <summary>
    /// The class contains data about the subject who takes the experiment
    /// </summary>
    public class ParticipantConfiguration
    {
        #region Consts
        private const uint DEFAULT_NUMBER = 1;
        private const uint DEFAULT_GROUP_NUMBER = 1;
        private const GenderType DEFAULT_GENDER = GenderType.Male;

        #endregion

        #region Propertises
        /// <summary>
        /// The subject number (like ID)
        /// </summary>
        [ConfigurationProperty("Participant Number", DefaultValue = DEFAULT_NUMBER)]
        [Validator(IsRequiered = true)]
        public uint Number { get; set; }

        /// <summary>
        /// the group of the subject
        /// </summary>
        [ConfigurationProperty("Participant Group Number", DefaultValue = DEFAULT_GROUP_NUMBER)]
        public uint GroupNumber { get; set; }

        /// <summary>
        /// the gender of the subject (consider adding more genders in future versions)
        /// </summary>
        [ConfigurationProperty("Participant Gender", DefaultValue = DEFAULT_GENDER)]
        public GenderType Gender { get; set; }

        /// <summary>
        /// The age of the subject
        /// </summary>
        public uint Age { get; set; }

        #endregion

        #region Ctor
        public ParticipantConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        } 
        #endregion
    }
}