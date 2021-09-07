﻿using System;
using System.Collections.Generic;

namespace Horns_n_legs_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* У меня нет навыков фронт разработки, поэтому первую попытку решения задачи в проекте Hornds_n_legs я решил сделать консольной полностью и
             * без какой-либо логики. Прикрутить туда фронт не составило бы труда, но задача была решена слишком просто.
             * 
             * Поэтому я решил сделать её масштабируемой и уйти от заранее указанного списка животных и сделать систему, которая бы составляла списки
             * при любом количестве животных, ориентируясь на их характеристиках, а не на моих заранее определенных логических операциях.
             * 
             * Данные классы не зависят от консоли и к ним без проблем можно поднять любой фронт.
             * 
             * Краткое описание логики:
             * 
             * В классе Animal_List содержатся все животные с методами, которые они обязаны иметь для корректной работы программы. Туда можно добавить любое
             * количество новых видов и задать им характеристики. После этого в методе Main() в лист List<Animal> list добавить экземпляр нового вида.
             *
             * Дальше в класс AnimalListGenerator при создании нужно отправить данный list с экземплярами животныХ, после чего на экземпляре генератора вызвать
             * необходимый метод.
             * 
             * Внутри класса генератора листа животных я оставил по 2 реализации каждого класса, т.к. сначала сделал 4 очень похожих метода, где было достаточно
             * много повторного использования когда. Поэтому я решил седалать один метод с двумя входящими булевыми флагами, которые определяют его поведение и
             * выходящий результат.
             * 
             * 
             * Методы, которые считают max\min количество животных, основаны на логике количества конечностей (рог считаем за конечность) у животного. Чем выше индекс,
             * тем приоритетнее данное животное для создания списка.
             * 
             * При добавлении условия максимального веса, мы добавляем к данному индексу еще и вес, получая там образом индекс "веса" каждой конечности у данного животного.
             * Если нам требуется максимальный вес, то ищем животного с максимальным индексом. Иначе - с минимальным индексом.
             * 
             * Пример:
             * 
             * Если нам требуется получить максимальный вес из 4 ног, то выбирая между курицей (0.7 кг) и кроликом (1кг) мы получим следующее:
             * 
             * курица: (1/(количество ног)) * вес = (1/2)*0.7 =   0.35
             * Кролик: (1/(количество ног)) * вес = (1/4)*1 = 0.25 
             * 
             * Т.е. брать кролика невыгодно для достижения максимального веса.
             */



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
