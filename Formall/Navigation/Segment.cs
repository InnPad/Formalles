using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    internal class Segment : ISegment
    {
        private ISegment _parent;
        private SegmentCollection _children;

        public Segment(ISegment parent)
        {
            _parent = parent;
        }

        protected virtual string Name
        {
            get;
            set;
        }

        protected ISegment Parent
        {
            get { return _parent; }
        }

        protected string Path
        {
            get { return Parent != null ? Parent.Path + '/' + Name : Name; }
        }

        string ISegment.Name
        {
            get { return this.Name; }
        }

        string ISegment.Path
        {
            get { return this.Path; }
        }

        ISegment ISegment.Parent
        {
            get { return this.Parent; }
        }

        public SegmentCollection Children
        {
            get { return _children ?? (_children = new SegmentCollection()); }
        }

        IDictionary<string, ISegment> ISegment.Children
        {
            get { return this.Children.Dictionary; }
        }
    }

    internal class SegmentCollection : KeyedCollection<string, ISegment>
    {
        public new IDictionary<string, ISegment> Dictionary
        {
            get { return base.Dictionary; }
        }

        protected override string GetKeyForItem(ISegment item)
        {
            return item.Name.ToLower();
        }
    }
}
