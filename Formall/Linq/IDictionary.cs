using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Reflection;

    public interface IDictionary : IDictionary<string, IEntry>, IDynamicMetaObjectProvider, IObject
    {
        Model Model { get; }

        T Value<T>(string name);
    }
}
