﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cwiczenie2
{
    class Data

    {
        public List<string> data;
        private List<CorrectRecord> dataSets;

        public Data(List<string> lista)
        {
            data = new List<string>();
            dataSets = new List<CorrectRecord>();
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

                    if (isDuplicate(correctRecord) )
                    {

                        throw new Exception("Znaleziono duplikat: " + correctRecord.getCorrectedRecord() );
                    }
                    else
                    {
                        dataSets.Add(correctRecord);
                        string record = correctRecord.getCorrectedRecord();

                        data.Add(record);

                        correctRecord.showDataSet();



                        iloscposprawdzeniu++;

                    }
                   


               //     correctRecord.showDataSet();

         

                //    iloscposprawdzeniu++;

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
            private string[] columns;
            private string correctedRecord;



            private string indexNumber;
            private string fname ;
            private string lname ;
            private string birthdate;
            private string email ;
            private string mothersName ;
            private string fathersName ;
            private string studiesName;
            private string studiesMode ;


            public CorrectRecord(string[] columns)
            {


                if (columns.Length != 9)
                {
                    throw new Exception("Zła ilośc dostarczonych do konstruktora danych");
                }

                if (isBlankFiled(columns))
                {

                    throw new Exception(" Jenda z kolumn nawiera nieprawidłową wartość");

                }
                else
                {

                    columns=sortColumns(columns);

                    this.columns = columns;

                    correctedRecord= string.Join(",", columns);
                    

                }

               

            }
           



            private string[] sortColumns(string [] columns) 
            {
                this.indexNumber = columns[4];
                this.fname = columns[0];
                this.lname = columns[1];
                this.birthdate = columns[5];
                this.email = columns[6];
                this.mothersName = columns[7];
                this.fathersName = columns[8];
                this.studiesName = columns[2];
                this.studiesMode = columns[3];

                columns = new string[] {
                    indexNumber,
                    fname,
                    lname,
                    birthdate,
                    email,
                    mothersName,
                    fathersName,
                    studiesName,
                    studiesMode };

                return columns;




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

                foreach (string s in columns)
                {
                    count++;

                    Console.WriteLine("Kolumna " + count + ": " + s);

                }


            }
            public string getIndexNumber()
            {
                return indexNumber;
            }

            public string getFname()
            {
                return fname;
            }

            public string getLname()
            {
                return lname;
            }


        }




        private bool isDuplicate(CorrectRecord record)
        {
            foreach (CorrectRecord s in dataSets)
            {
                int conditions = 0;

                if (Equals(s.getIndexNumber(), record.getIndexNumber()))
                {
                    conditions++;
                }

                if (Equals(s.getFname(), record.getFname()))
                {
                    conditions++;
                }

                if (Equals(s.getLname(), record.getLname()))
                {
                    conditions++;
                }

                if (conditions == 3)
                {
                    return true;
                }

            }


            return false;
        }







    }
}

