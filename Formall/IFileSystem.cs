using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public interface IFileSystem
    {
        DateTime CreationTime { get; }

        string FullName { get; }

        DateTime LastAccessTime { get; }

        DateTime LastWriteTime { get; }
    }
}
