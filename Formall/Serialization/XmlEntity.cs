using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Serialization
{
    using Formall.Persistence;

    public class XmlEntity : IEntity
    {
        dynamic IEntity.Data
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Guid IEntity.Id
        {
            get { throw new NotImplementedException(); }
        }

        Reflection.Model IEntity.Model
        {
            get { throw new NotImplementedException(); }
        }

        IRepository IEntity.Repository
        {
            get { throw new NotImplementedException(); }
        }

        IResult IEntity.Delete()
        {
            throw new NotImplementedException();
        }

        T IEntity.Get<T>()
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Refresh()
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Set<T>(T value)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Patch(object data)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Update(object data)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.WriteJson(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.WriteJson(System.IO.TextWriter writer)
        {
            throw new NotImplementedException();
        }

        System.IO.Stream IDocument.Content
        {
            get { throw new NotImplementedException(); }
        }

        IDocumentContext IDocument.Context
        {
            get { throw new NotImplementedException(); }
        }

        string IDocument.Key
        {
            get { throw new NotImplementedException(); }
        }

        string IDocument.MediaType
        {
            get { throw new NotImplementedException(); }
        }

        Metadata IDocument.Metadata
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class XmlEntity<T> : XmlEntity
    {
    }
}
