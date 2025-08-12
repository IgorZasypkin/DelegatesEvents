using System;
using System.IO;

class TestDirectoryCreator
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
    }
}