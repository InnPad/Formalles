using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Xml
{
    public abstract class DocumentContext : IDocumentContext
    {
        internal Collection Clone(ICollection collection)
        {
            return null;
        }

        internal Dictionary Clone(IDictionary document)
        {
            return null;
        }

        internal Document Clone(IDocument document)
        {
            return new Document(document);
        }

        internal Entry Clone(IEntry entry)
        {
            return null;
        }

        public XElement ToXml(ICollection collection)
        {
            return collection != null ? (XElement)((collection as Collection) ?? Clone(collection)) : null;
        }

        public XElement ToXml(IDictionary dictionary)
        {
            return dictionary != null ? (XElement)((dictionary as Dictionary) ?? Clone(dictionary)) : null;
        }

        public XDocument ToXml(IDocument document)
        {
            return document != null ? (XDocument)((document as Document) ?? Clone(document)) : null;
        }

        public XNode ToXml(IEntry entry)
        {
            return entry != null ? (XNode)((entry as Entry) ?? Clone(entry)) : null;
        }
    }
}
