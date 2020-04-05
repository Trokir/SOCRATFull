using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Socrat.UI.Core
{
    public static class UserSettingsSerializer
    {
        public static void Save(Dictionary<string, string> dictionary, string fileName)
        {
            if (dictionary.Count<1)
                return;
            XDocument _document = new XDocument();
            XElement _items = new XElement("Items");
            _document.Add(_items);
            XElement _item;
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                _item = new XElement("Item");
                _items.Add(_item);
                XAttribute _key = new XAttribute("Key", pair.Key);
                XAttribute _value = new XAttribute("Value", pair.Value);
                _item.Add(_key);
                _item.Add(_value);
            }
            FileStream _file = new FileStream(fileName, FileMode.Create);
            _document.Save(_file);
            _file.Close();
        }

        public static Dictionary<string, string> Load(string fileName)
        {
            Dictionary<string, string> _dictionary = new Dictionary<string, string>();
            if (!File.Exists(fileName))
                return _dictionary;

            XDocument _document = XDocument.Load(fileName);
            XElement _items = _document.Elements().FirstOrDefault(x => x.Name == "Items");
            if (_items != null)
            {
                var _nodes = _items.Elements().Where(x => x.Name == "Item");
                foreach (XElement xElement in _nodes)
                {
                    _dictionary.Add(
                        xElement.Attributes().FirstOrDefault(x => x.Name == "Key")?.Value,
                        xElement.Attributes().FirstOrDefault(x => x.Name == "Value")?.Value);
                }

            }


            return _dictionary;
        }
    }
}