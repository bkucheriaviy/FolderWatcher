using System;
using System.Xml.Serialization;

namespace XmlStockFileReader.XmlEntities
{
    [Serializable]
    [XmlRoot("values")]
    public class XmlStockFile
    {
        [XmlElement("value")]
        public StockValue[] Values { get; set; }
    }
}
