using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    public static class SpellburstOption
    {
        public static bool SoftWarn { private set; get; } = false;

        public static void CauseOption(string[] args)
        {
            foreach(var s in args)
            {
                if (!s.StartsWith("-") && !s.StartsWith("/")) continue;

                var v = s.Replace("-", "");
                v = v.Replace("/", "").ToLower();

                if(v.Contains("優しく罵れ"))
                {
                    SoftWarn = true;
                }
            }
        }
    }
}
