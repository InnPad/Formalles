using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Reflection;

    public interface IDocumentContext
    {
        IResult Delete(string key);

        IDocument Import(Stream stream, Metadata metadata);

        IDocument Import(TextReader reader, Metadata metadata);

        IDocument Import(IDocument document);

        IDocument Read(string key);

        IDocument[] Read(int skip, int take);

        IDocument[] Read(string keyPrefix, int skip, int take);
    }
}
