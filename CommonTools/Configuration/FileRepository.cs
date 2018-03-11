using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace CommonTools
{
    public class FileRepository : IConfigurationRepository
    {
        private string mPath;
        public bool Close()
        {
            return true;
        }

        public bool Connect(string connectionStr)
        {
            mPath = connectionStr;
            return true;
        }

        public T GetObject<T>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T obj;

            obj = ReadFromFile<T>(serializer);
            return obj;
        }

        private T ReadFromFile<T>(XmlSerializer serializer)
        {
            T obj;
            FileStream readFS = new FileStream(mPath, FileMode.Open);
            try
            {
                obj = (T)serializer.Deserialize(readFS);
            }
            catch (Exception)
            {

                throw;
            }

            readFS.Close();
            return obj;
        }

        public object GetObject(Type objectType)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            object obj;

            obj = ReadFromFile<object>(serializer);
            return obj;
        }

        public bool Save(object obj, string path)
        {
            FileStream saveFileFS = new FileStream(path, FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            try
            {
                serializer.Serialize(saveFileFS, obj);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed serializing to file : " + ex.Message);
                throw;
            }
            saveFileFS.Close();
            return true;
        }
    }
}
