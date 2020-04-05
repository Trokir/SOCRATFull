using System;

namespace Socrat.Model.Convertion
{
    public class BaseConverter
    {
        public T ValueParse<T>(object value, T defaultValue)
        {
            if (value == null)
                return defaultValue;
            else
                return Get<T>(value.ToString());
        }

        public T Get<T>(string _key)
        {
            return (T)Get(_key, typeof(T));
        }

        public object Get(string _toparse, Type _t)
        {
            Type undertype = Nullable.GetUnderlyingType(_t);
            Type basetype = undertype == null ? _t : undertype;
            return Convert.ChangeType(_toparse, basetype);
        }
    }
}