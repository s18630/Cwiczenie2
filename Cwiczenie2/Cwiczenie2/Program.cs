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


            ErrorsRegister errorsRecord = new ErrorsRegister();
          

            string pathInput = null;
            string arg2 = null;
            string arg3 = null;
            
            if(args.Length == 0)
            {
                // zapis do pliku z błedami
            }
            else
            {
                if (args.Length > 3)
                {
                    //zła liczba argumentóq

                }
                else
                {

                    //znajdz argument zakończony cvd 
                    //jeśli nie ma daj domyślną nazwę 

                    foreach(string s in args)
                    {
                        if (s.EndsWith(".csv"))
                        {
                            pathInput = s;
                            break;

                        }
  
                    }
                    
                    foreach (string s in args)
                    {
                        int i = 1;
                        if(!s.EndsWith(".csv"))
                        {
                            i++;
                            if (i == 2)
                            {
                                arg2 = s;

                            }
                            if (i == 3)
                            {
                                arg3 = s;
                            }
              
                        }

                    }

                }


            }

            //////////////////////////////////////////////////*

            try
            {
                InputFile inputFile;

                if (pathInput == null)
                {
                    inputFile = new InputFile();
                }
                else
                {
                    inputFile = new InputFile(pathInput);
                }

                inputFile.showContent();

                //    InputFile plikPoprawnyParametr = new InputFile("C:\\Users\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //    plikPoprawnyParametr.showContent();


                //      InputFile plikNiepoprwanyParametr = new InputFile("C:\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //      plikNiepoprwanyParametr.showContent();


                Data studentsData  = new Data(inputFile.content, errorsRecord);
                studentsData.showData();
                List<Student> students = studentsData.students;



                OutputFile pw = new OutputFile(students);
                OutputFile pwjson = new OutputFile(students, "Zkonstruktora.json", "json");
                OutputFile plikzjsonDomyslnaNazwa = new OutputFile(students, "json");





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
                errorsRecord.saveToFile(ex.Message);
            }





        }
    }
}
