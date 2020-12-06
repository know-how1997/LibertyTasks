using System;

namespace CountIslands
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = new Random().Next(0, 2);
            }


            Console.WriteLine($"number of islands : {GetNumberOfIslands(matrix, n)}");
        }
        static int GetNumberOfIslands(int[,] matrix, int n)
        {
            bool[,] isVisited = new bool[n, n];
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] == 1 && !isVisited[i, j])
                    {
                        LandCheck(matrix, i, j, n, isVisited);
                        count++;
                    }
            return count;
        }
        static void LandCheck(int[,] matrix, int i, int j, int n, bool[,] isVisited)
        {
            int[] horizontal = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] vertical = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            isVisited[i, j] = true;
            for (int k = 0; k < 8; k++)
                if (IsNewLand(matrix, i + horizontal[k], j + vertical[k], n, isVisited))
                    LandCheck(matrix, i + horizontal[k], j + vertical[k], n, isVisited);
        }
        static bool IsNewLand(int[,] matrix, int i, int j, int n, bool[,] isVisited)
        {
            return (i >= 0) && (i < n) && (j >= 0) && (j < n) && (matrix[i, j] == 1 && !isVisited[i, j]);
        }
    }
}


