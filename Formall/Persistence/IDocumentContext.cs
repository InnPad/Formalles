using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IDocumentContext
    {
        IResult Delete(string key);

        IDocument Import(Stream stream);

        IDocument Import(TextReader reader);

        IDocument Import(IDocument document);

        IDocument[] Read(int skip, int take);

        IDocument Read(string key);

        IDocument[] Read(string keyPrefix, int skip, int take);

        IResult Store(ref IDocument document);
    }
}
