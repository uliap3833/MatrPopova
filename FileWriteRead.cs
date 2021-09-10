using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Matrix
{
    class FileWriteRead
    {
        public static void ReadData(string path, ref int[,] matr)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var lines = File.ReadAllLines(path);
            int k = 0;
            string[] strLen = lines[0].Split(';'); //Определение длины строки массива
            matr = new int[lines.Length, strLen.Length]; //Инициализируется массив, куда будут записываться значения
            foreach (var line in lines)
            {

                string[] str = line.Split(';'); //Считывание в строковой массив
                for (int j = 0; j < str.Length; j++)
                {
                    matr[k, j] = Convert.ToInt32(str[j]); //Передача в основной массив
                }
                k++;
            }
        }

        public static void WriteToFile(string path, List<int> neededNums, int count)
        {
            if (!File.Exists(path)) File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, false))
            {

                sw.WriteLine("Элементы массива, у которых сумма кубов их цифр равна самому числу:");
                foreach(var num in neededNums)
                {
                    sw.Write(num+"; ");
                }
                sw.WriteLine("\nОбщее количество элементов, подходящих по условию: " +count);
            }
        }
    }
}
