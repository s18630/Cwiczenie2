using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime;
    using System.Xml.Linq;
    public class PlikWyjsciowy
    {

        List<string> data;
        string sciezka;
        string formatDanych;
        public PlikWyjsciowy(List<string> listaDanych,string sciezkaDocelowa, string formatDanych)
        {

            this.data = listaDanych;

          if(  isFormatXML(formatDanych)== false)
            {

                throw new Exception("Nieprawidłowy format danych : "+ formatDanych);

            }
            else
            {
                this.formatDanych = formatDanych;

            }


          if( isPathCorrectJSON(sciezkaDocelowa))
            {

                throw new Exception("Nieprawidłowa ścieżka docelowa : " + sciezkaDocelowa);

            }

            if (isPathCorrectXML(sciezkaDocelowa))
            {

                this.sciezka = sciezkaDocelowa;

            }
            else
            {
                throw new Exception("Nieprawidłowa ścieżka docelowa : " + sciezkaDocelowa);


            }
            
            UtorzeniePlikuXML();
           



        }





        public PlikWyjsciowy(List<string> listaDanych, string sciezkaDocelowa)
        {

            this.data = listaDanych;
            // metoda na sprawdzenie czy dziala scieżka


            if (sciezkaDocelowa.EndsWith("xml"))
            {

                if (isPathCorrectXML(sciezkaDocelowa))
                {


                    this.sciezka = sciezkaDocelowa;
                    this.formatDanych = "xml";




                }

                if (isFormatXML(sciezkaDocelowa))
                {
                    this.sciezka = @"żesult.xml";
                    this.formatDanych = sciezkaDocelowa;

                }
            }
            else
            {

                throw new ArgumentException("Podana ścieżka jest niepoprawna : " + sciezkaDocelowa);
            }
           
                
               UtorzeniePlikuXML();

         





        }




        public PlikWyjsciowy(List<string> listaDanych )
        {

            this.data = listaDanych;
            // metoda na sprawdzenie czy dziala scieżka
            sciezka = @"żesult.xml";
             formatDanych = "xml";
            // sprawdzenie jaki jest format 
            //domyslne arg
            UtorzeniePlikuXML();




        }




        public void UtorzeniePlikuXML()
        {

            XElement cust = new XElement("studenci",


          from str in data
          let fields = str.Split(',')

          select new XElement("Student",
              new XAttribute("indexNumber", fields[0]),
              new XElement("fname", fields[1]),
              new XElement("lname", fields[2]),
              new XElement("birthdate", fields[3]),
              new XElement("Phone", fields[4]),
              new XElement("mothersname", fields[5]),
               new XElement("fathersname", fields[6]),
              new XElement("studies",
                  new XElement("name", fields[7]),
                  new XElement("mode", fields[8])


              )
          )
          );



            Console.WriteLine(cust);
            var studentXml = new XDocument();



            DateTime dt = DateTime.Now;
            string czas = dt.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));


            //Now, we are Adding the Root Element  
            var rootElement = new XElement("uczelnia",
                new XAttribute("createdAt", czas),
                new XAttribute("author", "Weronika Jaworek")
             );

            studentXml.Add(rootElement); 

            var e2 = new XElement(cust);


            rootElement.Add(cust);
          
 //         Console.WriteLine(studentXml.ToString());
            studentXml.Save(sciezka);
  //        Console.ReadKey();









        }



         public bool isPathCorrectXML( string path)
        {
            if (path.EndsWith(".xml"))
            {

                return true;

            }


            return false;




        }


        public bool isPathCorrectJSON(string path)
        {
            if (path.EndsWith(".json"))
            {

                return true;

            }


            return false;

        }



        public bool isFormatXML(string format)
        {
            if(format.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }
            

            return false;
        }




            
        






    }
}
