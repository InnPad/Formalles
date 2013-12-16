using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Navigation
{
    using Formall.Linq;
    using Formall.Presentation;
    using Formall.Persistence;
    using Formall.Reflection;

    public class Schema : DocumentContext, IEdmx
    {
        [ThreadStatic]
        private static Schema _current;

        private readonly static object _lock = new object();

        private static readonly ConcurrentDictionary<string, Schema> _container;

        static Schema()
        {
            _container = new ConcurrentDictionary<string, Schema>();
        }

        private static IDocument Arrange(IDocument[] array)
        {
            IDocument domain = null;

            Array.Sort(array, (IDocument x, IDocument y) =>
                {
                    var xDic = x.Content as IDictionary;
                    var yDic = y.Content as IDictionary;
                    var xToken = xDic["Name"];
                    var yToken = yDic["Name"];

                    if (xToken.ToString() == "Domain")
                    {
                        domain = x;
                    }
                    else if (yToken.ToString() == "Domain")
                    {
                        domain = y;
                    }

                    return string.Compare(xToken.ToString(), yToken.ToString(), true);
                });

            return domain;
        }

        public static Schema Current
        {
            get { return _current; }
        }

        public static void Initialize(string domain)
        {
            _current = null;

            while (true)
            {
                if (string.IsNullOrEmpty(domain))
                {
                    break;
                }

                if (_container.TryGetValue(domain, out _current))
                {
                    break;
                }

                var parts = domain.Split('.');

                if (parts.Length < 3)
                {
                    break;
                }

                if (parts[0] == "*")
                {
                    domain = string.Join(".", parts.Skip(1));
                }
                else
                {
                    parts[0] = "*";
                    domain = string.Join(".", parts);
                }
            }
        }

        public static void Finalize()
        {
            _current = null;
        }

        public static Schema Register(string domain, IDocumentContext context)
        {
            var schema = new Schema(domain, context);
            _container.AddOrUpdate(domain, schema, (key, value) => { return schema; });
            return schema;
        }

        private readonly string _name;
        private readonly Domain _domain;
        private readonly IDocumentContext _context;

        private Schema(string name, IDocumentContext context)
        {
            _name = name;
            _domain = new Domain(null);
            _context = context;
        }

        public ISegment this[string path]
        {
            get { throw new NotImplementedException(); }
        }

        #region - IDocumentContext -

        public IDocument Read(string path)
        {
            throw new NotImplementedException();
        }

        #endregion - IDocumentContext -

        #region - IEdmx -

        XElement IEdmx.ToEdmx()
        {
            throw new NotImplementedException();
        }

        #endregion - IEdmx -
    }

    public static class SchemaExtensions
    {
        public static ISegment ParentOf(this Schema domain, ISegment segment)
        {
            return null;
        }
    }
}
