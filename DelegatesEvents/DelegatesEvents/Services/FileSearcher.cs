using DelegatesEvents.Events;
using DelegatesEvents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Services
{
    public class FileSearcher : IFileSearcher
    {
        public event EventHandler<FileArgs> FileFound;
        private bool _cancelSearch = false;

        public void Search(string directory)
        {
            _cancelSearch = false;

            try
            {
                SearchDirectory(directory);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет доступа к каталогу: {directory}. Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске в каталоге {directory}: {ex.Message}");
            }
        }

        private void SearchDirectory(string directory)
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
                if (_cancelSearch) return;
                SearchDirectory(subDir);
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
}
