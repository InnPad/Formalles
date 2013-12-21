using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    using Formall.Persistence;
    using Formall.Reflection;

    internal static class SegmentExtensions
    {
        public static Segment Ensure(this Segment root, Queue<string> path)
        {
            Segment segment = root;

            if (path != null && path.Count > 0)
            {
                var name = path.Dequeue();

                var child = root.Children[name] as Segment;

                if (child != null)
                {
                    segment = child.Ensure(path);
                }
                else
                {
                    segment = new Segment(root);

                    root.Children.Dictionary[name] = segment;

                    while (path.Count > 0)
                    {
                        name = path.Dequeue();

                        child = new Segment(segment);

                        segment.Children.Dictionary[name] = child;

                        segment = child;
                    }
                }
            }

            return segment;
        }

        public static Segment Insert(this Segment root, IDocument document)
        {
            Segment segment = null;
            Segment parent = null;
            string name = null;

            var metadata = document.Metadata;
            var entity = document as IEntity;

            if (entity != null)
            {
                var keyPrefix = document.Key.Exclude(1, '/') + '/';

                name = entity.Data.Name as string;

                if (name == null)
                {
                    // log error
                }
                else
                {
                    var path = name.Split('/').Exclude(1);
                    name = name.Split('/').Last();

                    parent = root.Ensure(new Queue<string>(path));

                    switch (keyPrefix)
                    {
                        case "Type/Item/":
                            var item = new Entity<Item>(entity, parent);
                            segment = item;
                            break;

                        case "Type/Model/":
                            var model = new Entity<Model>(entity, parent);
                            segment = model;
                            break;

                        case "Type/Value/":
                            var value = new Entity<Value>(entity, parent);
                            segment = value;
                            break;

                        default:
                            segment = new Entity(entity, parent);
                            break;
                    }
                }
            }
            else
            {
                var file = document as IFileSystem;

                if (file != null)
                {
                    name = file.Name;
                    var path = file.Path.Split(new char[] { '/', '\\' });
                    parent = root.Ensure(new Queue<string>(path));
                    segment = new Document(document, parent);
                }
            }

            if (segment != null && parent != null && name != null)
            {
                var current = parent.Children[name];

                if (current != null)
                {
                    foreach (var child in current.Children)
                    {
                        segment.Children.Dictionary.Add(child);
                    }
                }

                parent.Children.Dictionary[name] = segment;
            }

            return segment;
        }

        public static string Exclude(this string list, int count, char separator)
        {
            return string.Join(separator.ToString(), list.Split(separator).Exclude(count));
        }

        public static string[] Exclude(this string[] array, int count)
        {
            return array.Length > 1 ? array.Take(array.Length - count).ToArray() : new string[0];
        }

        public static ISegment Select(this ISegment root, Queue<string> path)
        {
            ISegment segment;

            if (path == null || path.Count == 0)
            {
                segment = root;
            }
            else
            {
                var name = path.First();
                if (root.Children.TryGetValue(name, out segment))
                {
                    path.Dequeue();
                    segment = Select(segment, path);
                }
            }
            return segment;
        }
    }   
}
