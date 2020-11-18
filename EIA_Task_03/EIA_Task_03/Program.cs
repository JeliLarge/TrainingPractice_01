using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIA_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = "hello";
            int maxAttemps = 3;


            Console.WriteLine("Введите пароль");

            for (int i = 0; i <= maxAttemps; i++)
            {
                if (i == maxAttemps)
                {
                    Console.WriteLine("Не гэнгста...");
                    break;
                }

                if (Console.ReadLine() == pass)
                {
                    Console.WriteLine("реальный гэнгста");
                    break;
                }

                Console.WriteLine("Неверный пароль");


            }

            Console.ReadLine();
        }
    }
}
