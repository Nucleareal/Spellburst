using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    public class SpellburstIMP
    {
        private List<SpellCode> IMP;

        public SpellburstIMP()
        {
            IMP = new List<SpellCode>();
        }

        public void Reset()
        {
            IMP.Clear();
        }

        public void AddIMP(SpellCode code)
        {
            IMP.Add(code);
        }

        public bool IsEqualTo(string s)
        {
            string res = "";
            foreach(var v in IMP)
            {
                switch(v)
                {
                    case SpellCode.NewLine:
                        res += "N"; break;
                    case SpellCode.Space:
                        res += "S"; break;
                    case SpellCode.Tab:
                        res += "T"; break;
                }
            }
            return res.Equals(s);
        }
    }

    public class SpellburstCommand : SpellburstIMP
    {
        public void AddCommand(SpellCode code)
        {
            AddIMP(code);
        }
    }

    public class SpellburstNumber
    {
        private string ns { set; get; }

        public SpellburstNumber()
        {
            Reset();
        }

        public void Reset()
        {
            ns = "";
        }

        public void AddNumber(SpellCode s)
        {
            var str = s == SpellCode.Space ? "0" : "1";
            ns += str;
        }

        public int Result
        {
            get
            {
                return Convert.ToInt32(ns, 2);
            }
        }
    }

    public class SpellburstLabel
    {
        public int Line { set; get; }
        private string Name { set; get; }

        public SpellburstLabel()
        {
            Line = 0;
            Reset();
        }

        public void Reset()
        {
            Name = "";
        }

        public void Add(SpellCode s)
        {
            string str = s == SpellCode.Space ? "0" : "1";
            Name += s;
        }

        public string Result
        {
            get
            {
                return Name;
            }
        }
    }
        
}
