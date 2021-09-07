using System;
using System.Collections.Generic;

namespace Horns_n_legs_2
{

    class Box
    {
        public Animal value;
        public int count;


        public Box(Animal value1, int count1)
        {
            value = value1;
            count = count1;

        }
    }

    class AnimalListGenerator
    {
        public List<Animal> listAnimal = new List<Animal>();   // Входящий набор животных, которые будут анализироваться для создания каждой комбинации. Животных может быть любое количество 

        public List<Box> resultDict = new List<Box>();
        public AnimalListGenerator(List<Animal> listAnimal)
        {
            this.listAnimal = listAnimal;
        }


        #region Первый набор методов с повторяющимся кодом

        // Этот набор методов записывает результат в лист внутри экземпляра класса. Это неверное решение, но решил оставить это тут как первую итерацию
        public void CountMaxAnimalsHunky(int legs, int horns)
        {
            resultDict = new List<Box>();

            int count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством рогов и ногов большим, чем дано по условию
                {
                    count++;
                    if (animal.Horns() <= horns && animal.Legs() <= legs && animal.Horns() > 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, true);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством НОГ больше, чес осталось
                {
                    count++;
                    if (animal.Legs() <= legs)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, false);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            void TakeAnimals(ref int legs, ref int horns, Animal matches, bool needHorn)
            {

                Animal tempAnimal = matches;
                int countTempAnimal = 0;

                foreach (var animal in listAnimal)
                {
                    if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                    {
                        if (animal.Horns() > 0)
                        {
                            if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) < (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы конечностей к единице. Т.е. с самым малым компонентов
                            animal.Horns() <= horns && animal.Legs() <= legs)                                                                        //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                            {
                                tempAnimal = animal;
                            }
                        }
                    }

                    if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                    {
                        if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) < (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы конечностей к единице. Т.е. с самым малым компонентов
                           animal.Horns() <= horns && animal.Legs() <= legs)                                                                        //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                        {
                            tempAnimal = animal;
                        }
                    }

                }

                if (needHorn)
                {
                    while (horns >= tempAnimal.Horns() && legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        horns -= tempAnimal.Horns();
                        countTempAnimal++;
                    }
                }

