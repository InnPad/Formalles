using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall
{
    public class DocumentContext : IDocumentContext
    {
        public virtual IResult Append(Guid id, Model model, string field, IEntry item, IDocumentSession session = null)
        {
            var document = Read(id, model, session);
            return Append(document, field, item, session);
        }

        public virtual IResult Append(IDocument document, string field, IEntry item, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Create(Guid id, Model model, IDictionary data, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Delete(Guid id, Model model, IDocumentSession session = null)
        {
            var document = Read(id, model, session);
            return Delete(document, session);
        }

        public virtual IResult Delete(IDocument document, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Import(Stream stream)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Import(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Import(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument[] Read(IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument[] Read(int startIndex, int pageSize, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Read(Guid id, Model model, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Load(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Load(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public virtual IDocument Load(Stream stream)
        {
            throw new NotImplementedException();
        }

        public virtual IDocumentSession OpenSession(bool async = false)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Remove(Guid id, Model model, string field, IEntry value, IDocumentSession session = null)
        {
            var document = Read(id, model, session);
            return Remove(document, field, value, session);
        }

        public virtual IResult Remove(IDocument document, string field, IEntry value, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Store(Guid id, Model model, IDictionary entity, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Store(IDocument document, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Update(Guid id, Model model, IDictionary entity, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Update(IDocument document, IDictionary entity, IDocumentSession session = null)
        {
            throw new NotImplementedException();
        }
    }
}
