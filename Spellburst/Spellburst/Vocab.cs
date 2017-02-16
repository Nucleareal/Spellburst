using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    public static class Vocab
    {
        public static string S { get { return "わしはしがない魔法使いじゃよ！"; } }
        public static string TS { get { return "書に記されぬ知識を求めて！"; } }
        public static string TT { get { return "すっごい魔法、試してみよっと！"; } }
        public static string N { get { return "ま、アタシに任せておきなさいって！"; } }
        public static string TN { get { return "私は貴様らを許容しない。"; } }

        public static string RS { get { return "シュピィン！シュピィン！"; } }
        public static string RT { get { return "ボゥン！"; } }

        public static IEnumerable<string> FWORDS()
        {
            yield return "盤面";
            yield return "タイムレスウィッチ";
            yield break;
        }
    }
}
