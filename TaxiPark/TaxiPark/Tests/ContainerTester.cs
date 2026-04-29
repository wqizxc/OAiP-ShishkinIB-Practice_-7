using System;
using TaxiPark.Containers;
using TaxiPark.Helpers;
using TaxiPark.Models;

namespace TaxiPark.Tests
{
    public static class ContainerTester
    {
        public static void RunAllTests()
        {

            TestAddingElements();
            TestInsertOperation();
            TestRemoveOperation();
            TestErrorHandling();

            Console.WriteLine("\n ВСЕ ТЕСТЫ ЗАВЕРШЕНЫ ");
        }

        private static void TestAddingElements()
        {
            Console.WriteLine("ТЕСТ 1: Добавление 1000 элементов");
            Console.WriteLine(new string('-', 40));

            var taxiPark = new DynamicContainer<Car>();

            for (int i = 0; i < 1000; i++)
            {
                taxiPark.Add(CarDataGenerator.GenerateCar(i));
            }

            Console.WriteLine($" Добавлено машин: {taxiPark.Count}");
            Console.WriteLine($"\nПроверка доступа:");
            Console.WriteLine($"  Элемент [0]:   {taxiPark[0]}");
            Console.WriteLine($"  Элемент [500]: {taxiPark[500]}");
            Console.WriteLine($"  Элемент [999]: {taxiPark[999]}");
            Console.WriteLine();
        }

        private static void TestInsertOperation()
        {
            Console.WriteLine("ТЕСТ 2: Вставка элемента (Insert)");
            Console.WriteLine(new string('-', 40));

            var container = new DynamicContainer<Car>();

            for (int i = 0; i < 5; i++)
            {
                container.Add(CarDataGenerator.GenerateCar(i));
            }

            var newCar = CarDataGenerator.GenerateCustomCar(9999, "Tesla Model 3", "Иванов И.И.");
            container.Insert(2, newCar);

            Console.WriteLine($" Вставлена машина на позицию 2");
            Console.WriteLine($"  Новая машина: {container[2]}");
            Console.WriteLine($"  Общее количество: {container.Count}");
            Console.WriteLine();
        }

        private static void TestRemoveOperation()
        {
            Console.WriteLine("ТЕСТ 3: Удаление элемента (RemoveAt)");
            Console.WriteLine(new string('-', 40));

            var container = new DynamicContainer<Car>();

            for (int i = 0; i < 5; i++)
            {
                container.Add(CarDataGenerator.GenerateCar(i));
            }

            Console.WriteLine($"До удаления: {container.Count} элементов");
            container.RemoveAt(1);
            Console.WriteLine($" Удалён элемент с индексом 1");
            Console.WriteLine($"После удаления: {container.Count} элементов");
            Console.WriteLine();
        }

        private static void TestErrorHandling()
        {
            Console.WriteLine("ТЕСТ 4: Проверка защиты от ошибок");
            Console.WriteLine(new string('-', 40));

            var container = new DynamicContainer<Car>();
            container.Add(CarDataGenerator.GenerateCar(0));

            try
            {
                var car = container[100];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($" Чтение: {ex.Message}");
            }

            try
            {
                container.RemoveAt(50);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($" Удаление: {ex.Message}");
            }

            try
            {
                container.Insert(10, CarDataGenerator.GenerateCar(1));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($" Вставка: {ex.Message}");
            }
        }
    }
}