using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public abstract class StreamDocument : IDocument
    {
        private readonly StreamDocumentContext _context;
        private readonly Metadata _metadata;

        public StreamDocument(Metadata metadata, StreamDocumentContext context)
        {
            _metadata = metadata;
            _context = context;
        }

        public abstract Stream Content { get; }

        IDocumentContext IDocument.Context
        {
            get { return _context; }
        }

        public string Key
        {
            get { return _metadata.Key; }
        }

        public string MediaType
        {
            get { return _metadata != null ? _metadata.ContentType : null; }
        }

        public Metadata Metadata
        {
            get { return _metadata; }
        }
    }
}
