using System;
using System.IO;

namespace Formall.Linq
{
    using Formall.Reflection;

    public interface IObject
    {
        DataType DataType { get; }

        TObject ToObject<TObject>();

        void WriteJson(Stream stream);

        void WriteJson(TextWriter writer);
    }
}
