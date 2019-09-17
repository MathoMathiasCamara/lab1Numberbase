using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NumberBase
{
    class Program
    {
        static String hexa = "0123456789ABCDEF";  //"алфавит" шестнадцатиричной системы

        static void Main(string[] args)
        {
            
            int[] strore = new int[10];
            string Number, ConvertedNumber = string.Empty;
            int Base10 = 0, Base8 = 0, Rest, Divide;
            //чтение файла
            using (StreamReader sr = new StreamReader(@"D:\input.txt"))
            {
                Console.WriteLine("Reading the number.");
                try
                {
                    Number = sr.ReadLine();
                    // CONVERTING TO THE BASE 10
                    for (int i = 9; i >= 0; i--)
                    {
                        Base10 += Convert.ToInt32(Number[i]) * (int)(Math.Pow(2, i));
                    }

                    //CONVERT TO THE BASE 8mhm
                    Divide = Base10;
                    while (Divide >= 7)
                    {
                        Rest = Divide % 8;
                        Divide = Math.Abs(Divide / 8);

                        ConvertedNumber += (Rest).ToString();

                    }

                    // INVERT THE RESULT
                    ConvertedNumber = Convert.ToString(ConvertedNumber.Reverse());
                    Base8 = Convert.ToInt32(ConvertedNumber);
                }
                catch
                {
                    //Если в файле будут не только цифры, произойдет ошибка и в файл запишется "0"
                    Console.WriteLine("Упс, что-то пошло не так...");
                    Console.Read();
                }


                //Запись
                using (StreamWriter sw = new StreamWriter(@"D:\output.txt"))
                {
                    sw.Write(ConvertedNumber);
                    sw.Close();
                }

            }
        }
    }
}