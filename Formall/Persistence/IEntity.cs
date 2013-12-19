using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IEntity
    {
        dynamic Data { get; }

        Guid Id { get; }

        Model Model { get; }

        IRepository Repository { get; }

        IResult Delete();

        IResult Refresh();

        /// <summary>
        /// Remove from a list
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IResult Remove(string field, string value);

        IResult Patch(IDictionary data);

        IResult Update(IDictionary data);
    }
}
