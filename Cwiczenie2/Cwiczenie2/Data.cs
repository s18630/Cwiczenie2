using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cwiczenie2
{
    class Data

    {
        public List<string> data;


        public Data(List<string> lista)
        {
            data = new List<string>();
            extractData(lista);

        }









        public void extractData(List<string> lista)
        {
            int iloscposprawdzeniu = 0;
            int iloscrekordowWejsciowych = lista.Count;


     


            foreach (string s in lista)
            {
               

                string[] studentsData = s.Split(',');



                try
                {
                    CorrectRecord correctRecord = new CorrectRecord(studentsData);
                    string record = correctRecord.getCorrectedRecord();

                     // sptawdzić czy się nie powtarzają
                    data.Add(record);


                    correctRecord.showDataSet();

         

                    iloscposprawdzeniu++;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }









            }




            // zrobić set data i dodać 



            Console.WriteLine(" przed " + iloscrekordowWejsciowych + "----> " + "po" + iloscposprawdzeniu);




        }


        public void showData()
        {
            if (data.Count == 0)
            {
                Console.WriteLine("Lista jest pusta ");
            }

            else
            {

                Console.WriteLine(" Dostepne dane:");

                int i = 0;

                foreach (string s in data)
                { 
                    i++;
                    Console.WriteLine(" Zestaw Danych nr " + i);

                    Console.WriteLine(s + "\n");
                }

                Console.WriteLine("Zostało zapisane " + i + "zestawów danych");


            }





        }



        private class CorrectRecord

        {
            private string[] record;
            private string correctedRecord;

            public CorrectRecord(string[] record)
            {


                if (record.Length != 9)
                {
                    throw new Exception("Zła ilośc dostarczonych do konstruktora danych");
                }

                if (isBlankFiled(record))
                {

                    throw new Exception(" Jenda z kolumn nawiera nieprawidłową wartość");

                }
                else
                {
                    this.record = record;
                    // dodać potem funcke na odpowiednie miejsca

                    correctedRecord= string.Join(",", record);
                    

                }

               

            }



            public string getCorrectedRecord()
            {
                return correctedRecord;
            }




            public bool isBlankFiled(string[] fields)
            {
                int column = 0;

                foreach (string s in fields)
                {
                    column++;

                    if (isItEmpty(s) == true)
                    {
                        Console.WriteLine(" Niepasujące pole w kolumnie " + column);
                        return true;

                    }

                }

                return false;
            }



            private bool isItEmpty(string pole)
            {
                return !(Regex.IsMatch(pole, "[a-z0-9]+", RegexOptions.IgnoreCase));

            }




            public void showDataSet()
            {
                Console.WriteLine();
                int count = 0;

                foreach (string s in record)
                {
                    count++;

                    Console.WriteLine("Kolumna " + count + ": " + s);

                }


            }

        }
    


        }
    }

