using System.Configuration;

namespace CommonTools
{
    public enum GenderType
    {
        Female,
        Male
    }

    public class ParticipantConfiguration
    {
        private const uint DEFAULT_NUMBER = 1;
        private const uint DEFAULT_GROUP_NUMBER = 1;
        private const GenderType DEFAULT_GENDER = GenderType.Male;

        [ConfigurationProperty("Participant Number", DefaultValue = DEFAULT_NUMBER)]
        [Validator(IsRequiered = true)]
        public uint Number { get; set; }

        [ConfigurationProperty("Participant Group Number", DefaultValue = DEFAULT_GROUP_NUMBER)]
        public uint GroupNumber { get; set; }

        [ConfigurationProperty("Participant Gender", DefaultValue = DEFAULT_GENDER)]
        public GenderType Gender { get; set; }
        
        public uint Age { get; set; }

        public ParticipantConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        }
    }
}