using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CommonTools
{
    [Serializable]
    [TypeConverter(typeof(SubRunConverter))]
    public class SubRunConfiguration
    {
        private const uint DEFAULT_BLOCK_AMOUNT = 12;
        private const uint DEFAULT_INTER_BLOCK_TIMEOUT = 30;
        private const uint DEFAULT_BLOCK_DURATION = 1;

        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_BLOCK_AMOUNT)]
        public uint BlocksAmount { get; set; }

        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_INTER_BLOCK_TIMEOUT)]
        public uint InterBlockTimeout { get; set; }

        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_BLOCK_DURATION)]
        public uint BlockDuration { get; set; }

        public SubRunConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        }
    }
}