using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public static class ThreadExtensions
    {
        public static object GetCurrentDomain(this Thread thread)
        {
            return Thread.GetData(Thread.GetNamedDataSlot("Formall.Domain"));
        }

        public static void SetCurrentDomain(this Thread thread, object domain)
        {
            Thread.SetData(Thread.GetNamedDataSlot("Formall.Domain"), domain);
        }
    }
}
