using System;

namespace Sets
{
    class SetsOperations
    {
        /*Удаление одинаковых елементов*/
        private string[] RemoveDuplicateElements(string[] set)
        {
            if (set.Length == 0 || set.Length == 1)
            {
                return set;
            }

            string[] res = new string[set.Length];
            int countOfDuplicatedElements = 0;
            int j = 0;

            for (int i = 0; i < set.Length - 1; i++)
            {
                if (set[i] != set[i + 1])
                {
                    res[j++] = set[i];
                }
                else
                {
                    countOfDuplicatedElements++;
                }
            }

            res[j++] = set[set.Length - 1];
            Array.Resize(ref res, res.Length - countOfDuplicatedElements);

            return res;
        }

        /*Пузырьковая сортировка*/
        /*Тут должна быть перегрузка метода*/
        public string[] SetSort(string[] set)
        {
            int temp;
            int[] numericSet = new int[set.Length];
            string[] stringSet = new string[set.Length];

            // Перевод из string в int
            for (int k = 0; k < numericSet.Length; k++)
            {
                numericSet[k] = Int32.Parse(set[k]);
            }

            for (int i = 0; i < numericSet.Length - 1; i++)
            {
                for (int j = i + 1; j < numericSet.Length; j++)
                {
                    if (numericSet[i] > numericSet[j])
                    {
                        temp = numericSet[i];
                        numericSet[i] = numericSet[j];
                        numericSet[j] = temp;
                    }
                }
            }

            //Перевод обратно (из int в string)
            for (int k = 0; k < set.Length; k++)
            {
                stringSet[k] = numericSet[k].ToString();
            }

            /*Удаление одинаковых елементов*/
            stringSet = RemoveDuplicateElements(stringSet);
            return stringSet;
        }

        /*Объединение*/
        public string[] Union(string[] A, string[] B)
        {
            int lengthOfElements = 0;

            //Подсчитываем количество элементов, которое должно быть в выходном массиве
            foreach (string i in A)
            {
                lengthOfElements++;
            }

            foreach (string j in B)
            {
                lengthOfElements++;
            }

            string[] res = new string[lengthOfElements];
            int count = 0;

            //Запись элементов в выходной массив
            foreach (string i in A)
            {
                res[count] = i;
                count++;
            };

            foreach (string j in B)
            {
                res[count] = j;
                count++;
            };

            return SetSort(res);
        }

        /*Пересечение*/
        public string[] Intersection(string[] A, string[] B)
        {
            int lengthOfElements = 0;

            //Подсчитываем количество элементов, которое должно быть в выходном массиве
            foreach (string i in A)
            {
                foreach (string j in B)
                {
                    if (i == j) lengthOfElements++;
                }
            }

            string[] res = new string[lengthOfElements];
            int count = 0;

            //Запись элементов в выходной массив
            foreach (string i in A)
            {
                foreach (string j in B)
                {
                    if (i == j)
                    {
                        res[count] = i;
                        count++;
                    }
                }
            }

            return SetSort(res);
        }

        /*Разница*/
        public string[] Difference(string[] A, string[] B)
        {
            int lengthOfElements = 0;

            //Подсчитываем количество элементов, которое должно быть в выходном массиве
            foreach (string i in A)
            {
                bool isExistInSecondSet = false;
                foreach (string j in B)
                {
                    if (i == j)
                    {
                        isExistInSecondSet = true;
                    }
                }
                if (!isExistInSecondSet)
                {
                    lengthOfElements++;
                }
            }

            string[] res = new string[lengthOfElements];
            int count = 0;

            //Запись элементов в выходной массив
            foreach (string i in A)
            {
                bool isExistInSecondSet = false;
                foreach (string j in B)
                {
                    if (i == j)
                    {
                        isExistInSecondSet = true;
                    }
                }
                if (!isExistInSecondSet)
                {
                    res[count] = i;
                    count++;
                }
            }

            return SetSort(res);
        }

        /*Отрицание*/
        public string[] Compliment(string[] A, string[] U)
        {
            int lengthOfElements = 0;

            //Подсчитываем количество элементов, которое должно быть в выходном массиве
            foreach (string i in U)
            {
                bool isExistInSecondSet = false;
                foreach (string j in A)
                {
                    if (i == j)
                    {
                        isExistInSecondSet = true;
                    }
                }
                if (!isExistInSecondSet)
                {
                    lengthOfElements++;
                }
            }

            string[] res = new string[lengthOfElements];
            int count = 0;

            //Запись элементов в выходной массив
            foreach (string i in U)
            {
                bool isExistInSecondSet = false;
                foreach (string j in A)
                {
                    if (i == j)
                    {
                        isExistInSecondSet = true;
                    }
                }
                if (!isExistInSecondSet)
                {
                    res[count] = i;
                    count++;
                }
            }

            return SetSort(res);
        }


        /*Предыдущие версия*/
        /*
        public int[] SetSort(int[] set)
        {
            *//*Пузырьковая сортировка*//*
            int temp;
            for (int i = 0; i < set.Length - 1; i++)
            {
                for (int j = i + 1; j < set.Length; j++)
                {
                    if (set[i] > set[j])
                    {
                        temp = set[i];
                        set[i] = set[j];
                        set[j] = temp;
                    }
                }
            }

            *//*Удаление одинаковых елементов*//*
            set = set.Distinct().ToArray();
            return set;
        }

        *//*Объединение*//*
        public int[] Union(int[] A, int[] B)
        {
            List<int> Res = new List<int>();

            foreach (int i in A) Res.Add(i);
            foreach (int j in B) Res.Add(j);

            return Res.Distinct().ToArray();
        }

        *//*Пересечение*//*
        public int[] Intersection(int[] A, int[] B)
        {
            List<int> Res = new List<int>();

            foreach (int i in A)
            {
                foreach (int j in B)
                {
                    if (i == j) Res.Add(i);
                }
            }

            return Res.Distinct().ToArray();
        }

        *//*Разница*//*
        public int[] Difference(int[] A, int[] B)
        {
            List<int> Res = new List<int>();

            foreach (int i in A)
            {
                bool IsExistInSecondSet = false;
                *//*Console.WriteLine(i);*//*
                foreach (int j in B)
                {
                    *//*Console.WriteLine($"\t{j}");*//*
                    if (i == j) IsExistInSecondSet = true;
                }
                if (!IsExistInSecondSet) Res.Add(i);
            }

            return Res.Distinct().ToArray();
        }

        *//*Отрицание*//*
        public int[] Compliment(int[] A, int[] U)
        {
            List<int> Res = new List<int>();

            foreach (int i in U)
            {
                bool IsExistInSecondSet = false;
                foreach (int j in A)
                {
                    if (i == j) IsExistInSecondSet = true;
                }
                if (!IsExistInSecondSet) Res.Add(i);
            }

            return Res.Distinct().ToArray();
        }*/
    }
}
