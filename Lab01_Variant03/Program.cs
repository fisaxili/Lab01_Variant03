// See https://aka.ms/new-console-template for more information
using System;

namespace Lab01_Variant03
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                Console.WriteLine("  КОНВЕРТЕР ТЕМПЕРАТУР (Вариант 3)");
                Console.WriteLine("1 - Перевод в Фаренгейты");
                Console.WriteLine("2 - Перевод в Кельвины");
                Console.WriteLine("3 - Разница и сравнение шкал");
                Console.WriteLine("4 - Выход");
                Console.WriteLine("Выберите пункт меню:");

                string input = Console.ReadLine();   

                // Проверка на пустой ввод
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка. Ввод не может быть пустым.");
                    continue;
                }

                // Проверка, что введено число
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Ошибка. Необходимо ввести целое число.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ConvertToFahrenheit();
                        break;

                    case 2:
                        ConvertToKelvin();
                        break;

                    case 3:
                        CompareScales();
                        break;

                    case 4:
                        Console.WriteLine("Выход из программы");
                        break;
                    default: 
                        Console.WriteLine("Неверный ввод данных.Выберите один из пунктов от 1 до 4");
                        break;
                }


            } while (choice != 4);
        }

        //Ввод температуры
 
        static double ReadTemperature()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите температуру в градусах Цельсия: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Ошибка. Ввод не может быть пустым.");
                        continue;
                    }

                    input = input.Replace('.', ',');

                    if (!double.TryParse(input, out double celsius))
                    {
                        Console.WriteLine("Ошибка. Введите корректное число.");
                        continue;
                    }

                    // Проверка физического ограничения
                    if (celsius < -273.15)
                    {
                        Console.WriteLine("Ошибка. Температура ниже абсолютного нуля невозможна.");
                        continue;
                    }

                    return celsius;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                }
            }
        }

        // Задача 1
        static void ConvertToFahrenheit()
        {
            double celsius = ReadTemperature();
            double fahrenheit = celsius * 1.8 + 32;

            Console.WriteLine($"Температура в Фаренгейтах: {fahrenheit:F2} °F");
        }

        // Задача 2
        static void ConvertToKelvin()
        {
            double celsius = ReadTemperature();
            double kelvin = celsius + 273.15;

            Console.WriteLine($"Температура в Кельвинах: {kelvin:F2} K");
        }

        // Задача 3
        static void CompareScales()
        {
            double celsius = ReadTemperature();

            double fahrenheit = celsius * 1.8 + 32;
            double kelvin = celsius + 273.15;
            double difference = Math.Abs(fahrenheit - kelvin);

            Console.WriteLine($"Температура в Фаренгейтах: {fahrenheit:F2} °F");
            Console.WriteLine($"Температура в Кельвинах:   {kelvin:F2} K");
            Console.WriteLine($"Разница между шкалами:     {difference:F2}");

            if (fahrenheit > kelvin)
                Console.WriteLine("Фаренгейт даёт большее числовое значение.");
            else if (kelvin > fahrenheit)
                Console.WriteLine("Кельвин даёт большее числовое значение.");
            else
                Console.WriteLine("Числовые значения равны.");
        }
    }
}