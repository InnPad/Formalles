using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IDocumentContext
    {
        IResult Append(Guid id, Model model, string field, IEntry item, IDocumentSession session = null);

        IResult Append(IDocument document, string field, IEntry item, IDocumentSession session = null);

        IResult Create(Guid id, Model model, IDictionary data, IDocumentSession session = null);
        
        IResult Delete(Guid id, Model model, IDocumentSession session = null);

        IResult Delete(IDocument document, IDocumentSession session = null);

        IDocument Import(Stream stream);

        IDocument Import(TextReader reader);

        IDocument Import(XmlReader reader);

        IDocument Import(IDocument document);

        IDocument[] Read(IDocumentSession session = null);

        IDocument[] Read(int startIndex, int pageSize, IDocumentSession session = null);

        IDocument Read(Guid id, Model model, IDocumentSession session = null);

        IDocument Load(XmlReader reader);

        IDocument Load(TextReader reader);

        IDocument Load(Stream stream);

        IDocumentSession OpenSession(bool async = false);

        IResult Remove(Guid id, Model model, string field, IEntry value, IDocumentSession session = null);

        IResult Remove(IDocument document, string field, IEntry value, IDocumentSession session = null);

        IResult Store(Guid id, Model model, IDictionary entity, IDocumentSession session = null);

        IResult Store(IDocument document, IDocumentSession session = null);

        IResult Update(Guid id, Model model, IDictionary entity, IDocumentSession session = null);

        IResult Update(IDocument document, IDictionary entity, IDocumentSession session = null);
    }
}
