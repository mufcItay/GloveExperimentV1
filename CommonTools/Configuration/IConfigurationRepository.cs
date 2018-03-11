using System;

namespace CommonTools
{
    public interface IConfigurationRepository
    {
        bool Connect(string connectionStr);
        bool Save(Object obj, string path);
        T GetObject<T>();
        object GetObject(Type objectType);
        bool Close();
    }
}
