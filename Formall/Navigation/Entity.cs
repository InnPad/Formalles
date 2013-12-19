using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    using Formall.Linq;
    using Formall.Persistence;
    using Formall.Reflection;

    public class Entity : Document, IEntity
    {
        private readonly IEntity _entity;

        public Entity(IEntity entity, ISegment segment)
            : base(entity as IDocument, segment)
        {
            _entity = entity;
        }

        public Guid Id
        {
            get { return _entity.Id; }
        }

        public Model Model
        {
            get { return _entity.Model; }
        }

        IRepository IEntity.Repository
        {
            get { return _entity.Repository; }
        }

        IResult IEntity.Delete()
        {
            throw new NotImplementedException("Read only");
        }

        public T Get<T>()
        {
            return _entity.Get<T>();
        }

        IResult IEntity.Refresh()
        {
            return _entity.Refresh();
        }

        IResult IEntity.Set<T>(T value)
        {
            throw new NotImplementedException("Read only");
        }

        IResult IEntity.Patch(IDictionary data)
        {
            throw new NotImplementedException("Read only");
        }

        IResult IEntity.Update(IDictionary data)
        {
            throw new NotImplementedException("Read only");
        }
    }
}
