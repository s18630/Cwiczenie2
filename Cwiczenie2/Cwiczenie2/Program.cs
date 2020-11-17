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

            /*     if(args.Length == 0)
                 {
                     errorsRecord.saveToFile("Brak dostarczonych argumentów");
                 }
                 else
                 {
                     if (args.Length > 3)
                     {
                         errorsRecord.saveToFile("Nieprawidłowa liczba argumentów");
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
                             if (!s.EndsWith(".csv"))
                             {
                                 arg2 = s;
                                 errorsRecord.saveToFile("arg2 ->" + arg2);
                                 break;

                             }
                         }


                         foreach (string s in args)
                         {
                             if (!s.EndsWith(".csv") && !s.Equals(arg2))
                             {
                                 arg3 = s;
                                 errorsRecord.saveToFile("arg3 ->" + arg3);
                                 break;
                             }
                         }





                     }



                 }




            */

            if (args.Length == 0)
            {
                errorsRecord.saveToFile("Nie wprowadzono argumentów");
            }

            if (args.Length > 3)
            {
                errorsRecord.saveToFile("Wprowadzono zbyt dużo argumentów");
            }

            if( args.Length == 3)
            {
                pathInput = args[0];
                arg2 = args[1];
                arg3 = args[2];
            }

            if (args.Length == 2)
            {
                if (args[0].EndsWith(".csv"))
                {
                    pathInput = args[0];
                    arg2 = args[1];
                }else
                {
                    arg2 = args[0];
                    arg3 = args[1];

                }


            }


                 
                



           










                 /*


















                      errorsRecord.saveToFile(arg2 + ", " + arg3);
                      */
            //1. kiedy nie ma doatępnego formaty
            //    arg2 = "prawidlowebezformatu.json";
            //    arg3 = "bezform";

            //2a.kiedy 2 są prawidłowe i zgodne json
            //     arg2 = "prawidłowy.json";
            //      arg3 = "json";

            //2b. kiedy 2 są niezgodne i json 
            //      arg2 = "nieprawidłowy.json";
            //     arg3 = "xml";


            //3a. kiedy 2 sa poprawne i xml
            //     arg2 = "npoprawne.xml";
            //    arg3 = "xml";


            //3a. kiedy 2 sa niepoprawne i xml
            //       arg2 = "npoprawne.xml";
            //     arg3 = "json";



            //Konstruktor z 1 paramtetre,
            // kiedy to poprawny format xml
            //  arg2 = "xml";
            //kiedy niepoprawny format 
            //    arg2="niepop";

            //kiedy to poprawna sciezka
            //  arg2 = "poprawnasciezka.xml";

            //kiedy to poprawna sciezka 
            //  arg2 = "poprawna.json";

            //sciezka niepoprawna

          //  arg2 = "niepoprawnasciezka";



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
                OutputFile outputFile;

                if (arg2!= null & arg3 != null)
                {
                    try
                    {
                      outputFile = new OutputFile(students, arg2 , arg3);
                    }catch(Exception ex)
                    {
                       errorsRecord.saveToFile(ex.Message);
                    }
                }
                else if(arg2 != null)
                {
                    try
                    {
                        outputFile = new OutputFile(students, arg2);
                    }catch (ArgumentException ex)
                    {
                        errorsRecord.saveToFile(ex.Message);
                    }
                }
                else
                {
                    outputFile = new OutputFile(students);
                }


                
                   

            








         //     OutputFile pw = new OutputFile(students);
        //    OutputFile pwjson = new OutputFile(students, "Zkonstruktora.json", "json");
         //   OutputFile plikzjsonDomyslnaNazwa = new OutputFile(students, "json");





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
