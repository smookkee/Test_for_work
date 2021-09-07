using System;
using System.Diagnostics;
using System.Linq;

namespace Test_Sort
{
    class Program
    {
        static void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        static int Separator(int[] array, int minIndex, int maxIndex)
        {
            var baseIndex = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    baseIndex++;
                    Swap(ref array[baseIndex], ref array[i]);
                }
            }

            baseIndex++;
            Swap(ref array[baseIndex], ref array[maxIndex]);
            return baseIndex;
        }

        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            int pivot_loc = 0;

            if (minIndex < maxIndex)
            {
                pivot_loc = Separator(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivot_loc - 1);
                QuickSort(array, pivot_loc + 1, maxIndex);
            }


            //if (minIndex >= maxIndex)
            //{
            //    return array;
            //}
            //
            //var pivotIndex = Separator(array, minIndex, maxIndex);
            //QuickSort(array, minIndex, pivotIndex - 1);
            //QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }


        static void Main(string[] args)
        {

            int[] array = new int[1000000];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-1,2);
            }

            
            int[] StandartSort(int[] array)
            {
                Array.Sort(array);
                Array.Reverse(array);
                return array;
            }


            int[] StrangeSort(int[] array)
            {
                int negativeOne = 0;
                int zero = 0;
                int one = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0)
                    {
                        one++;
                    }
                    if (array[i] < 0)
                    {
                        negativeOne++;
                    }
                    if (array[i] == 0)
                    {
                        zero++;
                    } 
                }


                int[] arrayOne = Enumerable.Repeat(1, one).ToArray();
                int[] arrayZero = Enumerable.Repeat(0, zero).ToArray();
                int[] arrayNegativeOne = Enumerable.Repeat(-1, negativeOne).ToArray();

                var resultArray = new int[array.Length];
                arrayOne.CopyTo(resultArray, 0);
                arrayZero.CopyTo(resultArray, arrayOne.Length);
                arrayNegativeOne.CopyTo(resultArray, arrayOne.Length+arrayZero.Length-1);

                return resultArray;
            }


            int[] BubleSort(int[] array)
            {

                var len = array.Length;
                for (var i = 1; i < len; i++)
                {
                    for (var j = 0; j < len - i; j++)
                    {
                        if (array[j] < array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }

                return array;
            }


            int[] QuickSort(int[] array)
            {
                return Program.QuickSort(array, 0, array.Length - 1);
            }

            int[] StrangeSort2(int[] array)
            {
                int[] sortArray = new int[array.Length];
                int one = 0;
                int negativeOne = array.Length - 1;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 1)
                    {
                        sortArray[one] = 1;
                        one++;
                    }
                    if (array[i] == -1)
                    {
                        sortArray[negativeOne] = -1;
                        negativeOne--;
                    }
                }

                return sortArray;
            }


            int[] LinqSort(int[] array)
            {
                var sortArray = from i in array
                                    orderby i
                                     select i;

                return sortArray.ToArray();
            }


            int[] TestTime(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {

                }
                return array;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            int[] tempArray = TestTime(array);

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);

        //   foreach (var item in tempArray)
        //  {
        //      Console.WriteLine(item);
        //  }


            Console.ReadKey();
        }
    }
}
