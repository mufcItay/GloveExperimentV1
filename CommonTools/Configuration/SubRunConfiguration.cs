using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CommonTools
{
    /// <summary>
    /// the class contains data about how a sub run shoul run
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SubRunConverter))]
    public class SubRunConfiguration
    {
        #region Consts
        private const uint DEFAULT_BLOCK_AMOUNT = 12;
        private const uint DEFAULT_INTER_BLOCK_TIMEOUT = 30;
        private const uint DEFAULT_BLOCK_DURATION = 1;

        #endregion

        #region Properties
        /// <summary>
        /// the amout of blocks in current sub run
        /// </summary>
        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_BLOCK_AMOUNT)]
        public uint BlocksAmount { get; set; }

        /// <summary>
        /// the amount of time to wait between blocks in the sub run
        /// </summary>
        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_INTER_BLOCK_TIMEOUT)]
        public uint InterBlockTimeout { get; set; }
        
        /// <summary>
        /// how long does the block take?
        /// </summary>
        [Validator(IsRequiered = true)]
        [ConfigurationProperty("Block Duration", DefaultValue = DEFAULT_BLOCK_DURATION)]
        public uint BlockDuration { get; set; }

        #endregion

        #region Ctor
        public SubRunConfiguration()
        {
            ConfiguartionUtilities.SetDefaultValues(this);
        } 
        #endregion
    }
}