using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIA_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
           
           do 
           {
               Console.WriteLine("Чтобы выйти введите Exit");
           
           } while(Console.ReadLine().ToLower().Trim() != "exit");
        }
    }
}
