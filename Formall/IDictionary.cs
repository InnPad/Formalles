﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall
{
    public interface IDictionary : IDictionary<string, IEntry>, IEntry//, IValidatable
    {
        Model Model { get; }
    }
}