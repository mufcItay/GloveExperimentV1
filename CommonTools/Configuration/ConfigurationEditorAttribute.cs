using System;

namespace CommonTools
{
    public class ConfigurationEditorAttribute : Attribute
    {
        public Type ObjectType { get; private set; }

        public ConfigurationEditorAttribute(Type type)
        {
            ObjectType = type;
        }
    }
}
