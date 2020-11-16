using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    [Serializable]
    public class Studia
    {
       
        [XmlElement(ElementName = "name")]
        public string name { get; set; }
        [XmlElement(ElementName = "node")]
        public string mode { get; set; }
    }
}
