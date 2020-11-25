using System;


namespace EIA_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int userHp = 100, bossHp = 500, bossAttack, userAttack, healPotion = 1, 
                 berserkTry = 2;
            string userAction;
            bool userArmor = true, chance, berserk = false;

            Random random = new Random();

            while (bossHp > 0 && userHp > 0)
            {
                userAttack = 30;
                
                    if (userArmor)
                        bossAttack = random.Next(5, 10);
                    else
                        bossAttack = 15;
                    Console.WriteLine(userHp + "|100 - Здоровье игрока\n\n" + bossHp + "|500 - Здоровье босса\n");
                    Console.WriteLine
                        ("1 - Аттака\n" +
                        "2 - Выпить лечебное зелье (пополяет здоровье на максимум).\n У вас имеется: " + healPotion + " Зелий\n" +
                        "3 - Выпить зелье берсерка (восполняет здоровье на максимум, так же увеличивает урон по боссу до 50 едениц).\n У вас имеется: " + berserkTry + " зелий\n"+
                        "4 - Аттака в увороте..\n");
                    
                    if (userArmor)
                        Console.WriteLine("5 - Снять доспехи (Увеличивает шанс удачной атаки в увороте на 75%, но также увеличивает урон по вам)\n\n\n");
                userAction = Convert.ToString(Console.ReadLine());
                switch (userAction) 
                {
                    case "1":
                        bossHp -= userAttack;
                        break;
                    case "2":
                        if (healPotion > 0)
                        {
                            if (userHp < 100)
                            {
                                userHp = 100;
                                Console.WriteLine("\nЗдоровье пополнено!");
                                healPotion--;
                                userAttack = 0;

                            }
                            else if (userHp == 100)
                            {
                                Console.WriteLine("\nВы полностью здоровы!");
                            }

                        }
                        else
                            userAttack = 0;
                            Console.WriteLine("\nЗелья лечения закончились!");
                        break;
                    case "3":
                        if (berserkTry >= 1)
                        {
                            Console.WriteLine("\nВы выпили зелье берсерка, урон увеличен, здоровье пополнено!");
                            userHp = 100;
                            berserk = true;
                            berserkTry--;
                            

                        }
                        else if (berserkTry == 0)
                        {
                            
                            Console.WriteLine("\nЗелье берсерка закончилось!");
                            berserk = false;
                            userAttack = 0;
                        }
                        if (berserk == true)
                            userAttack = 50;
                        else
                            userAttack = 30;
                        break;
                    case "4":
                        if (userArmor)
                        {
                            chance = Convert.ToBoolean(random.Next(2));
                            if (chance)
                            {
                                bossHp -= userAttack;
                                Console.WriteLine("\nВы удачно увернулись");
                                bossAttack = 0;
                            }
                            else
                            {
                                bossHp -= userAttack;
                                Console.WriteLine("\nВы неудачно увернулись");
                                bossAttack = 75;
                            }
                        }
                        else
                        {
                            chance = Convert.ToBoolean(random.Next(4));
                            if (chance)
                            {
                                bossHp -= userAttack;
                                Console.WriteLine("\nВы удачно увернулись");
                                bossAttack = 0;
                            }
                            else
                            {
                                bossHp -= userAttack;
                                Console.WriteLine("\nВы неудачно увернулись");
                                bossAttack = 90;
                            }
                        }
                        break;
                    case "5":
                    userArmor = false;
                        break;
                    default:
                        userAttack = 0;
                        Console.WriteLine("Вы пропустили ход!");
                        break;
                        
                }

                userHp -= bossAttack;
                Console.WriteLine("\nВы получили "+bossAttack+" урона");
                Console.WriteLine("\nБосс получил " + userAttack + " урона\n");
                Console.WriteLine("\nНажмите клавишу чтобы начать следующий ход..");
                Console.ReadKey();
                Console.Clear();
      
            }

            if (userHp <= 0 && bossHp <= 0)
                Console.WriteLine("Вы убили босса, но и босс убил вас..\n");
            else if (userHp > 0 && bossHp <= 0)
                Console.WriteLine("Вы убили босса..\n");
            else
                Console.WriteLine("Вы проиграли..\n");
            Console.WriteLine("Нажмите любую кнопку, чтобы выйти..");
            Console.ReadKey();
            Environment.Exit(0);
            
        }
    }
}
