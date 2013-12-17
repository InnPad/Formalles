using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IRepository
    {
        IDataContext Context { get; }

        Model Model { get; }

        IResult Create(IDictionary data);

        IResult Delete(Guid id);

        IEntity Read(Guid id);

        IEntity[] Read(int skip, int take);

        /// <summary>
        /// Remove from a list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IResult Remove(Guid id, string field, string value);

        IResult Patch(Guid id, IDictionary data);

        IResult Update(Guid id, IDictionary data);
    }
}
