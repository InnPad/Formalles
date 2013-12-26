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
        private readonly FileMetadata _metadata;
        private readonly string _name;
        private readonly ContentType _type;

        public FileDocument(FileEntry entry, FileDocumentContext context)
        {
            _name = entry.Name;
            _type = ContentType.Binary;
            _metadata = entry.Metadata;
            _context = context;
        }

        public FileDocument(string name, ContentType type, FileMetadata metadata, FileDocumentContext context)
        {
            _name = name;
            _type = type;
            _metadata = metadata;
            _context = context;
        }

        public Stream Content
        {
            get { return File.Open(FileMode.OpenOrCreate); }
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
            get { return new FileInfo(FullName); }
        }

        public string Key
        {
            get { return _metadata.Key; }
        }

        public FileMetadata Metadata
        {
            get { return _metadata; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string FullName
        {
            get
            {
                var name = _name + _metadata.Extension;
                
                return System.IO.Path.Combine(_context.Directory.FullName, name);
            }
        }

        Metadata IDocument.Metadata
        {
            get { return _metadata; }
        }
    }
}
