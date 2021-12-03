using System;
using System.Collections.Generic;
/*using System.Text;*/

namespace Sets
{
    class ShuntingYard
    {
        //Метод возвращает true, если проверяемый символ - оператор
        static private bool IsOperator(char с)
        {
            if (@"+\^*()".IndexOf(с) != -1)
            {
                return true;
            }

            return false;
        }

        //Метод возвращает приоритет оператора
        static private byte GetPriority(char s)
        {
            return s switch
            {
                '(' => 0,
                ')' => 1,
                '\\' => 2,
                '+' => 3,
                '*' => 4,
                '^' => 5,
                _ => 6,
            };
        }

        //Метод преобразовывает выражение в обратную польскую запись (постфиксную)
        static private string ConvertToRPN(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> stackForOperations = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++)
            {
                //Пробел пропускаем
                if (" ".IndexOf(input[i]) != -1)
                {
                    continue; //Переходим к следующему символу
                }

                //Если символ - буква, то добавляем к строке хранения выражения
                if (char.IsLetter(input[i]))
                {
                    output += input[i];
                    i++;

                    if (i == input.Length)
                    {
                        break; //Если символ - последний, то выходим из цикла
                    }
                }

                //Если символ - оператор
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        stackForOperations.Push(input[i]); //Записываем открывающую скобку в стек
                    }
                    else if (input[i] == ')') 
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = stackForOperations.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = stackForOperations.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (stackForOperations.Count > 0) //Если в стеке есть элементы
                        {
                            if (GetPriority(input[i]) <= GetPriority(stackForOperations.Peek()) && input[i] != '^') //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            {
                                output += stackForOperations.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                            }
                        }

                        stackForOperations.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (stackForOperations.Count > 0)
                output += stackForOperations.Pop() + " ";

            return output; //Возвращаем выражение в постфиксной записи
        }

        //Метод решает полученное выражение
        static private string[] Counting(string input, string[] A, string[] B, string[] C, string[] U)
        {
            string[] result;
            Stack<string[]> temp = new Stack<string[]>(); //Временный стек для решения
            SetsOperations SetsOperations = new SetsOperations();

            for (int i = 0; i < input.Length; i++)
            {
                //Если символ - буква, то записываем сет на вершинк стека
                if (char.IsLetter(input[i]))
                {
                    switch (input[i])
                    {
                        case 'A':
                            temp.Push(A);
                            break;
                        case 'B':
                            temp.Push(B);
                            break;
                        case 'C':
                            temp.Push(C);
                            break;
                        case 'U':
                            temp.Push(U);
                            break;
                        default:
                            break;
                    }
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    string[] a = temp.Pop();
                    string[] b;

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+':
                            b = temp.Pop();
                            /*Console.WriteLine($"Над множеством {{{string.Join(", ", a)}}} и {{{string.Join(", ", b)}}} производится действие {input[i]}");*/
                            result = SetsOperations.Union(b, a);
                            temp.Push(result);
                            break;
                        case '\\':
                            b = temp.Pop();
                            /*Console.WriteLine($"Над множеством {{{string.Join(", ", a)}}} и {{{string.Join(", ", b)}}} производится действие {input[i]}");*/
                            result = SetsOperations.Difference(b, a);
                            temp.Push(result);
                            break;
                        case '*':
                            b = temp.Pop();
                            /*Console.WriteLine($"Над множеством {{{string.Join(", ", a)}}} и {{{string.Join(", ", b)}}} производится действие {input[i]}");*/
                            result = SetsOperations.Intersection(b, a);
                            temp.Push(result);
                            break;
                        case '^':
                            /*result = SetsOperations.Compliment(b, a);*/
                            /*Console.WriteLine($"Над множеством {{{string.Join(", ", a)}}} и {{{string.Join(", ", U)}}} производится действие {input[i]}");*/
                            result = SetsOperations.Compliment(a, U);
                            temp.Push(result);
                            break;
                    }
                }
            }

            return SetsOperations.SetSort(temp.Peek()); //Забираем результат всех вычислений из стека и возвращаем его
        }

        //Основной метод класса
        static public string[] Calculate(string input, string[] A, string[] B, string[] C, string[] U)
        {
            string output = ConvertToRPN(input); //Переводим выражение в обратную польскую запись
            string[] result = Counting(output, A, B, C, U); //Считаем выражение в постфискной записи
            return result; //Возвращаем результат
        }
    }
}
