using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IDocumentRepository
    {
        IDocumentContext Context { get; }

        Model Model { get; }

        IResult Append(Guid id, string field, string entry, IDocumentSession session = null);

        IResult Create(IDictionary data, IDocumentSession session = null);

        IResult Delete(Guid id, IDocumentSession session = null);

        IDocument[] Read(IDocumentSession session = null);

        IDocument[] Read(int startIndex, int pageSize, IDocumentSession session = null);

        IDocument Read(Guid id, IDocumentSession session = null);

        IResult Remove(Guid id, string field, string entry, IDocumentSession session = null);

        IResult Patch(Guid id, IDictionary data, IDocumentSession session = null);

        IResult Update(Guid id, IDictionary data, IDocumentSession session = null);
    }
}
