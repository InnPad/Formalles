using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    internal class Segment : ISegment
    {
        private ISegment _parent;
        private List<ISegment> _children;

        public Segment(ISegment parent)
        {
            _parent = parent;
        }

        public List<ISegment> Children
        {
            get { return _children ?? (_children = new List<ISegment>()); }
        }

        public string Name
        {
            get;
            set;
        }

        public ISegment Parent
        {
            get { return _parent; }
        }

        public string Path
        {
            get { return Parent.Path + '/' + Name; }
        }
    }
}
