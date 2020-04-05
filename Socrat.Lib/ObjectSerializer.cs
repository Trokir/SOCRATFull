using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Socrat.Lib
{
    public static class ObjectSerializer
    {

        public static byte[] Serialise(object record)
        {
            var ms = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ms, record);
            byte[] byffer = ms.GetBuffer();
            ms.Close();
            return byffer;
        }

        public static T Deserialise<T>(byte[] data)
        {
            T res;
            var ms = new MemoryStream(data);
            BinaryFormatter deserialazer = new BinaryFormatter();
            object _tmp = deserialazer.Deserialize(ms);
            res = (T)_tmp;
            return res;
        }

        public static T Copy<T>(object from)
        {
            T res = default(T);
            if (from != null)
            {
                byte[] buffer = Serialise(from);
                res = Deserialise<T>(buffer);
            }
            return res;
        }

        public static void Save(object sObject, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileStream _fs = new FileStream(fileName, FileMode.CreateNew);

            BinaryFormatter serialazer = new BinaryFormatter();

            serialazer.Serialize(_fs, sObject);

            _fs.Close();
        }

        public static T Load<T>(string fileName)
        {
            T sObject = default(T);

            if (File.Exists(fileName))
            {
                FileStream _fs = File.OpenRead(fileName);

                BinaryFormatter deserialazer = new BinaryFormatter();

                try
                {
                    sObject = (T)deserialazer.Deserialize(_fs);
                }
                finally
                {
                    _fs.Close();
                }

            }

            return sObject;
        }
    }
}
