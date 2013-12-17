using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Formall.Reflection
{
    using Formall.Linq;

    public class Field : Dictionary
    {
        private static readonly object _lock = new object();
        private static Model _model;
        private IDictionary _dictionary;

        private static Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = new Model(null, null));
                    throw new NotImplementedException();
                }
            }

            return model;
        }

        internal Field(IDictionary dictionary)
            : base(GetModel(), dictionary)
        {
            _dictionary = dictionary;
        }

        /// <summary>
        /// Allow atutomatic transformations on field value depending on constraint
        /// </summary>
        public bool Auto
        {
            get;
            set;
        }

        /// <summary>
        /// Value constraint field name.
        /// If the type of the field referenced by Contraint is:
        /// * boolean: the value of this field is only valid if the value of the constraint field it true.
        /// * Unit: The value will be in terms this unit type, and if Auto is true, automatic conversion will be perform upon unit changes.
        public string Constraint
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Value constraint type name
        /// </summary>
        public string Type
        {
            get;
            set;
        }
    }
}
