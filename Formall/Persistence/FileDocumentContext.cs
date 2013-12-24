using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public class FileDocumentContext : IDataContext
    {
        private readonly DirectoryInfo _directory;

        public FileDocumentContext(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public DirectoryInfo Directory
        {
            get { return _directory; }
        }

        #region - IDocumentContext -

        IResult IDocumentContext.Delete(string key)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(Stream stream, ContentType type, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(TextReader reader, ContentType type, Metadata metadata)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        IDocument[] IDocumentContext.Read(int skip, int take)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Read(string key)
        {
            throw new NotImplementedException();
        }

        IDocument[] IDocumentContext.Read(string keyPrefix, int skip, int take)
        {
            throw new NotImplementedException();
        }

        #endregion - IDocumentContext -

        #region - IDataContext -

        IRepository IDataContext.CreateRepository(string name)
        {
            throw new NotImplementedException();
        }

        IEntity IDataContext.Import(IEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion - IDataContext -
    }
}
