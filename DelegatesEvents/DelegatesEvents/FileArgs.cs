using System;
using System.IO;

public class FileArgs : EventArgs
{
    public string FileName { get; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}

public class FileSearcher
{
    public event EventHandler<FileArgs> FileFound;
    private bool _cancelSearch = false;

    public void Search(string directory)
    {
        _cancelSearch = false;

        try
        {
            foreach (var file in Directory.EnumerateFiles(directory))
            {
                if (_cancelSearch)
                {
                    Console.WriteLine("Поиск отменён.");
                    return;
                }

                OnFileFound(new FileArgs(file));
            }

            foreach (var subDir in Directory.EnumerateDirectories(directory))
            {
                if (_cancelSearch)
                {
                    Console.WriteLine("Поиск отменён.");
                    return;
                }

                Search(subDir);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к каталогу: {directory}");
        }
    }

    public void Cancel()
    {
        _cancelSearch = true;
    }

    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}