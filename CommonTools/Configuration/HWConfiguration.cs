using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CommonTools
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class HWConfiguration
    {
        public string KeyboardUSBPort { get; set; }
        public string VRUSBPort { get; set; }
        public string GlovesUSBPort { get; set; }
    }
     
}