using System.Configuration;

namespace CommonTools
{
    public class SessionConfiguration
    {
        private const uint DEFAULT_NUMBER = 1;

        [ConfigurationProperty("Session Number", DefaultValue = DEFAULT_NUMBER)]
        [Validator(IsRequiered = true)]
        public uint Number { get; set; }

        public uint SleepHours { get; set; }

        public SessionConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        }
    }
}