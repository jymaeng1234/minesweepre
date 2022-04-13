using System;
using MinesweepreProject;
using MinesweepreProject.Util;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = 4;
            int colCount = 5;
            int mineCount = new Random().Next() % (rowCount * colCount);

            bool[,] mineLocation = MineSweepreFunction.CreateMineLocations(rowCount, colCount, mineCount);
            int[,] mineMap = MineSweepreFunction.CreateMineMap(mineLocation);

            PrintMineLocation(mineLocation);
            Console.WriteLine("---------------------------------");
            PrintMineMap(mineMap);
            
            Console.WriteLine("Finish");

        }

        static void PrintMineLocation(bool[,] mineLocation)
        {
            for (int i = 0; i < mineLocation.GetLength(0); i++)
            {
                for (int j = 0; j < mineLocation.GetLength(1); j++)
                {
                    Console.Write($"{mineLocation[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        static void PrintMineMap(int[,] mineMap)
        { 
            for(int i=0;i<mineMap.GetLength(0);i++)
            {
                for (int j = 0; j < mineMap.GetLength(1); j++)
                {
                    Console.Write($"{mineMap[i,j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
