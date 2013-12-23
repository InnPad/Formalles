using System;
using System.IO;

namespace Formall
{
    using Formall.Persistence;

    public interface IDocument
    {
        Stream Content { get; }

        ContentType ContentType { get; }

        IDocumentContext Context { get; }

        string Key { get; }

        Metadata Metadata { get; }
    }
}
