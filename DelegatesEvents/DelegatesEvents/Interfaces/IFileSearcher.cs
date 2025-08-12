using DelegatesEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Interfaces
{
    public interface IFileSearcher
    {
        event EventHandler<FileArgs> FileFound;
        void Search(string directory);
        void Cancel();
    }
}
