using System;
using System.Collections.Generic;
using System.IO;

namespace Cwiczenie2
{
    class Program
    {
        static void Main(string[] args)
        {




            try
            {


                         InputFile plikBezParametru = new InputFile();
                         plikBezParametru.showContent();

                //    InputFile plikPoprawnyParametr = new InputFile("C:\\Users\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //    plikPoprawnyParametr.showContent();


                //      InputFile plikNiepoprwanyParametr = new InputFile("C:\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                //      plikNiepoprwanyParametr.showContent();




                Data daneStudentow = new Data(plikBezParametru.content);
                daneStudentow.showData();

                //      PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data);

                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "xml");
                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "testowyzapi.xml");
                //     PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "testowyzapi.oml");
                //       PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "oml");
                 //      PlikWyjsciowy plikWyjsciowy = new PlikWyjsciowy(daneStudentow.data, "probazapisy.xml", "xml");






            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }




           


















        }
    }
}
