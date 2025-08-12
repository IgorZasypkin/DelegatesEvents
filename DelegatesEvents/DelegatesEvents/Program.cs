using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string baseDir = @"C:\TestDirectory";

        try
        {
            // Создаем базовую директорию (если не существует)
            Directory.CreateDirectory(baseDir);

            // Создаем подкаталоги
            Directory.CreateDirectory(Path.Combine(baseDir, "Documents"));
            Directory.CreateDirectory(Path.Combine(baseDir, "Images"));
            Directory.CreateDirectory(Path.Combine(baseDir, "Work"));

            // Создаем файлы в корневой директории
            File.WriteAllText(Path.Combine(baseDir, "readme.txt"), "Это файл readme");
            File.WriteAllText(Path.Combine(baseDir, "stop_here.txt"), "Этот файл должен остановить поиск");
            File.WriteAllText(Path.Combine(baseDir, "data.csv"), "id,name\n1,Test");

            // Создаем файлы в Documents
            File.WriteAllText(Path.Combine(baseDir, "Documents", "report.docx"), "Документ с отчетом");
            File.WriteAllText(Path.Combine(baseDir, "Documents", "notes.txt"), "Важные заметки");

            // Создаем файлы в Images
            File.WriteAllText(Path.Combine(baseDir, "Images", "image1.jpg"), "Файл изображения 1");
            File.WriteAllText(Path.Combine(baseDir, "Images", "image2.png"), "Файл изображения 2");

            // Создаем файлы в Work (включая подкаталог)
            Directory.CreateDirectory(Path.Combine(baseDir, "Work", "Projects"));
            File.WriteAllText(Path.Combine(baseDir, "Work", "todo.txt"), "Список задач");
            File.WriteAllText(Path.Combine(baseDir, "Work", "Projects", "project1.csproj"), "Проект 1");

            Console.WriteLine("Тестовая структура создана в C:\\TestDirectory");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании тестовой структуры: {ex.Message}");
        }

        // 1. Тестирование функции GetMax
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 20 }
        };

        var oldestPerson = people.GetMax(p => p.Age);
        Console.WriteLine($"Самый старший человек: {oldestPerson.Name}, возраст: {oldestPerson.Age}");

        var products = new List<Product>
        {
            new Product { Name = "Apple", Price = 1.5f },
            new Product { Name = "Banana", Price = 2.0f },
            new Product { Name = "Orange", Price = 1.2f }
        };

        var mostExpensiveProduct = products.GetMax(p => p.Price);
        Console.WriteLine($"Самый дорогой продукт: {mostExpensiveProduct.Name}, цена: {mostExpensiveProduct.Price}");

        // 2. Тестирование FileSearcher
        var searcher = new FileSearcher();
        searcher.FileFound += (sender, e) =>
        {
            Console.WriteLine($"Найден файл: {e.FileName}");

            // Пример условия для отмены поиска
            if (e.FileName.Contains("stop"))
            {
                Console.WriteLine("Файл с ключевым словом 'stop' найден - отмена поиска.");
                ((FileSearcher)sender).Cancel();
            }
        };

        Console.WriteLine("\nНачинаем поиск файлов:");
        searcher.Search(@"C:\TestDirectory"); // Укажите путь к тестовой директории
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Product
{
    public string Name { get; set; }
    public float Price { get; set; }
}