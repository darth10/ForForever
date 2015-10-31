using System.Collections.Generic;
using System.Linq;

namespace ForForever
{
    class RangeHelper
    {
        public IEnumerable<T> GetRange<T>(int n) where T : new()
        {
            return Enumerable.Range(0, n)
                             .Select(i => new T());
        }

        public List<T> GetList<T>(int n) where T : new()
        {
            var list = GetRange<T>(n).ToList();
            return list;
        }

        public T[] GetArray<T>(int n) where T : new()
        {
            var array = GetRange<T>(n).ToArray();
            return array;
        }
    }
}
