using System;

namespace TDI_Task_06
{
    class Program
    {
        // Структуры
        struct DossierFIO
        {
            public int ID;
            public string surname;
            public string name;
            public string lastName;
        }

        struct DossierPosition
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
        ///////////

        // Меню
        static void PrintMenu()
        {
            Console.WriteLine("\n||| MENU |||\n" +
                "\n > Add new dossier[1]" +
                "\n > Show all dossiers[2]" +
                "\n > Delete dossier[3]" +
                "\n > Find dossier by last name[4]" +
                "\n > Quit[5]\n");
        }
        ///////////

        // Добавить новую запись
        static Dossier[] AddDossier(DossierFIO[] arrayFIO, DossierPosition[] arrayPosition, Dossier[] dossier, int oldSize, int newSize)
        {

            for (int i = oldSize; i < newSize; i++)
            {
                try
                {
                    arrayFIO[i].ID = i;
                    arrayPosition[i].ID = arrayFIO[i].ID;

                    Console.WriteLine("\nNew entry #" + (i + 1));

                    Console.Write("\nSurname: ");
                    arrayFIO[i].surname = Console.ReadLine();

                    Console.Write("Name: ");
                    arrayFIO[i].name = Console.ReadLine();

                    Console.Write("Lastname: ");
                    arrayFIO[i].lastName = Console.ReadLine();

                    Console.Write("Position: ");
                    arrayPosition[i].position = Console.ReadLine();
                    Console.Clear();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input, try again...");
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
        ///////////

        //Создание первичных записей
        static Dossier[] CreateDossier(DossierFIO[] arrayFIO, DossierPosition[] arrayPosition, int size)
        {
            Dossier[] dossier = new Dossier[size];

            for (int i = 0; i < size; i++)
            {
                try
                {
                    arrayFIO[i].ID = i;
                    arrayPosition[i].ID = arrayFIO[i].ID;

                    Console.WriteLine("\nNew entry #" + (i + 1));

                    Console.Write("\nSurname: ");
                    arrayFIO[i].surname = Console.ReadLine();

                    Console.Write("Name: ");
                    arrayFIO[i].name = Console.ReadLine();

                    Console.Write("Lastname: ");
                    arrayFIO[i].lastName = Console.ReadLine();

                    Console.Write("Position: ");
                    arrayPosition[i].position = Console.ReadLine();
                    Console.Clear();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input, try again...");
                }
            }

            for (int i = 0; i < size; i++)
            {
                dossier[i].ID = arrayFIO[i].ID = arrayPosition[i].ID;
                dossier[i].surname = arrayFIO[i].surname;
                dossier[i].name = arrayFIO[i].name;
                dossier[i].lastName = arrayFIO[i].lastName;
                dossier[i].position = arrayPosition[i].position;
            }

            return dossier;
        }
        ///////////

        // Удаление записи
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
        ///////////

        // Поиск записи по фамилии
        static void FindDessier(Dossier[] array, int size, string surname)
        {
            Console.WriteLine("\nID\tSURNAME\t\tNAME\t\tLASTNAME\t\tPOSITION");

            for (int i = 0; i < size; i++)
            {
                if (array[i].surname == surname)
                {
                    Console.WriteLine(array[i].ID +
                    "\t" + array[i].surname +
                    "\t\t" + array[i].name +
                    "\t\t" + array[i].lastName +
                    "\t\t" + array[i].position);
                }
            }
        }
        ///////////

        //Показ всех записей
        static void showDossier(Dossier[] array, int size)
        {

            Console.WriteLine("\nID\tSURNAME\t\tNAME\t\tLASTNAME\t\tPOSITION");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(array[i].ID +
                    "\t" + array[i].surname +
                    "\t\t" + array[i].name +
                    "\t\t" + array[i].lastName +
                    "\t\t" + array[i].position);
            }
        }
        ///////////

        static void Main()
        {
            int size = 1;
            int newSize = 0;
            int oldSize = 0;

            DossierFIO[] arrayFIO = new DossierFIO[size];
            DossierPosition[] arrayPosition = new DossierPosition[size];

            Dossier[] dossierArray = new Dossier[size];

            bool isContinue = true;
            bool isFirstLaunch = true;
            int control;

            while (isContinue)
            {
                if (isFirstLaunch)
                {
                    Console.WriteLine("First launch" +
                        "\nYou must first add records" +
                        "\nHow many dossiers do you want to add ?");
                    Console.Write("\n> ");
                    size = Convert.ToInt32(Console.ReadLine());

                    oldSize = size;
                    newSize = size;

                    Array.Resize(ref arrayFIO, size);
                    Array.Resize(ref arrayPosition, size);
                    Array.Resize(ref dossierArray, size);

                    Console.Clear();

                    dossierArray = CreateDossier(arrayFIO, arrayPosition, size);

                    isFirstLaunch = false;

                    Console.Clear();
                }
                else
                {
                    PrintMenu();
                    Console.Write("> ");
                    control = Convert.ToInt32(Console.ReadLine());

                    switch (control)
                    {
                        case 1:
                            Console.Clear();

                            Console.WriteLine("\nHow many dossiers do you want to add ?");
                            Console.Write("\n> ");
                            size = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();

                            newSize += size;

                            Array.Resize(ref arrayFIO, newSize);
                            Array.Resize(ref arrayPosition, newSize);
                            Array.Resize(ref dossierArray, newSize);

                            dossierArray = AddDossier(arrayFIO, arrayPosition, dossierArray, oldSize, newSize);

                            oldSize = newSize;

                            break;
                        case 2:
                            Console.Clear();

                            showDossier(dossierArray, newSize);

                            Console.WriteLine("\nPress to continue . . .");
                            Console.ReadLine();

                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("\nEnter ID: ");

                            dossierArray = RemoveDossier(dossierArray, Convert.ToInt32(Console.ReadLine()));

                            newSize--;
                            oldSize = newSize;

                            break;
                        case 4:
                            Console.Clear();

                            Console.Write("\nEnter surname: ");

                            FindDessier(dossierArray, newSize, Console.ReadLine());

                            Console.WriteLine("\nPress to continue . . .");
                            Console.ReadLine();

                            break;
                        case 5:
                            isContinue = false;

                            break;
                    }
                    Console.Clear();
                }
            }
        }
    }
}