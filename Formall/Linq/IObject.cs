using System;
using System.IO;

namespace Formall.Linq
{
    using Formall.Reflection;

    public interface IObject
    {
        Prototype Prototype { get; }

        TObject ToObject<TObject>();

        void WriteJson(Stream stream);

        void WriteJson(TextWriter writer);
    }
}
