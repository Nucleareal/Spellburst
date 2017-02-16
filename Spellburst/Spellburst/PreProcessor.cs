using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    class PreProcessor
    {
        public PreProcessor(string code)
        {
            this.Code = code;
        }

        public string Code { private set; get; }

        public string[] Codes { private set; get; }

        public SpellburstCompileError PreProcess()
        {
            string[] sa = Code.Replace(Environment.NewLine, "\n").Split('\n');

            //行数過多
            if (sa.Length >= 8) return new SpellburstCompileError(ErrorType.TooManyNewLine);
            //禁止ワード
            if (ContainsFWords(Code)) return new SpellburstCompileError(ErrorType.FWord);

            //解釈処理
            Code = string.Join("", sa);

            var iter = new SpellburstIterator(Code);
            var queue = new Queue<SpellCode>();

            var i = new[]{ SpellCode.None};

            while((i = iter.NextCode()) != null)
            {
                queue.EnqueueRange(i);
            }

            Interpreter.Codes = new List<SpellCode>(queue);

            //Console.WriteLine(queue.Select(e => e.ToString()).Aggregate(",", (s, e) => s += e + ","));

            var mode = ReadMode.WaitIMP;

            var IMP = new SpellburstIMP();
            var Command = new SpellburstCommand();
            var Number = new SpellburstNumber();
            var Label = new SpellburstLabel();

            var ProgramCounter = 0;

            var SubroutineCall = 0;
            var SubroutineEnd = 0;
            var LabelTemp = 0;

            var labelDict = new Dictionary<string, int>();
            var labelJumpDict = new List<string>();

            Action reset = () => { IMP.Reset(); Command.Reset(); Number.Reset(); Label.Reset(); };

            while (queue.Count != 0)
            {
                var first = queue.Dequeue();

                switch (mode)
                {
                    case ReadMode.WaitIMP:
                        IMP.AddIMP(first);

                        if (IMP.IsEqualTo("S")) mode = ReadMode.WaitCommand;
                        if (IMP.IsEqualTo("N")) mode = ReadMode.WaitCommand;
                        if (IMP.IsEqualTo("TS")) mode = ReadMode.WaitCommand;
                        if (IMP.IsEqualTo("TN")) mode = ReadMode.WaitCommand;
                        if (IMP.IsEqualTo("TT")) mode = ReadMode.WaitCommand;
                        break;
                    case ReadMode.WaitCommand:
                        Command.AddCommand(first);

                        //楽なのを先に処理
                        if (IMP.IsEqualTo("TT"))
                        {
                            if (Command.IsEqualTo("S")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("T")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("N")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                        }
                        //ここから本題
                        if (IMP.IsEqualTo("S"))
                        {
                            if (Command.IsEqualTo("S")) { mode = ReadMode.InputInteger; }
                            if (Command.IsEqualTo("NS")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("NT")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("NN")) { mode = ReadMode.WaitIMP; reset(); }

                            if (Command.IsEqualTo("T")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                        }
                        if(IMP.IsEqualTo("TS"))
                        {
                            if(Command.IsEqualTo("SS")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("ST")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("SN")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("TS")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("TT")) { mode = ReadMode.WaitIMP; reset(); }

                            if (Command.IsEqualTo("TN")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                            if (Command.IsEqualTo("N")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                        }
                        if(IMP.IsEqualTo("N"))
                        {
                            if (Command.IsEqualTo("SS")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            if (Command.IsEqualTo("ST")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            if (Command.IsEqualTo("SN")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            if (Command.IsEqualTo("TS")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            if (Command.IsEqualTo("TT")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            if (Command.IsEqualTo("TN")) { mode = ReadMode.WaitIMP; SubroutineEnd++; reset(); }
                            if (Command.IsEqualTo("NN")) { mode = ReadMode.Finish; }

                            if (Command.IsEqualTo("NS")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                            if (Command.IsEqualTo("NT")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                            //labelJumpDict
                        }
                        if(IMP.IsEqualTo("TN"))
                        {
                            if (Command.IsEqualTo("SS")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("ST")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("TS")) { mode = ReadMode.WaitIMP; reset(); }
                            if (Command.IsEqualTo("TN")) { mode = ReadMode.WaitIMP; reset(); }

                            if (Command.IsEqualTo("SN")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                            if (Command.IsEqualTo("TT")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                            if (Command.IsEqualTo("N")) return new SpellburstCompileError(ErrorType.CommandNotFound, ProgramCounter);
                        }
                        break;
                    case ReadMode.InputInteger:
                        if(first.Equals(SpellCode.NewLine))
                        {
                            //スタックに数値をpushする(preprocessなのでしない)

                            mode = ReadMode.WaitIMP;
                            reset();
                            break;
                        }

                        Number.AddNumber(first);
                        break;
                    case ReadMode.InputLabel:
                        if(first.Equals(SpellCode.NewLine))
                        {
                            //ラベル定義
                            if (Command.IsEqualTo("SS"))
                            {
                                if(labelDict.ContainsKey(Label.Result))
                                {
                                    return new SpellburstCompileError(ErrorType.LabelIsAlreadyDefined);
                                }
                                labelDict.Add(Label.Result, LabelTemp);
                            }
                            //サブルーチン呼び出し
                            if(Command.IsEqualTo("ST"))
                            {
                                labelJumpDict.Add(Label.Result);
                                SubroutineCall++;
                            }
                            //無条件ジャンプ
                            if(Command.IsEqualTo("SN"))
                            {
                                labelJumpDict.Add(Label.Result);
                            }
                            //ゼロならジャンプ
                            if(Command.IsEqualTo("TS"))
                            {
                                labelJumpDict.Add(Label.Result);
                            }
                            //負ならジャンプ
                            if (Command.IsEqualTo("TT"))
                            {
                                labelJumpDict.Add(Label.Result);
                            }
                            mode = ReadMode.WaitIMP;
                            reset();
                        }

                        Label.Add(first);
                        break;
                    case ReadMode.Finish:
                        queue.Clear();
                        break;
                }
                ProgramCounter++;
            }

            foreach(var l in labelJumpDict)
            {
                if(!labelDict.ContainsKey(l))
                {
                    return  new SpellburstCompileError(ErrorType.InvalidLabelJump);
                }
            }
            Interpreter.LabelDict = new Dictionary<string, int>(labelDict);

            return new SpellburstCompileError(ErrorType.Success);
        }

        private bool ContainsFWords(string code)
        {
            foreach (var s in Vocab.FWORDS())
            {
                if (code.Contains(s))
                    return true;
            }
            return false;
        }
    }
}
