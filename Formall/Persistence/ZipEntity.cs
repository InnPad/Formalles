using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Reflection;

    public abstract class ZipEntity : ZipDocument, IEntity
    {
        private readonly ZipRepository _repository;

        protected ZipEntity(ZipArchiveEntry entry, Metadata metadata, ZipRepository repository)
            : base(entry, metadata, repository.Context)
        {
        }

        public abstract dynamic Data { get; }

        public Guid Id
        {
            get
            {
                Guid id;
                var key = Metadata.Key;
                Guid.TryParse(key.Split('/').Last(), out id);
                return id;
            }
        }

        public Model Model
        {
            get { return _repository.Model; }
        }

        IRepository IEntity.Repository
        {
            get { return _repository; }
        }

        IResult IEntity.Delete()
        {
            return this.Context.Delete(Key);
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

        IResult IEntity.WriteJson(Stream stream)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.WriteJson(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
