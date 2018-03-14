using System;
using System.ComponentModel;

namespace Tihom
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BlockConfiguration
    {
    }
}