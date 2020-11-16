using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    [XmlRoot("PurchaseOrder", Namespace = "http://www.cpandl.com",
   IsNullable = false)]
 public    class Uczelnia
    {
        public Student student;
       

    }
}
