using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Cwiczenie2
{
    public class Program
    {
        static void Main(string[] args)
        {


            //////////////////////////////////////////////////*

            try
            {


                       InputFile plikBezParametru = new InputFile();
                        plikBezParametru.showContent();

                //    InputFile plikPoprawnyParametr = new InputFile("C:\\Users\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //    plikPoprawnyParametr.showContent();


                //      InputFile plikNiepoprwanyParametr = new InputFile("C:\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //      plikNiepoprwanyParametr.showContent();




                 Data daneStudentow = new Data(plikBezParametru.content);
                List<string> records = daneStudentow.data;
               
                daneStudentow.showData();
                Console.WriteLine("po records sreung");
                List<Data.CorrectRecord> correctRecords = new List<Data.CorrectRecord>();
                Console.WriteLine("po correct rec");

                foreach(Data.CorrectRecord cs in correctRecords)
                {
                    
                        Console.WriteLine("aaaa");
                    
                    cs.showDataSet();
                }
                Console.WriteLine("po correct rec");

                List<Student> students = new List<Student>();

                foreach( Data.CorrectRecord dc in correctRecords)
                {

                    students.Add(
                        new Student
                        {
                            indexNumber = dc.indexNumber,
                            fname = dc.fname,
                            lname = dc.lname,
                            birthdate = dc.birthdate,
                            email = dc.email,
                            mothersName = dc.mothersName,
                            fathersName = dc.fathersName,
                            studia = new Studia
                            {
                                name = dc.studiesName,
                                mode = dc.studiesMode
                            }


                        }
                        );

                }

               


                foreach(Student s  in students)
                {
                    Console.WriteLine(s.email);
                }



                Console.WriteLine("bbbbbb");

                XmlSerializer(students);
               

                //      PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data);

                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "xml");
                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "testowyzapi.xml");
                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "testowyzapi.oml");
                //       PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "oml");
                //      PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "probazapisy.xml", "xml");


                //utwórz studentów 







            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }





            /*     using (StreamReader reader = new StreamReader("dane.csv"))
                 using (CsvReader csv = new CsvReader(reader,
                     CultureInfo.InvariantCulture))
                 {

                     Student student = new Student();
                     csv.Configuration.HasHeaderRecord = false;
                     List<Student> records = csv.GetRecords<Student>().ToList();




                 }


                 }*/





       /*     Student s = new Student()
            {
                indexNumber = "1",
                fname = "Keronika",
                lname = "jawor",
                birthdate = "23.23",
                email = "email@",
                fathersName = "otek",
                mothersName = "ania",
                studia = new Studia()
                {
                    name = "informatyka",
                    mode = "internetowe"
                }
            };

            XmlSerializer(s);



            Student s2= new Student()
            {
                indexNumber = "2",
                fname = "weronika",
                lname = "jawor",
                birthdate = "23.23",
                email = "email@",
                fathersName = "otek",
                mothersName = "ania",
                studia = new Studia()
                {
                    name = "informatyka",
                    mode = "internetowe"
                }
            };


            Student s3 = new Student()
            {
                indexNumber = "3",
                fname = "weronika",
                lname = "jawor",
                birthdate = "23.23",
                email = "email@",
                fathersName = "otek",
                mothersName = "ania",
                studia = new Studia()
                {
                    name = "informatyka",
                    mode = "internetowe"
                }
            };

            List<Student> listaStudentow = new List<Student>();
            listaStudentow.Add(s);
            listaStudentow.Add(s2);
            listaStudentow.Add(s3);


  XmlSerializer(listaStudentow);

          string jsonString = JsonSerializer.Serialize(listaStudentow);
            File.WriteAllText("plikjakohonson", jsonString);


            */






        }

        private static void  XmlSerializer(Student student)
        { string filename = "osoba.xml";
            var serializer = new  XmlSerializer(typeof(Student));
            using(var stream = File.Open(filename, FileMode.Create))
            {

                serializer.Serialize(stream, student);
            }
        }
        private static void XmlSerializer(List<Student> students)
        {
            string filename = "listaOsoby.xml";
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var stream = File.Open(filename, FileMode.Create))
            {

                serializer.Serialize(stream, students);
            }
        }

    }
}
