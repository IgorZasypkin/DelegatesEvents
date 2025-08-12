using DelegatesEvents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Helpers
{
    public class TestDataGenerator : ITestDataGenerator
    {
        public void CreateTestDirectory(string baseDir)
        {
            try
            {
                // Создаем базовую директорию
                Directory.CreateDirectory(baseDir);

                // Создаем подкаталоги
                CreateSubDirectory(baseDir, "Documents");
                CreateSubDirectory(baseDir, "Images");
                CreateSubDirectory(baseDir, "Work");

                // Создаем файлы
                CreateTestFile(baseDir, "readme.txt", "Это файл readme");
                CreateTestFile(baseDir, "stop_here.txt", "Этот файл должен остановить поиск");
                CreateTestFile(baseDir, "data.csv", "id,name\n1,Test");

                // Documents
                CreateTestFile(Path.Combine(baseDir, "Documents"), "report.docx", "Документ с отчетом");
                CreateTestFile(Path.Combine(baseDir, "Documents"), "notes.txt", "Важные заметки");

                // Images
                CreateTestFile(Path.Combine(baseDir, "Images"), "image1.jpg", "Файл изображения 1");
                CreateTestFile(Path.Combine(baseDir, "Images"), "image2.png", "Файл изображения 2");

                // Work
                CreateSubDirectory(Path.Combine(baseDir, "Work"), "Projects");
                CreateTestFile(Path.Combine(baseDir, "Work"), "todo.txt", "Список задач");
                CreateTestFile(Path.Combine(baseDir, "Work", "Projects"), "project1.csproj", "Проект 1");

                Console.WriteLine($"Тестовая структура создана в {baseDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании тестовой структуры: {ex.Message}");
            }
        }

        private void CreateSubDirectory(string basePath, string dirName)
        {
            Directory.CreateDirectory(Path.Combine(basePath, dirName));
        }

        private void CreateTestFile(string dirPath, string fileName, string content)
        {
            File.WriteAllText(Path.Combine(dirPath, fileName), content);
        }
    }
}
