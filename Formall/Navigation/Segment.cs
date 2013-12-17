using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    public class Segment : ISegment
    {
        private ISegment _parent;
        private List<ISegment> _children;

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
            get { return Parent.Path + '/' + Name; }
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

        List<ISegment> ISegment.Children
        {
            get { return _children ?? (_children = new List<ISegment>()); }
        }
    }
}
