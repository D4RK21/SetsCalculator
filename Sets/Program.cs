using System;

namespace Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Создание объекта класса SetsOperations*/
            SetsOperations SetsOperations = new SetsOperations();
            /*Цвета для текста в консоли*/
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tSets Operations\n\t\t\t\tSE-21-1\n\t\t\t\tBy Mikhail Zhmaytsev\n");
            Console.ResetColor();

            /*Выбор сета по умолчанию или ввод своего*/
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Would you like to enter your own set or use already declarated?");
            Console.ResetColor();
            Console.Write("Type \"1\" for own set and \"2\" for declarated: ");

            string[] A, B, C, U;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\n\tEnter elements separated by space of set A: ");
                    A = Console.ReadLine().Split(' ');

                    Console.Write("\n\tEnter elements separated by space of set B: ");
                    B = Console.ReadLine().Split(' ');

                    Console.Write("\n\tEnter elements separated by space of set C: ");
                    C = Console.ReadLine().Split(' ');
                    break;
                case "2":
                    /*Входные сеты*/
                    A = new string[] { "1", "1", "3", "5", "1", "8", "2", "13" };
                    B = new string[] { "8", "10", "5", "3", "8", "9", "89" };
                    C = new string[] { "3", "6", "1000", "4000", "1000", "3", "3", "3" };
                    break;
                default:
                    /*Входные сеты*/
                    A = new string[] { "1", "1", "3", "5", "1", "8", "2", "13" };
                    B = new string[] { "8", "10", "5", "3", "8", "9", "89" };
                    C = new string[] { "3", "6", "1000", "4000", "1000", "3", "3", "3" };
                    break;
            }

            /*Выбор универсального множетсва по умолчанию или ввод своего*/
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWould you like to enter your own universal set or automatically generate it (Union of all sets)?");
            Console.ResetColor();
            Console.Write("Type \"1\" for own set and \"2\" to generate: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\n\tEnter elements separated by space of universal set U: ");
                    U = Console.ReadLine().Split(' ');
                    break;
                case "2":
                    U = SetsOperations.Union(SetsOperations.Union(A, B), C);
                    break;
                default:
                    U = SetsOperations.Union(SetsOperations.Union(A, B), C);
                    break;
            }

            /*Входные сеты
            int[] A = new int[] { 1, 1, 3, 5, 1, 8, 2, 13 };
            int[] B = new int[] { 8, 10, 5, 3, 8, 9, 89 };
            int[] C = new int[] { 3, 6, 1000, 4000, 1000, 3, 3, 3 };
            int[] U = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };*/

            /*Сортировка массивов*/
            A = SetsOperations.SetSort(A);
            B = SetsOperations.SetSort(B);
            C = SetsOperations.SetSort(C);
            U = SetsOperations.SetSort(U);

            /*Вывод входных сетов*/
            Console.WriteLine("\nInput data:");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (A.Length != 0) Console.Write($"\tSet A: {{{string.Join(", ", A)}}}\n");
            if (B.Length != 0) Console.Write($"\tSet B: {{{string.Join(", ", B)}}}\n");
            if (C.Length != 0) Console.Write($"\tSet C: {{{string.Join(", ", C)}}}\n");
            if (U.Length != 0) Console.Write($"\tSet U: {{{string.Join(", ", U)}}}\n");
            Console.ResetColor();

            while (true) // Бесконечный цикл для ввода операций
            {
                /*Выбор действия или ввод формулы*/
                Console.WriteLine("\nChoose an action or enter a formula:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t Type \"1\" for Union");
                Console.WriteLine("\t Type \"2\" for Intersection");
                Console.WriteLine("\t Type \"3\" for Difference");
                Console.WriteLine("\t Type \"4\" for Compliment");
                Console.WriteLine("\t Type \"5\" to enter the formula");
                Console.ResetColor();
                Console.Write("Your choice: ");

                switch (Console.ReadLine())
                {
                    case "1": // Union
                        Console.Write("Enter sets for Union: ");

                        string[] setsForOperation = Console.ReadLine().Split(' ');
                        string[] firstSet = setsForOperation[0] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => A,
                        };
                        string[] secondSet = setsForOperation[1] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => B,
                        };

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Result: {{{string.Join(", ", SetsOperations.Union(firstSet, secondSet))}}}\n");
                        Console.ResetColor();
                        break;
                    case "2": // Intersection
                        Console.Write("Enter sets for Intersection: ");

                        setsForOperation = Console.ReadLine().Split(' ');
                        firstSet = setsForOperation[0] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => A,
                        };
                        secondSet = setsForOperation[1] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => B,
                        };

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Result: {{{string.Join(", ", SetsOperations.Intersection(firstSet, secondSet))}}}\n");
                        Console.ResetColor();
                        break;
                    case "3": // Difference
                        Console.Write("Enter sets for Difference: ");

                        setsForOperation = Console.ReadLine().Split(' ');
                        firstSet = setsForOperation[0] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => A,
                        };
                        secondSet = setsForOperation[1] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => B,
                        };

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Result: {{{string.Join(", ", SetsOperations.Difference(firstSet, secondSet))}}}\n");
                        Console.ResetColor();
                        break;
                    case "4": // Compliment
                        Console.Write("Enter sets for Compliment: ");

                        setsForOperation = Console.ReadLine().Split(' ');
                        firstSet = setsForOperation[0] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => A,
                        };
                        secondSet = setsForOperation[1] switch
                        {
                            "A" => A,
                            "B" => B,
                            "C" => C,
                            "U" => U,
                            _ => B,
                        };

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Result: {{{string.Join(", ", SetsOperations.Compliment(firstSet, secondSet))}}}\n");
                        Console.ResetColor();
                        break;
                    case "5": // Formula
                        Console.WriteLine("Notation keys: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tUnion — \"+\" | Intersection — \"*\" | Difference — \"\\\" | Compliment — \"^\"");
                        Console.ResetColor();
                        Console.Write("Formula: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Result: {{{string.Join(", ", ShuntingYard.Calculate(Console.ReadLine(), A, B, C, U))}}}\n");
                        Console.ResetColor();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
