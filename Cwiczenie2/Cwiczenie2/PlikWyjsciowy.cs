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
    using System.Text.Json;
    using System.Xml.Linq;
    public class PlikWyjsciowy
    {

        List<string> data;
        List<Student> students;
        string sciezka;
        string formatDanych;

        public PlikWyjsciowy(List<Student> students)
        {
            this.students = students;
            sciezka = @"żesult.xml";
            formatDanych = "xml";
            XmlSerializer(students, sciezka);
        }


        public PlikWyjsciowy(List<Student>students,string sciezka, string formatDanych)
        {
            this.students = students;

            if (isFormatXML(formatDanych) == false &&
                isFormatJSON(formatDanych)==false)
            {
                throw new Exception("Nieprawidłowy format danych : " + formatDanych);
            }
            else
            {
                this.formatDanych = formatDanych;
            }


            if (isPathCorrectJSON(sciezka) && isFormatJSON(formatDanych))
            {
                this.sciezka = sciezka;
                this.formatDanych = formatDanych;
                JsonCreateFile(students, sciezka);
            }
            else
            {
                if (isPathCorrectXML(sciezka) && isFormatXML(formatDanych))
                {
                    this.sciezka = sciezka;
                    this.formatDanych = formatDanych;
                    XmlSerializer(students, sciezka);

                }
                else
                {

                // zapis jako bład
                //wyrzucenie błedy
                throw new Exception("Nieprawidłowa argumenty  : " + sciezka + "," + formatDanych);
                }
            }
        }

        public PlikWyjsciowy(List<Student> students, string parametr)
        {

            this.students = students;

            if (isFormatXML(parametr) || isPathCorrectXML(parametr))
            {
                this.formatDanych = "xml";

                if (isPathCorrectXML(parametr))
                {
                    this.sciezka = parametr;
                }
                else
                {
                    this.sciezka = @"żesult.xml";
                }

                XmlSerializer(students, sciezka);
            }
            else
            {

                if (isFormatJSON(parametr) || isPathCorrectJSON(parametr))
                {
                    this.formatDanych = "JSON";

                    if (isPathCorrectJSON(parametr))
                    {
                        this.sciezka = parametr;
                    }
                    else
                    {
                        this.sciezka = @"żesult.json";
                    }
                    JsonCreateFile(students, sciezka);
                }
                else
                {
                    // zapis o błedzie 
                    //wywołać poprawny argument
                    throw new ArgumentException("Podana ścieżka jest niepoprawna : " + parametr);
                }
       
            }
            


        }







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
        

        public static void XmlSerializer(List<Student> students, string sciezka)
        {
            string filename =sciezka;
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var stream = File.Open(filename, FileMode.Create))
            {

                serializer.Serialize(stream, students);
            }
        }
        public static void JsonCreateFile (List<Student> students, string sciezka)
        {  
            string jsonString = JsonSerializer.Serialize(students);
            File.WriteAllText(sciezka,jsonString);

        
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

        public bool isFormatJSON(string format)
        {
            if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }


            return false;
        }












    }
}
