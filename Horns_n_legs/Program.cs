using System;

namespace Horns_n_legs
{

    //куры, кролики, козы и коровы
    class Program
    {
        public static void CountMaxAnimalsHunky(int legs, int horns)
        {
            int goats = 0;
            int chicken = 0;
            while(horns>=2 && legs >= 4)
            {
                legs -= 4;
                horns -= 2;
                goats++;
            }

            while (legs >=2)
            {
                legs -= 2;
                chicken++;
            }

            Console.WriteLine("Максимум животных без остатка: Овец - {0}, кур - {1}. Остатки: ноги - {2}, рога {3}.", goats, chicken, legs, horns);
        }

        //в задаче не указано, что мы должны использовать все рога обязательно, поэтому вариант только
        //с курами даст действительно максимальный результат в выборке с максимальным количеством животных
        public static void CountMaxAnimalsCheat(int legs, int horns) 
        {                                                              
            int chicken = 0;
            while (legs >= 2)
            {
                legs -= 2;
                chicken++;
            }

            Console.WriteLine("Максимум животных с остатком:  кур - {0}. Остатки: ноги - {1}, рога {2}.", chicken, legs, horns);
        }

        public static void CountMinAnimals(int legs, int horns)
        {
            int chicken = 0;
            int goats = 0;
            int rabbits = 0;
            while (horns >= 2 && legs >= 4)
            {
                legs -= 4;
                horns -= 2;
                goats++;
            }

            while (legs >= 4)
            {
                legs -= 4;
                rabbits++;
            }

            while (legs >= 2)
            {
                legs -= 2;
                chicken++;
            }

            Console.WriteLine("Минимум животных: Овец - {0}, кроликов - {1}, кур - {2}. Остатки: ноги - {3}, рога {4}.", goats, rabbits, chicken, legs, horns);
        }

        public static void CountMaxWeight(int legs, int horns)
        {
            int cows = 0;
            int rabbits = 0;
            int chicken = 0;
            while (horns >= 2 && legs >= 4)
            {
                legs -= 4;
                horns -= 2;
                cows++;
            }
            while (legs >= 4)
            {
                legs -= 4;
                rabbits++;
            }
            while (legs >= 2)
            {
                legs -= 2;
                chicken++;
            }

            Console.WriteLine("Максимальный вес животных: коров - {0}, кроликов - {1}, кур - {2}. Остатки: ноги - {3}, рога {4}.", cows, rabbits, chicken, legs, horns);
        }






        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество ног");
            int legs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество рогов");
            int horns = Convert.ToInt32(Console.ReadLine());

            CountMaxAnimalsHunky(legs, horns);
            CountMaxAnimalsCheat(legs, horns);
            CountMinAnimals(legs, horns);
            CountMaxWeight(legs, horns);

            Console.WriteLine("Комбинация с наименьшим суммарным весом = комбинации с наименьшим количеством животных");


            Console.ReadKey();
        }
    }
}
