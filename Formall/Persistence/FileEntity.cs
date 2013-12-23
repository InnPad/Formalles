using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public abstract class FileEntity : FileDocument, IEntity
    {
        private readonly FileRepository _repository;

        protected FileEntity(string name, Metadata metadata, FileRepository repository)
            : base(name, metadata, repository.Context)
        {
            _repository = repository;
        }

        public abstract dynamic Data { get; }

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
    }
}
