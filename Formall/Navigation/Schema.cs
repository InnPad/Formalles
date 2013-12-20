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
        public static string[] Split(string pattern)
        {
            var list = new List<string>();

            return list.ToArray();
        }

        private static Schema _current;

        private readonly static object _lock = new object();

        private static IDocument Arrange(IDocument[] array)
        {
            IDocument domain = null;

            Array.Sort(array, (IDocument x, IDocument y) =>
                {
                    var a = x as IEntity;
                    var b = y as IEntity;
                    
                    var xName = a.Data.Name;
                    var yName = b.Data.Name;

                    if (xName.ToString() == "Domain")
                    {
                        domain = x;
                    }
                    else if (yName.ToString() == "Domain")
                    {
                        domain = y;
                    }

                    return string.Compare(xName.ToString(), yName.ToString(), true);
                });

            return domain;
        }

        public static Schema Current
        {
            get
            {
                var current = _current;

                if (current == null)
                {
                    // lock and check again
                    lock (_lock)
                    {
                        // create new instance if doesn't exist
                        current = _current ?? (_current = new Schema());
                    }
                }

                return current;
            }
        }

        public ISegment Domain(string value)
        {
            Entity<Domain> domain = null;

            while (true)
            {
                if (string.IsNullOrEmpty(value))
                {
                    break;
                }

                if (_container.TryGetValue(value, out domain))
                {
                    break;
                }

                var parts = value.Split('.');

                if (parts.Length < 3)
                {
                    break;
                }

                if (parts[0] == "*")
                {
                    value = string.Join(".", parts.Skip(1));
                }
                else
                {
                    parts[0] = "*";
                    value = string.Join(".", parts);
                }
            }

            return domain;
        }

        private readonly ConcurrentDictionary<string, Entity<Domain>> _container;

        private Schema()
        {
            _container = new ConcurrentDictionary<string, Entity<Domain>>();
        }

        public ISegment this[string path]
        {
            get { throw new NotImplementedException(); }
        }

        public ISegment Domain(string pattern, IDocumentContext context, ISegment parent)
        {
            var document = context.Read("Domain");
            var entity = document as IEntity;
            var domain = new Entity<Domain>(entity, parent);
            _container.AddOrUpdate(pattern, domain, (key, previous) => { return domain; });
            return domain;
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
