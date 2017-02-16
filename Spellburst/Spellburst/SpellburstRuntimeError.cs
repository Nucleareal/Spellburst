using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    class SpellburstRuntimeError : SpellburstError
    {
        public SpellburstRuntimeError(ErrorType type) : base(type)
        {
        }

        protected override string ErrorMessage()
        {
            return "これはまだ回ってない方だから";
        }
    }
}
