using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystals_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во кристаллов в магазине | целое число: ");
            int crystalsOnStore = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите стоимость кристаллов | целое число: ");
            int price = Convert.ToInt32(Console.ReadLine());


            Console.Write("\nВведите колличество Вашего золота: ");
            int usergold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВ магазине CrystalsStore - " + crystalsOnStore + " кристаллов. " + price + " золотых - 1 кристалл.");
            Console.Write("Сколько возьмете | целое число: ");
            int userByCrystals = Convert.ToInt32(Console.ReadLine());


            if (crystalsOnStore < userByCrystals)
            {
                Console.WriteLine("\nЯ же тебе сказал, сколько кристаллов в магазине!\nзаходи завтра..");
                Console.WriteLine("\nЧтобы выйти, нажмите любую кнопку..");
                Console.ReadKey();
            }
            else if (crystalsOnStore >= userByCrystals)
            {

                int goldspent = price * userByCrystals;

                if (goldspent > usergold)
                {
                    Console.WriteLine("\nУ тебя мало золота для покупки " + userByCrystals + " кристаллов,\nзаходи в магазин, когда его появится больше!");
                }
                else if (goldspent <= usergold)
                {
                    usergold -= goldspent;
                    int result = crystalsOnStore - userByCrystals;

                    Console.WriteLine("\nУ вас осталось золота: " + usergold + "\nВ магазине осталось кристаллов: " + result);
                    Console.WriteLine("\nЧтобы выйти, нажмите любую кнопку..");
                    Console.ReadKey();
                }
            }
        }
    }
}
