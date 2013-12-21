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

    public class Match
    {
        public CultureInfo Culture
        {
            get;
            set;
        }

        public string Original
        {
            get;
            set;
        }

        public string Pattern
        {
            get;
            set;
        }

        public string Redirect
        {
            get;
            set;
        }
    }

    public class Schema
    {
        public static Match[] Options(string host)
        {
            var original = host;

            host = host.ToLower();

            var list = new List<Match>();

            var absolute = host.Split('.');
            var relative = host.Substring(0, host.LastIndexOf('.')).Split('.');
            relative[relative.Length - 1] = "*";

            CultureInfo culture = null;
            string redirect = null;

            if (absolute.Length > 2)
            {
                var tag = absolute[0].Split('-');

                switch (tag.Length)
                {
                    case 1:
                        try
                        {
                            culture = CultureInfo.GetCultureInfoByIetfLanguageTag(tag[0]);
                        }
                        catch (CultureNotFoundException)
                        {
                        }
                        break;

                    case 2:
                        try
                        {
                            culture = CultureInfo.GetCultureInfoByIetfLanguageTag(tag[0] + '-' + tag[1].ToUpper());
                        }
                        catch (CultureNotFoundException)
                        {
                            try
                            {
                                culture = CultureInfo.GetCultureInfoByIetfLanguageTag(tag[0]);
                                redirect = culture.Name + '.' + string.Join(".", absolute.Skip(1));
                            }
                            catch (CultureNotFoundException)
                            {
                            }
                        }
                        break;
                }

                if (culture != null)
                {
                    absolute = absolute.Skip(1).ToArray();
                    relative = relative.Skip(1).ToArray();
                }
            }

            list.Add(new Match { Culture = culture, Original = original, Pattern = string.Join(".", absolute), Redirect = redirect });
            list.Add(new Match { Culture = culture, Original = original, Pattern = string.Join(".", relative), Redirect = redirect });

            for (var i = 0; i < absolute.Length - 2; i++)
            {
                if (i > 0)
                {
                    redirect = string.Join(".", absolute.Skip(i));

                    if (culture != null)
                    {
                        redirect = culture.Name + '.' + redirect;
                    }
                }

                absolute[i] = "*";
                list.Add(new Match { Culture = culture, Original = original, Pattern = string.Join(".", absolute.Skip(i)), Redirect = redirect });

                relative[i] = "*";
                list.Add(new Match { Culture = culture, Original = original, Pattern = string.Join(".", relative.Skip(i)), Redirect = redirect });
            }

            redirect = absolute.Length > 2 ? string.Join(".", absolute.Skip(absolute.Length - 2)) : null;

            if (culture != null)
            {
                redirect = culture.Name + '.' + redirect;
            }

            list.Add(new Match { Culture = culture, Original = original, Pattern = string.Join(".", absolute.Skip(absolute.Length - 2)), Redirect = redirect });
            list.Add(new Match { Culture = culture, Original = original, Pattern = "*", Redirect = redirect });

            return list.ToArray();
        }

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

        public ISegment this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<ISegment> Query(string name, string host)
        {
            var options = Options(host);

            for (int i = 0, count = options.Length; i < count; i++)
            {
                var current = options[i];

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

        public ISegment Load(Guid id, Domain domain, IDocumentContext context)
        {
            var entity = new Entity<Domain>(domain, new Metadata { Key = "Domain/" + id, Type = "Domain" }, null);

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

        public Match Match(string host)
        {
            Match match = null;

            var options = Options(host);

            for (int i = 0, count = options.Length; i < count; i++)
            {
                var current = options[i];

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
