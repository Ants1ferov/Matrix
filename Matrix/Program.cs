using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            byte size;

            Console.Write("Выберите действие (запись/чтение матрицы): ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "запись":
                    Console.Write("Введите размер матрицы: ");
                    size = Convert.ToByte(Console.ReadLine());
                    MatrixOperations.WritingMatrix(size);
                    break;
                case "чтение":
                    MatrixOperations.ReadingMatrix();
                    break;
            }

            Console.WriteLine("Действие с матрицей успешно завершено");

            Console.ReadLine();
        }
    }
}
