using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Tihom
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ControlParameters : ISerializable
    {
        public ControlParameters()
        {
            Appearance = new AppearanceConfiguration();
            MovementControl = new MovementControlConfiguration();
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AppearanceConfiguration Appearance { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MovementControlConfiguration MovementControl  { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }
    }

    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MovementControlConfiguration
    {
        public string RightHand { get; set; }
        public string LeftHand { get; set; }

    }

    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AppearanceConfiguration
    {
        public string SkinTone { get; set; }
        public string Gender { get; set; }
        public string Orientation { get; set; }
        public string Size { get; set; }
    }
}