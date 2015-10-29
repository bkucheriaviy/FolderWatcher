using System;
using System.Xml.Serialization;

namespace XmlStockFileReader.XmlEntities
{
    [Serializable]
    public class StockValue
    {
        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlAttribute("open")]
        public string Open { get; set; }

        [XmlAttribute("high")]
        public string High { get; set; }

        [XmlAttribute("low")]
        public string Low { get; set; }

        [XmlAttribute("close")]
        public string Close { get; set; }

        [XmlAttribute("volume")]
        public string Volume { get; set; }
    }
}