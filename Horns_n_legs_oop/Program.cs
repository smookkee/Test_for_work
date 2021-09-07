using System;
using System.Collections.Generic;

namespace Horns_n_legs_2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> list = new List<Animal>();
            list.Add(new Chicken());
            list.Add(new Rabbit());
            list.Add(new Goat());
            list.Add(new Cow());
            list.Add(new OneHornOneLeg());

            AnimalListGenerator generator = new AnimalListGenerator(list);

            generator.CountMaxAnimalsHunky2(4, 2);

            Console.WriteLine("Максимум животных:");
            foreach (var item in generator.resultDict)
            {
                Console.WriteLine("{0} - {1} штук.", item.value.Name(), item.count);
            }


            Console.WriteLine("end");
            Console.ReadKey();

        }
    }
}
