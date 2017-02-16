using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    public static class Extentions
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> arr)
        {
            foreach(var v in arr)
            {
                queue.Enqueue(v);
            }
        }
    }
}
