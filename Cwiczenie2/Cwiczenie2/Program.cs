using System;
using System.IO;

namespace Cwiczenie2
{
    class Program
    {
        static void Main(string[] args)
        {




            try
            {


                    //      InputFile plikBezParametru = new InputFile();
                   //      plikBezParametru.showContent();

                    //    InputFile plikPoprawnyParametr = new InputFile("C:\\Users\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                    //    plikPoprawnyParametr.showContent();


                  //      InputFile plikNiepoprwanyParametr = new InputFile("C:\\weron\\OneDrive\\Pulpit\\Plik testowy folder\\danetestowe.csv");
                   //      plikNiepoprwanyParametr.showContent();




            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }























        }
    }
}
