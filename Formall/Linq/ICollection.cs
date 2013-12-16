using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Formall.Linq
{
    public interface ICollection : IList<IEntry>, IObject
    {
        IList<T> MakeGeneric<T>();

        TObject[] ToArray<TObject>();

        XElement ToXElement();
    }
}
