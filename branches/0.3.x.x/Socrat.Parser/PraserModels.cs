using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization;

namespace Socrat.Parser
{
    [Serializable]
    public class HeaderField
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "MaxLength")]
        public string MaxLength { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }

    [Serializable]
    public class BodyField
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "MaxLength")]
        public string MaxLength { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }

    [Serializable]
    public class Common
    {
        [XmlAttribute(AttributeName = "GPSVersion")]
        public string GPSVersion { get; set; }
        [XmlAttribute(AttributeName = "MinSize")]
        public string MinSize { get; set; }
        [XmlAttribute(AttributeName = "MinRatio")]
        public string MinRatio { get; set; }
        [XmlAttribute(AttributeName = "SaveToFormul")]
        public string SaveToFormul { get; set; }
    }

    [Serializable]
    public class HeaderItem
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ConstValue")]
        public string ConstValue { get; set; }
        [XmlAttribute(AttributeName = "CellRow")]
        public string CellRow { get; set; }
        [XmlAttribute(AttributeName = "CellColumn")]
        public string CellColumn { get; set; }
        [XmlArray("Parse"), XmlArrayItem(typeof(ParseItem), ElementName = "ParseItem")]
        public List<ParseItem> Parse { get; set; }
    }

    [Serializable]
    public class Detail
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "LabelString")]
        public string LabelString { get; set; }
        [XmlAttribute(AttributeName = "CellColumn")]
        public string CellColumn { get; set; }
        [XmlAttribute(AttributeName = "DeltaRow")]
        public string DeltaRow { get; set; }
    }

    [Serializable]
    public class Details: List<Detail>
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Formula")]
        public string Formula { get; set; }
    }

    [Serializable]
    public class ParseItem
    {
        [XmlAttribute(AttributeName = "Order")]
        public string Order { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Object")]
        public string Object { get; set; }
        [XmlAttribute(AttributeName = "ParseStr")]
        public string ParseStr { get; set; }
        [XmlAttribute(AttributeName = "ValueStr")]
        public string ValueStr { get; set; }
    }

    [Serializable]
    public class BodyItem
    {
        [XmlArray("Details"), XmlArrayItem(typeof(Detail), ElementName = "Detail")]
        public Details Details { get; set; }
        [XmlArray("Parse"), XmlArrayItem(typeof(ParseItem), ElementName = "ParseItem")]
        public List<ParseItem> Parses { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Required")]
        public string Required { get; set; }
    }

    [Serializable]
    public class Body: List<BodyItem>
    {
        [XmlAttribute(AttributeName = "StartLine")]
        public string StartLine { get; set; }
        [XmlAttribute(AttributeName = "LinesPerRecord")]
        public string LinesPerRecord { get; set; }
        [XmlAttribute(AttributeName = "StopLine")]
        public string StopLine { get; set; }
    }

    [Serializable]
    public class Customer
    {
        [XmlElement(ElementName = "Common")]
        public Common Common { get; set; }
        [XmlArray("Header"), XmlArrayItem(typeof(HeaderItem), ElementName = "HeaderItem")]
        public List<HeaderItem> Headers { get; set; }
        [XmlArray("Body"), XmlArrayItem(typeof(BodyItem), ElementName = "BodyItem")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "Alias")]
        public string Alias { get; set; }
        [XmlAttribute(AttributeName = "UniqueStr")]
        public string UniqueStr { get; set; }
        [XmlAttribute(AttributeName = "Note")]
        public string Note { get; set; }
    }

    [Serializable]
    [XmlRoot(ElementName = "PARSER_CONFIG")]
    public class ParserConfig
    {
        [XmlArray("HEADERFIELDS"), XmlArrayItem(typeof(HeaderField), ElementName = "HEADERFIELD")]
        public List<HeaderField> HeaderFields { get; set; }
        [XmlArray("BODYFIELDS"), XmlArrayItem(typeof(BodyField), ElementName = "BODYFIELD")]
        public List<BodyField> BodyFields { get; set; }
        [XmlArray("CUSTOMERS"), XmlArrayItem(typeof(Customer), ElementName = "CUSTOMER")]
        public List<Customer> Customer { get; set; }
    }

}

