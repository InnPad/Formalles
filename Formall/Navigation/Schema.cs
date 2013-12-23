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
    using Formall.Presentation;
    using Formall.Persistence;
    using Formall.Reflection;
    using System.Globalization;

    public class Schema
    {
        private static Schema _current;

        private readonly static object _lock = new object();

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

        private readonly ConcurrentDictionary<string, Entity<Domain>> _container;

        private Schema()
        {
            _container = new ConcurrentDictionary<string, Entity<Domain>>();
        }

        public IEnumerable<ISegment> Query(string name, string host)
        {
            var options = RouteOption.FromHost(host);

            foreach (var current in options)
            {
                Entity<Domain> entity;

                if (_container.TryGetValue(current.Pattern, out entity))
                {
                    var domain = (Domain)entity;

                    var path = new Queue<string>(name.Split('/'));

                    var segment = entity.Select(path);

                    if (segment != null && path.Count == 0)
                    {
                        yield return segment;
                    }
                }
            }

            yield break;
        }

        public ISegment Load(Guid id, string host, Domain domain, IDocumentContext context)
        {
            var entity = new Entity<Domain>(domain, new Metadata { Key = "Domain/" + id, Model = "Domain" }, string.Empty, null);

            _container.AddOrUpdate(host, entity, (key, previous) => { return entity; });

            Load(context, entity);

            return entity;
        }

        internal void Load(IDocumentContext context, Segment root)
        {
            const int pageSize = 65536;
            int count;
            for (count = 0; ; )
            {
                var page = context.Read(count, pageSize);

                for (var i = 0; i < page.Length; i++)
                {
                    root.Insert(page[i]);
                }

                count += page.Length;

                if (page.Length < pageSize)
                    break;
            }
        }

        public RouteOption Match(string host)
        {
            RouteOption match = null;

            var options = RouteOption.FromHost(host);

            foreach(var current in options)
            {
                Entity<Domain> entity;
                if (_container.TryGetValue(current.Pattern, out entity))
                {
                    match = current;
                    break;
                }
            }

            return match;
        }
    }

    public static class SchemaExtensions
    {
        public static ISegment ParentOf(this Schema domain, ISegment segment)
        {
            return null;
        }
    }
}
