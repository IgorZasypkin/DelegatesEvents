using DelegatesEvents.Extensions;
using DelegatesEvents.Interfaces;
using DelegatesEvents.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Services
{
    public class DemoService
    {
        private readonly IFileSearcher _fileSearcher;
        private readonly ITestDataGenerator _testDataGenerator;
        private readonly AppSettings _settings;

        public DemoService(
            IFileSearcher fileSearcher,
            ITestDataGenerator testDataGenerator,
            IOptions<AppSettings> settings)
        {
            _fileSearcher = fileSearcher;
            _testDataGenerator = testDataGenerator;
            _settings = settings.Value;
        }

        public void RunDemo()
        {
            // 1. Создаем тестовые данные
            _testDataGenerator.CreateTestDirectory(_settings.TestDirectoryPath);

            // 2. Демонстрация поиска максимального элемента
            DemonstrateGetMax();

            // 3. Демонстрация поиска файлов
            DemonstrateFileSearch();
        }

        private void DemonstrateGetMax()
        {
            var people = new List<Person>
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 20 }
            };

            var oldestPerson = people.GetMax(p => p.Age);
            Console.WriteLine($"\nСамый старший человек: {oldestPerson?.Name}, возраст: {oldestPerson?.Age}");

            var products = new List<Product>
            {
                new Product { Name = "Apple", Price = 1.5f },
                new Product { Name = "Banana", Price = 2.0f },
                new Product { Name = "Orange", Price = 1.2f }
            };

            var mostExpensiveProduct = products.GetMax(p => p.Price);
            Console.WriteLine($"Самый дорогой продукт: {mostExpensiveProduct?.Name}, цена: {mostExpensiveProduct?.Price}");
        }

        private void DemonstrateFileSearch()
        {
            _fileSearcher.FileFound += (sender, e) =>
            {
                Console.WriteLine($"Найден файл: {e.FileName}");

                if (e.FileName.Contains("stop_here.txt"))
                {
                    Console.WriteLine("Файл 'stop_here.txt' найден - отмена поиска.");
                    ((IFileSearcher)sender).Cancel();
                }
            };

            Console.WriteLine("\nНачинаем поиск файлов:");
            _fileSearcher.Search(_settings.TestDirectoryPath);
        }
    }
}
