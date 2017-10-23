using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class ExtensionCuncurrentBug
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
             toAdd.AsParallel().ForAll(t => @this.Add(t));
        }
    }
}
