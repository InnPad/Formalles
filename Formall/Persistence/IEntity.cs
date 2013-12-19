using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IEntity : IDocument
    {
        Guid Id { get; }

        Model Model { get; }

        IRepository Repository { get; }

        IResult Delete();

        T Get<T>();

        IResult Refresh();

        IResult Set<T>(T value);

        IResult Patch(IDictionary data);

        IResult Update(IDictionary data);
    }
}
