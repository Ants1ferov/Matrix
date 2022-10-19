using System;
using System.IO;

namespace Matrix
{
    static class MatrixOperations
    {
        public static void WritingMatrix(byte size)
        {
            Random random = new Random();
            StreamWriter streamWriter = new StreamWriter("Matrix.txt");
            int[,] arrayMatrix = new int[size,size];

            for (int i = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(0); j++)
                {
                    arrayMatrix[i, j] = random.Next(-1000, 1000);
                    streamWriter.Write($"{arrayMatrix[i, j]}\t");
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }
        public static void ReadingMatrix()
        {
            StreamReader streamReader = new StreamReader("Matrix.txt");
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            string[] line = s.Split(new char[] { '\t', '\r', '\n', });
            line = ClearingArray(line);

            int size = Convert.ToInt32(Math.Sqrt((double)line.Length));

            int[,] arrayMatrix = new int[size, size];

            for (int i = 0, t = 0; i < arrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMatrix.GetLength(1); j++)
                {
                    arrayMatrix[i, j] = Convert.ToInt32(line[t]);
                    t++;
                }
            }

            int[,] sortedArrayMatrix = SortedArray(arrayMatrix);

            StreamWriter streamWriter = new StreamWriter("SortMatrix.txt");

            for (int i = 0; i < sortedArrayMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sortedArrayMatrix.GetLength(0); j++)
                {
                    streamWriter.Write($"{sortedArrayMatrix[i, j]}\t");
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }
        private static string[] ClearingArray(string[] line)
        {
            int emptyElements = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == "")
                {
                    emptyElements++;
                }
            }

            string[] purifiedSings = new string[line.Length - emptyElements];

            for (int i = 0, j = 0; i < purifiedSings.Length;)
            {
                if (line[j] == "")
                {
                    j++;
                    continue;
                }

                purifiedSings[i] = line[j];
                j++;
                i++;
            }

            return purifiedSings;
        }
        private static int[,] SortedArray(int[,] arr)
        {
            int[] allElements = new int[arr.Length];
            int[,] sortedArray = new int[arr.GetLength(0), arr.GetLength(1)];

            for (int i = 0, t = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    allElements[t] = arr[i, j];
                    t++;
                }
            }

            Array.Sort(allElements);
            Array.Reverse(allElements);

            for (int i = 0, t = 0; i < sortedArray.GetLength(0); i++)
            {
                for (int j = 0; j < sortedArray.GetLength(1); j++)
                {
                    sortedArray[i, j] = allElements[t];
                    t++;
                }
            }

            return sortedArray;
        }
    }
}
