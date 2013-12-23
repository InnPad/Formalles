using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    using Formall.Persistence;
    using Formall.Reflection;
    using Formall.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    
    internal class Entity : Document, IEntity
    {
        private readonly IEntity _entity;
        
        public Entity(IEntity entity, string name, ISegment parent)
            : base(entity, name, parent)
        {
            _entity = entity;
        }

        public dynamic Data
        {
            get;
            set;
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

        public T Get<T>() where T : class
        {
            return _entity.Get<T>();
        }

        public virtual IResult Refresh()
        {
            return _entity.Refresh();
        }

        IResult IEntity.Set<T>(T value)
        {
            throw new NotImplementedException("Read only");
        }

        IResult IEntity.Patch(object data)
        {
            throw new NotImplementedException("Read only");
        }

        IResult IEntity.Update(object data)
        {
            throw new NotImplementedException("Read only");
        }

        public IResult WriteJson(Stream stream)
        {
            return _entity.WriteJson(stream);
        }

        public IResult WriteJson(TextWriter writer)
        {
            return _entity.WriteJson(writer);
        }
    }

    internal class Entity<T> : Entity
        where T : class
    {
        public static implicit operator T(Entity<T> entity)
        {
            if (entity == null)
            {
                return null;
            }

            var content = entity._content;

            if (content == null)
            {
                lock (entity)
                {
                    content = entity._content ?? (entity._content = entity.Get<T>());
                }
            }

            return content;
        }

        private T _content;

        public Entity(Guid id, T data, Metadata metadata, string name, ISegment parent)
            : this(new JsonEntity(id, data, metadata), name, parent)
        {
        }

        public Entity(T data, Metadata metadata, string name, ISegment parent)
            : this(Guid.NewGuid(), data, metadata, name, parent)
        {
        }

        public Entity(IEntity entity, string name, ISegment parent)
            : base(entity, name, parent)
        {
            _content = null;
        }

        public override IResult Refresh()
        {
            var result = base.Refresh();

            _content = null;

            return result;
        }
    }
}
