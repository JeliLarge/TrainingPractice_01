using System;
using System.Text;
using System.Globalization;

namespace TDI_Task_06
{
    class Program 
    {
        struct dHumanInfo 
        {
            public int ID;
            public string surname;
            public string name;
            public string lastName;
        }
        
        struct dHumanPosition
        {
            public int ID;
            public string position;
        }

        struct Dossier
        {
            public int ID; 
            public string surname;
            public string name;
            public string lastName;
            public string position;
        }
        static void PrintMenu() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Нажмите q) Добавить досье");
            sb.AppendLine("Нажмите w) Показать все досье");
            sb.AppendLine("Нажмите e) Удалить определенное досье");
            sb.AppendLine("Нажмите r) Найти досье по фамилии");
            sb.AppendLine("Нажмите t) Выйти..");
            sb.AppendLine("Нажмите y) Перейти на профиль GitHub");

            Console.WriteLine(sb.ToString());
           
        }
        static Dossier[] AddDossier(dHumanInfo[] arrayFIO, dHumanPosition[] arrayPosition, Dossier[] dossier, int oldSize, int newSize)
        {

            for (int i = oldSize; i < newSize; i++)
            {
                try
                {
                    arrayFIO[i].ID = i;
                    arrayPosition[i].ID = arrayFIO[i].ID;

                    Console.WriteLine("\nНовая запись.. " + (i + 1));

                    Console.Write("\nФамилия ");
                    arrayFIO[i].surname = Console.ReadLine();

                    Console.Write("Имя ");
                    arrayFIO[i].name = Console.ReadLine();

                    Console.Write("Отчество ");
                    arrayFIO[i].lastName = Console.ReadLine();

                    Console.Write("Должность ");
                    arrayPosition[i].position = Console.ReadLine();
                    Console.Clear();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nИнвалид.. ");
                }
            }

            for (int i = oldSize; i < newSize; i++)
            {
                dossier[i].ID = arrayFIO[i].ID = arrayPosition[i].ID;
                dossier[i].surname = arrayFIO[i].surname;
                dossier[i].name = arrayFIO[i].name;
                dossier[i].lastName = arrayFIO[i].lastName;
                dossier[i].position = arrayPosition[i].position;
            }

            return dossier;
        }
        
        static Dossier[] CreateDossier(dHumanInfo[] arrrayHumanInfo, dHumanPosition[] arrayHumanPosition, int size) 
        {
            Dossier[] dossier = new Dossier[size];
            
            for (int i = 0; i < size; i++)
            {
                try
                {
                    arrrayHumanInfo[i].ID = i;
                    arrayHumanPosition[i].ID = arrrayHumanInfo[i].ID;

                    Console.WriteLine("\nНовая запись.." + (i + 1));

                    Console.Write("\nФамилия ");
                    arrrayHumanInfo[i].surname = Console.ReadLine();

                    Console.Write("Имя ");
                    arrrayHumanInfo[i].name = Console.ReadLine();

                    Console.Write("Отчество "); 
                    arrrayHumanInfo[i].lastName = Console.ReadLine();

                    Console.Write("Должность ");
                    arrayHumanPosition[i].position = Console.ReadLine();
                    Console.Clear();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nИнвалид.. ");
                }
            }

            for (int i = 0; i < size; i++)
            {
                dossier[i].ID = arrrayHumanInfo[i].ID = arrayHumanPosition[i].ID;
                dossier[i].surname = arrrayHumanInfo[i].surname;
                dossier[i].name = arrrayHumanInfo[i].name;
                dossier[i].lastName = arrrayHumanInfo[i].lastName;
                dossier[i].position = arrayHumanPosition[i].position; 
            }

            return dossier;
        }
        static Dossier[] RemoveDossier(Dossier[] dossier, int removeID)
        {
            int remInd = -1;

            for (int i = 0; i < dossier.Length; ++i) 
            {
                if (dossier[i].ID == removeID)
                {
                    remInd = i;
                    break; 
                }
            }

            Dossier[] newDossier = new Dossier[dossier.Length - 1];

            for (int i = 0, j = 0; i < newDossier.Length; ++i, ++j)
            {
                if (j == remInd)
                {
                    ++j; 
                }

                newDossier[i] = dossier[j];
            }

            return newDossier;
        }
        static void FindDessier(Dossier[] array, int size, string surname)
        {
            Console.WriteLine("\nНомер\tФамилия\tИмя\tОтчество\tДолжность");

            for (int i = 0; i < size; i++)
            {
                if (array[i].surname == surname)
                {
                    Console.WriteLine(array[i].ID +
                    "\t" + array[i].surname +
                    "\t" + array[i].name +
                    "\t" + array[i].lastName +
                    "\t\t" + array[i].position);
                }
            }
        }
        static void showDossier(Dossier[] array, int size)
        {

            Console.WriteLine("\nНомер\tФамилия\tИмя\tОтчество\tДолжность");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i].ID +
                    "\t" + array[i].surname +
                    "\t" + array[i].name +
                    "\t" + array[i].lastName +
                    "\t\t" + array[i].position);
            }
        }

        static void Main()
        {
            int size = 1;
            int newSize = 0;
            int oldSize = 0;

            dHumanInfo[] arrayHumanInfo = new dHumanInfo[size];
            dHumanPosition[] arrayHumanPosition = new dHumanPosition[size];

            Dossier[] dossierArray = new Dossier[size];

            bool isContinue = true;
            bool isFirstLaunch = true;
            char control;

            while (isContinue) 
            {
                if (isFirstLaunch)
                {
                    Console.WriteLine("Добавить досье.. Кол-во? ");
                    Console.Write("\n> ");
                    size = Convert.ToInt32(Console.ReadLine());

                    oldSize = size;
                    newSize = size;
                    
                    Array.Resize(ref arrayHumanInfo, size);
                    Array.Resize(ref arrayHumanPosition, size);
                    Array.Resize(ref dossierArray, size);

                    Console.Clear();

                    dossierArray = CreateDossier(arrayHumanInfo, arrayHumanPosition, size);

                    isFirstLaunch = false;

                    Console.Clear();
                }
                else
                {
                    PrintMenu();
                    Console.Write("> ");
                    control = (Console.ReadLine()[0]);

                    switch (control)
                    {
                        case 'q':
                            Console.Clear();

                            Console.WriteLine("\nСколько досье создать? ");
                            Console.Write("\n> ");
                            size = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            newSize += size;

                            Array.Resize(ref arrayHumanInfo, newSize);
                            Array.Resize(ref arrayHumanPosition, newSize);
                            Array.Resize(ref dossierArray, newSize);

                            dossierArray = AddDossier(arrayHumanInfo, arrayHumanPosition, dossierArray, oldSize, newSize);

                            oldSize = newSize;
                            
                            break;
                        case 'w':
                            Console.Clear();

                            showDossier(dossierArray, newSize);

                            Console.WriteLine("\nНажмите.. ");
                            Console.ReadLine();

                            break;
                        case 'e':
                            Console.Clear();
                            Console.Write("\nВведите ИД ");

                            dossierArray = RemoveDossier(dossierArray, Convert.ToInt32(Console.ReadLine()));

                            newSize--;
                            oldSize = newSize;

                            break;
                        case 'r':
                            Console.Clear();

                            Console.Write("\nВведите фамилию ");

                            FindDessier(dossierArray, newSize, Console.ReadLine());

                            Console.WriteLine("\nНажмите.. ");
                            Console.ReadLine();

                            break;
                        case 't':
                            isContinue = false;
                            
                            break;
                        case 'y':
                            System.Diagnostics.Process.Start("https://github.com/JeliLarge");
                                break;
                                
                    }
                    Console.Clear();
                }
            }
        }
    }
}