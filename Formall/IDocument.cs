using System;
using System.IO;

namespace Formall
{
    using Formall.Persistence;

    public interface IDocument
    {
        Stream Content { get; }

        IDocumentContext Context { get; }

        string Key { get; }

        string MediaType { get; }

        Metadata Metadata { get; }
    }
}
