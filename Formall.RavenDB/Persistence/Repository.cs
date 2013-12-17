using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;

    internal class Repository : IRepository
    {
        private IDocumentSession _session = null;

        public Context Context
        {
            get { throw new NotImplementedException(); }
        }

        IDataContext IRepository.Context
        {
            get { throw new NotImplementedException(); }
        }

        public Reflection.Model Model
        {
            get { throw new NotImplementedException(); }
        }

        public IResult Create(IDictionary data)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEntity Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEntity[] Read(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(Guid id, string field, string value)
        {
            throw new NotImplementedException();
        }

        public IResult Patch(Guid id, IDictionary data)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Guid id, IDictionary data)
        {
            throw new NotImplementedException();
        }
    }
}
