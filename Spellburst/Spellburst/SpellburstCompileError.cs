using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    class SpellburstCompileError : SpellburstError
    {
        private int ErrorLine { set; get; }

        public SpellburstCompileError(ErrorType type, int ErrorLine = 0) : base(type)
        {
            this.ErrorLine = ErrorLine;
        }

        protected override string ErrorMessage()
        {
            return "ガイジかよ";
        }
    }
}
