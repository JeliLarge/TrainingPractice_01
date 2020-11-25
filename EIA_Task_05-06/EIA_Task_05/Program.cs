using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {

        private const char wallchar = '\u2588';
        private const char mazechar = '\u0020';

        static private List<List<bool>> mazeLayout = new List<List<bool>>();

        static void Main(string[] args)
        {

            //

            string[] lines = File.ReadAllLines("C:/Users/Сергей/Documents/Visual Studio 2013/Projects/ConsoleApplication12/ConsoleApplication12/mappp (1).txt");

            for (int i = 0; i < lines.Length; ++i)
            {

                List<bool> line = new List<bool>();

                for (int j = 0; j < lines[i].Length; ++j)
                {
                    line.Add(lines[i][j] == '█');
                }

                mazeLayout.Add(line);

            }

            //

            Console.SetWindowSize(30, 30);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("");

            int col = 10;
            int row = 2;
            

            //Make maze
           
          
           
               
           
            if (col != 8 && row != 15)  
            {
                for (int i = 0; i < mazeLayout.Count; i++)
                {
                    for (int j = 0; j < mazeLayout[i].Count; j++)
                    {
                        Console.Write(mazeLayout[i][j] ? wallchar : mazechar);
                    }
                    Console.Write("\n");
                }

                Console.WriteLine("");
                col = 10;
                row = 2;

                Console.SetCursorPosition(col, row);
                Console.Write("*");
                Console.SetCursorPosition(col, row);
                while (true)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.W && !mazeLayout[row - 2][col])
                    {
                        Console.Write(" ");
                        Debug.Print("W");
                        row--;
                    }
                    if (info.Key == ConsoleKey.Z && !mazeLayout[row][col])
                    {
                        Console.Write(" ");
                        Debug.Print("Z");
                        row++;
                    }

                    if (info.Key == ConsoleKey.A && !mazeLayout[row - 1][col - 1])
                    {
                        Console.Write(" ");
                        Debug.Print("A");
                        col--;
                    }

                    if (info.Key == ConsoleKey.S && !mazeLayout[row - 1][col + 1])
                    {
                        Console.Write(" ");
                        Debug.Print("S");
                        col++;
                        
                        if (info.Key == ConsoleKey.F1)
                        {
                            Debug.Print("F1");
                            col = 10;
                            row = 2;
                            for (int a = 0; a < 1; a++)
                                row++;
                            for (int a = 0; a < 2; a++)
                                col++;
                            for (int a = 0; a < 6; a++)
                                row++;
                            for (int a = 0; a < 1; a++)
                                col--;
                            for (int a = 0; a < 3; a++)
                                row++;
                            for (int a = 0; a < 3; a++)
                                col--;



                        }
                    }

                    Console.SetCursorPosition(col, row);
                    Console.Write("*");
                    Console.SetCursorPosition(col, row);
                    
                    if (col == 8 && row == 15)
                    {
                        Console.Clear();
                        Console.WriteLine("Вы прошли лабиринт!");
                        Console.WriteLine("Нажмите чтобы выйти..");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            } 

    }
    }
}
