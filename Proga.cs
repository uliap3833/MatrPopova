using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Proga
    {
        string readPath; //Путь читаемого файла
        string savingPath; //Путь файла, в который идёт запись
        int[,] matrix; //Матрица
        int count = 0; //Количество подходящих чисел
        List<int> neededNums = new List<int>(); //Список подходящих чисел

        public Proga(string readPath, string savingPath) //Конструктор класса
        {
            this.readPath = readPath;
            this.savingPath = savingPath;
        }

        void MatrixMoving() //Прохождение по всей матрице
        {  
            foreach(int num in matrix)
            {
                if(NumSumCheck(num) == true)
                {
                    count++;
                    neededNums.Add(num);
                }
            }
        }

        bool NumSumCheck(int num) //Проверка элемента по условию
        {
            int sum = 0, origNum = num;
            bool result = false;
            while (num > 0)
            {
                sum = sum + Convert.ToInt32(Math.Pow(num % 10,3));
                num = num / 10;
            }

            if (sum == origNum) result = true;

            return result;
        }

        public void CalcStart() //Метод, вызывающий функционал класса, а также чтение и запись
        {
            FileWriteRead.ReadData(readPath, ref matrix);
            MatrixMoving();
            FileWriteRead.WriteToFile(savingPath, neededNums, count);
        }
    }

}
