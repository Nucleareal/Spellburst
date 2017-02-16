using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spellburst
{
    class SpellburstIterator
    {
        public string Code { private set; get; } = null;

        public SpellburstIterator(string code)
        {
            this.Code = code;
        }

        public SpellCode[] NextCode()
        {
            //Code
            if (FindAndReplace(Vocab.RS)) return new[] { SpellCode.Space };
            if (FindAndReplace(Vocab.RT)) return new[] { SpellCode.Tab };

            //IMP
            if (FindAndReplace(Vocab.S)) return new[] { SpellCode.Space };
            if (FindAndReplace(Vocab.TS)) return new[] { SpellCode.Tab, SpellCode.Space };
            if (FindAndReplace(Vocab.TT)) return new[] { SpellCode.Tab, SpellCode.Tab };
            if (FindAndReplace(Vocab.N)) return new[] { SpellCode.NewLine };
            if (FindAndReplace(Vocab.TN)) return new[] { SpellCode.Tab, SpellCode.NewLine };

            //if (FindAndReplace(Vocab.RS)) Environment.Exit(0);

            return null;
        }

        private bool FindAndReplace(string s)
        {
            if(Code.StartsWith(s))
            {
                Code = Code.ReplaceFirst(s, "");
                return true;
            }
            return false;
        }
    }
}
