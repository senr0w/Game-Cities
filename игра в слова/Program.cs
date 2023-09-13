
using System;
using System.Collections.Generic;

class Program
{
    static List<string> cities = new List<string>() { "Москва", "Киев", "Минск", "Астана", "Санкт-Петербург", "Новосибирск", "Владивосток", "Нью-Йорк", "Париж", "Лондон" };
    static string previousCity = "";

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру в города! Начните игру, введя город.");

        while (true)
        {
            Console.Write("Ваш ход: ");
            string playerCity = Console.ReadLine().Trim();

            if (!IsValidCity(playerCity))
            {
                Console.WriteLine("Неверный город! Попробуйте снова.");
                continue;
            }

            if (!IsCityAvailable(playerCity))
            {
                Console.WriteLine("Этот город уже был назван или не существует! Попробуйте другой город.");
                continue;
            }

            cities.Remove(playerCity);
            Console.WriteLine($"Вы: {playerCity}");

            string computerCity = GetComputerCity(playerCity);

            if (computerCity == "")
            {
                Console.WriteLine("Нет доступных городов. Вы выиграли!");
                break;
            }

            cities.Remove(computerCity);
            Console.WriteLine($"Компьютер: {computerCity}");

            previousCity = computerCity;
        }
    }

    static bool IsValidCity(string city)
    {
        if (city.Length == 0 || !char.IsLetter(city[0]))
        {
            return false;
        }

        for (int i = 1; i < city.Length; i++)
        {
            if (!char.IsLetter(city[i]) && city[i] != '-')
            {
                return false;
            }
        }

        return true;
    }

    static bool IsCityAvailable(string city)
    {
        return !previousCity.Equals(city, StringComparison.OrdinalIgnoreCase) && cities.Contains(city, StringComparer.OrdinalIgnoreCase);
    }

    static string GetComputerCity(string playerCity)
    {
        foreach (string city in cities)
        {
            if (char.ToUpper(city[0]) == char.ToUpper(playerCity[playerCity.Length - 1]))
            {
                return city;
            }
        }

        return "";
    }
}
