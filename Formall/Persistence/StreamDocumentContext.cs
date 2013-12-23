using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public abstract class StreamDocumentContext : IDocumentContext
    {
        IResult IDocumentContext.Delete(string key)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(System.IO.Stream stream, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(System.IO.TextReader reader, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Read(string key)
        {
            throw new NotImplementedException();
        }

        IDocument[] IDocumentContext.Read(int skip, int take)
        {
            throw new NotImplementedException();
        }

        IDocument[] IDocumentContext.Read(string keyPrefix, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