                if (!needHorn)
                {
                    while (legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        countTempAnimal++;
                    }
                }
                resultDict.Add(new Box(tempAnimal, countTempAnimal));
            }

        }

        public void CountMinAnimals(int legs, int horns)  // от метода CountMaxAnimalsHunky данный методо отличается только условием проверки индекса отношения 1 к конечностям животных. Здесь животные с минимальным индексом в приоритете
        {
            resultDict = new List<Box>();
            int count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством рогов и ногов большим, чем дано по условию
                {
                    count++;
                    if (animal.Horns() <= horns && animal.Legs() <= legs && animal.Horns() > 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, true);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством НОГ больше, чес осталось
                {
                    count++;
                    if (animal.Legs() <= legs && animal.Horns() == 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, false);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.

                        break;
                    }
                }
            }

            void TakeAnimals(ref int legs, ref int horns, Animal matches, bool needHorn)
            {

                Animal tempAnimal = matches;
                int countTempAnimal = 0;

                foreach (var animal in listAnimal)
                {
                    if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                    {
                        if (animal.Horns() > 0)
                        {
                            if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) > (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с минимальным отношнием суммы конечностей к единице. Т.е. с самым большим количеством конечностей
                            animal.Horns() <= horns && animal.Legs() <= legs)                                                                               //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                            {
                                tempAnimal = animal;
                            }
                        }
                    }

                    if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                    {
                        if (animal.Legs() < legs)
                        {
                            if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) > (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы НОГ к единице. Т.е. с самым большим количеством ног при отсутствии рогов
                         animal.Horns() <= horns && animal.Horns() == 0)                                                    //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                            {
                                tempAnimal = animal;
                            }
                        }
                    }

                }

                if (needHorn)   //Считаем сколько животных типа, который мы определили, мы сможем выбрать из данного нам списка. needHorn определяет по какой ветке идет код. В данном случае мы рассматриваем животных с рогами
                {
                    while (horns >= tempAnimal.Horns() && legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        horns -= tempAnimal.Horns();
                        countTempAnimal++;
                    }
                }

                if (!needHorn)  //В данном случае мы рассматриваем животных с без рогов
                {
                    while (legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        countTempAnimal++;
                    }
                }

                resultDict.Add(new Box(tempAnimal, countTempAnimal));

            }

        }

        public void CountMaxWeight(int legs, int horns)
        {
            resultDict = new List<Box>();
            int count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством рогов и ногов большим, чем дано по условию
                {
                    count++;
                    if (animal.Horns() <= horns && animal.Legs() <= legs && animal.Horns() > 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, true);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством НОГ больше, чес осталось
                {
                    count++;
                    if (animal.Legs() <= legs && animal.Horns() == 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, false);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.

                        break;
                    }
                }
            }


            void TakeAnimals(ref int legs, ref int horns, Animal matches, bool needHorn)
            {

                Animal tempAnimal = matches;
                int countTempAnimal = 0;

                foreach (var animal in listAnimal)
                {
                    if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                    {
                        if (animal.Horns() > 0)
                        {
                            if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() < ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&  //здесь ищем животное, с максимальным "весом" каждой конечности. т.е. (1/(сумма конечностей))*вес
                                     animal.Horns() <= horns && animal.Legs() <= legs)                                                                                                                           // Если у нас 4 ноги, то 2 курицы по 0.7 будут весить больше, чем кролик в 1кг с 4 лапами.  
                            {                                                                                                                                                                           //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                tempAnimal = animal;
                            }
                        }
                    }

                    if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                    {
                        if (animal.Legs() < legs)
                        {
                            if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() < ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&   //Все тоже самое, что и для if (needHorn), только для животных без рогов.
                                     animal.Horns() <= horns && animal.Horns() == 0)

                            {
                                tempAnimal = animal;
                            }
                        }
                    }

                }

                if (needHorn)   //Считаем сколько животных типа, который мы определили, мы сможем выбрать из данного нам списка. needHorn определяет по какой ветке идет код. В данном случае мы рассматриваем животных с рогами
                {
                    while (horns >= tempAnimal.Horns() && legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        horns -= tempAnimal.Horns();
                        countTempAnimal++;
                    }
                }

                if (!needHorn)  //В данном случае мы рассматриваем животных с без рогов
                {
                    while (legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        countTempAnimal++;
                    }
                }

                resultDict.Add(new Box(tempAnimal, countTempAnimal));

            }








        }

        public void CountMinWeight(int legs, int horns)
        {
            resultDict = new List<Box>();
            int count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством рогов и ногов большим, чем дано по условию
                {
                    count++;
                    if (animal.Horns() <= horns && animal.Legs() <= legs && animal.Horns() > 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, true);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством НОГ больше, чес осталось
                {
                    count++;
                    if (animal.Legs() <= legs && animal.Horns() == 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, false);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.

                        break;
                    }
                }
            }


            void TakeAnimals(ref int legs, ref int horns, Animal matches, bool needHorn)
            {

                Animal tempAnimal = matches;
                int countTempAnimal = 0;

                foreach (var animal in listAnimal)
                {
                    if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                    {
                        if (animal.Horns() > 0)
                        {
                            if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() > ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&  //здесь ищем животное, с максимальным "весом" каждой конечности. т.е. (1/(сумма конечностей))*вес
                                     animal.Horns() <= horns && animal.Legs() <= legs)                                                                                                                           // Если у нас 4 ноги, то 2 курицы по 0.7 будут весить больше, чем кролик в 1кг с 4 лапами.  
                            {                                                                                                                                                                           //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                tempAnimal = animal;
                            }
                        }
                    }

                    if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                    {
                        if (animal.Legs() < legs)
                        {
                            if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() > ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&   //Все тоже самое, что и для if (needHorn), только для животных без рогов.
                                     animal.Horns() <= horns && animal.Horns() == 0)

                            {
                                tempAnimal = animal;
                            }
                        }
                    }

                }

                if (needHorn)   //Считаем сколько животных типа, который мы определили, мы сможем выбрать из данного нам списка. needHorn определяет по какой ветке идет код. В данном случае мы рассматриваем животных с рогами
                {
                    while (horns >= tempAnimal.Horns() && legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        horns -= tempAnimal.Horns();
                        countTempAnimal++;
                    }
                }

                if (!needHorn)  //В данном случае мы рассматриваем животных с без рогов
                {
                    while (legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        countTempAnimal++;
                    }
                }

                resultDict.Add(new Box(tempAnimal, countTempAnimal));

            }

        }
        #endregion


        #region Попытка вынести повторяющийся код в отдельный метод с управляющими флагами
        //методы ниже отдают лист с экземплярами класса Box при обращении к ним. Внутри Box лежит экземпляр животного и их количество

        public List<Box> CountMaxAnimalsHunky2(int legs,int horns)
        {
            return CountThem(legs, horns, true, false);
        }

        public List<Box> CountMinAnimalsy2(int legs, int horns)
        {
            return CountThem(legs, horns, false, false);
        }

        public List<Box> CountMaxWeight2(int legs, int horns)
        {
            return CountThem(legs, horns, true, true);
        }

        public List<Box> CountMinWeight2(int legs, int horns)
        {
            return CountThem(legs, horns, false, true);
        }


        //Сократить удалось не все: циклы выбора животного на основе наличия рогов и их отсутствия + логику подсчета количества возможных животных найденного типа
        public List<Box> CountThem(int legs, int horns, bool max, bool weight)
        {
            List<Box> resultlist = new List<Box>();

            int count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством рогов и ногов большим, чем дано по условию
                {
                    count++;
                    if (animal.Horns() <= horns && animal.Legs() <= legs && animal.Horns() > 0)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, true, max, weight);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            count = 0;
            while (count <= listAnimal.Count)
            {

                foreach (Animal animal in listAnimal)      //проверяем, есть ли хотя бы одно животное с количеством НОГ больше, чес осталось
                {
                    count++;
                    if (animal.Legs() <= legs)
                    {
                        count = 0;
                        TakeAnimals(ref legs, ref horns, animal, false, max, weight);    //если находим такое, то сразу запускаем метод обработки и поиска лучшего экземпляра.
                        break;
                    }
                }
            }

            return resultlist;

            void TakeAnimals(ref int legs, ref int horns, Animal matches, bool needHorn, bool max, bool weight)
            {

                Animal tempAnimal = matches;
                int countTempAnimal = 0;

                foreach (var animal in listAnimal)
                {
                    if (!weight)
                    {
                        //максимум животных
                        if (max)  
                        {
                           
                            if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                            {
                                if (animal.Horns() > 0)
                                {
                                    if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) < (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы конечностей к единице. Т.е. с самым малым компонентов
                                    animal.Horns() <= horns && animal.Legs() <= legs)                                                                        //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                    {
                                        tempAnimal = animal;
                                    }
                                }
                            }

                            if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                            {
                                if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) < (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы конечностей к единице. Т.е. с самым малым компонентов
                                   animal.Horns() <= horns && animal.Legs() <= legs)                                                                        //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                {
                                    tempAnimal = animal;
                                }
                            }



                        }


                        //минимум животных
                        if (!max)
                        {
                            if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                            {
                                if (animal.Horns() > 0)
                                {
                                    if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) > (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с минимальным отношнием суммы конечностей к единице. Т.е. с самым большим количеством конечностей
                                    animal.Horns() <= horns && animal.Legs() <= legs)                                                                               //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                    {
                                        tempAnimal = animal;
                                    }
                                }
                            }

                            if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                            {
                                if (animal.Legs() < legs)
                                {
                                    if ((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs()) > (decimal)1 / ((decimal)animal.Horns() + animal.Legs()) &&   //здесь ищем животное, с максимальным отношнием суммы НОГ к единице. Т.е. с самым большим количеством ног при отсутствии рогов
                                 animal.Horns() <= horns && animal.Horns() == 0)                                                    //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                    {
                                        tempAnimal = animal;
                                    }
                                }
                            }

                        }

                    }


                    if (weight)
                    {
                        //максимальный вес
                        if (max)
                        {
                            if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                            {
                                if (animal.Horns() > 0)
                                {
                                    if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() < ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&  //здесь ищем животное, с максимальным "весом" каждой конечности. т.е. (1/(сумма конечностей))*вес
                                             animal.Horns() <= horns && animal.Legs() <= legs)                                                                                                                           // Если у нас 4 ноги, то 2 курицы по 0.7 будут весить больше, чем кролик в 1кг с 4 лапами.  
                                    {                                                                                                                                                                           //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                        tempAnimal = animal;
                                    }
                                }
                            }

                            if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                            {
                                if (animal.Legs() < legs)
                                {
                                    if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() < ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&   //Все тоже самое, что и для if (needHorn), только для животных без рогов.
                                             animal.Horns() <= horns && animal.Horns() == 0)

                                    {
                                        tempAnimal = animal;
                                    }
                                }
                            }






                        }


                        //минимальный вес
                        if (!max)
                        {

                            if (needHorn) //состояние, если мы ищем идеальное животное для количества, которое имеет рога
                            {
                                if (animal.Horns() > 0)
                                {
                                    if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() > ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&  //здесь ищем животное, с максимальным "весом" каждой конечности. т.е. (1/(сумма конечностей))*вес
                                             animal.Horns() <= horns && animal.Legs() <= legs)                                                                                                                           // Если у нас 4 ноги, то 2 курицы по 0.7 будут весить больше, чем кролик в 1кг с 4 лапами.  
                                    {                                                                                                                                                                           //Исходим из логики, что все животные имеют ноги, но не все имеют рога
                                        tempAnimal = animal;
                                    }
                                }
                            }

                            if (!needHorn) //состояние, если мы ищем идеальное животное для количества, которое не имеет рогов
                            {
                                if (animal.Legs() < legs)
                                {
                                    if (((decimal)1 / ((decimal)tempAnimal.Horns() + tempAnimal.Legs())) * tempAnimal.Weight() > ((decimal)1 / ((decimal)animal.Horns() + animal.Legs())) * animal.Weight() &&   //Все тоже самое, что и для if (needHorn), только для животных без рогов.
                                             animal.Horns() <= horns && animal.Horns() == 0)

                                    {
                                        tempAnimal = animal;
                                    }
                                }
                            }



                        }

                    }

                }

                //===============================================Обязательная часть===============================================================================
                if (needHorn)
                {
                    while (horns >= tempAnimal.Horns() && legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        horns -= tempAnimal.Horns();
                        countTempAnimal++;
                    }
                }

                if (!needHorn)
                {
                    while (legs >= tempAnimal.Legs())
                    {
                        legs -= tempAnimal.Legs();
                        countTempAnimal++;
                    }
                }

                resultDict.Add(new Box(tempAnimal, countTempAnimal));

            }

        }

        #endregion


    }
}
