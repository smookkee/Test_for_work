using System;

namespace Test_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[24];

            Random rnd = new Random();
            int rndDel = rnd.Next(array.Length - 1);
            Console.WriteLine(rndDel+1);

            bool flag = true;

            for (int i = 0; i < array.Length+1; i++)
            {


                if (i != rndDel && flag)
                {
                    array[i] = i + 1;
                    Console.Write(i + 1 + " ");
                }

                if (i != rndDel && !flag)
                {
                    array[i-1] = i + 1;
                    Console.Write(i + 1 + " ");
                }

                if (i == rndDel)
                {
                   flag= !flag;
                }
                
            }


            int FindMissedNumber(int[] array)
            {
                int sum = 0;
                
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];

                }

                int realSum = 0;
                for (int i = 1; i <= array.Length+1; i++)
                {
                    realSum += i;
                }

                return (realSum - sum);
            }
            Console.WriteLine();
            Console.WriteLine(FindMissedNumber(array));


            #region первая попытка
            /*
            int FindMissedNumber(int[] array)
            {
                int sum = 0;
                int max = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                    if (array[i]>max)
                    max = array[i];
                }

                int realSum = 0;
                for (int i = 1; i <= max; i++)
                {
                    realSum += i;
                }

                return (realSum - sum);
            }

            Console.WriteLine("Ответ = " + FindMissedNumber(array));
            */
            #endregion


            Console.ReadKey();
        }
    }
}
