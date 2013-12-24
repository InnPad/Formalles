using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public class FileDocument : IDocument
    {
        private readonly FileDocumentContext _context;
        private readonly Metadata _metadata;
        private readonly string _name;
        private readonly ContentType _type;

        public FileDocument(string name, ContentType type, Metadata metadata, FileDocumentContext context)
        {
            _name = name;
            _type = type;
            _metadata = metadata;
            _context = context;
        }

        public Stream Content
        {
            get { throw new NotImplementedException(); }
        }

        public ContentType ContentType
        {
            get { return _type; }
        }

        public FileDocumentContext Context
        {
            get { return _context; }
        }

        IDocumentContext IDocument.Context
        {
            get { return _context; }
        }

        public FileInfo File
        {
            get { return new FileInfo(Path); }
        }

        public string Key
        {
            get { return _metadata.Key; }
        }

        public Metadata Metadata
        {
            get { return _metadata; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { return System.IO.Path.Combine(_context.Directory.FullName, Name); }
        }
    }
}
