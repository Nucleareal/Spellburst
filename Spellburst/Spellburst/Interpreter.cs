using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    class Interpreter
    {
        public Interpreter()
        {
            Reset();
        }

        private Stack<int> IntegerStack { set; get; }
        private int ProgramCounter { set; get; }

        public static Dictionary<string, int> LabelDict { set; get; }

        public static List<SpellCode> Codes { set; get; }

        private Stack<int> CallFrom { set; get; }

        public static int Heap { set; get; }

        private void Reset()
        {
            if(IntegerStack != null)
            {
                IntegerStack.Clear();
            }
            else
            { 
                IntegerStack = new Stack<int>();
            }
            if (CallFrom != null)
            {
                CallFrom.Clear();
            }
            else
            {
                CallFrom = new Stack<int>();
            }
            ProgramCounter = 0;
        }

        public SpellburstRuntimeError Run()
        {
            var mode = ReadMode.WaitIMP;

            var IMP = new SpellburstIMP();
            var Command = new SpellburstCommand();
            var Number = new SpellburstNumber();
            var Label = new SpellburstLabel();

            var ProgramCounter = 0;

            var RoutineMaxDepth = 31;
            var RoutineNowDepth = 0;

            var LabelTemp = 0;

            Action reset = () => { IMP.Reset(); Command.Reset(); Number.Reset(); Label.Reset(); mode = ReadMode.WaitIMP; };

            while (Codes.Count != 0)
            {
                if (ProgramCounter >= Codes.Count)
                {
                    break;
                }
                var first = Codes[ProgramCounter];


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
                            //スタックの値をアドレスに格納
                            if (Command.IsEqualTo("S"))
                            {
                                if(CheckStackEmpty()) return new SpellburstRuntimeError(ErrorType.StackIsEmpty);
                                Heap = IntegerStack.Peek();
                                reset();
                            }
                            //アドレスの値をスタックに積む
                            if (Command.IsEqualTo("T"))
                            {
                                IntegerStack.Push(Heap);
                                reset();
                            }
                        }
                        //ここから本題

                        //スタック操作
                        if (IMP.IsEqualTo("S"))
                        {
                            //数値をスタックにプッシュ(ReadMode.InputIntegerの方で処理は行う)
                            if (Command.IsEqualTo("S"))
                            {
                                mode = ReadMode.InputInteger;
                            }
                            //スタックトップを複製
                            if (Command.IsEqualTo("NS"))
                            {
                                IntegerStack.Push(IntegerStack.Peek());
                                reset();
                            }
                            //スタックの1番目と2番目を交換
                            if (Command.IsEqualTo("NT"))
                            {
                                var e1 = IntegerStack.Pop();
                                var e2 = IntegerStack.Pop();
                                IntegerStack.Push(e1);
                                IntegerStack.Push(e2);

                                reset();
                            }
                            //スタックトップを破棄
                            if (Command.IsEqualTo("NN"))
                            {
                                IntegerStack.Pop();

                                reset();
                            }
                        }
                        //四則演算+余
                        if (IMP.IsEqualTo("TS"))
                        {
                            //加減乗除余
                            if (Command.IsEqualTo("SS"))
                            {
                                Calc((e1, e2) => e1 + e2);
                                reset();
                            }
                            if (Command.IsEqualTo("ST"))
                            {
                                Calc((e1, e2) => e1 - e2);
                                reset();
                            }
                            if (Command.IsEqualTo("SN"))
                            {
                                Calc((e1, e2) => e1 * e2);
                                reset();
                            }
                            if (Command.IsEqualTo("TS"))
                            {
                                Calc((e1, e2) => e1 / e2);
                                reset();
                            }
                            if (Command.IsEqualTo("TT"))
                            {
                                Calc((e1, e2) => e1 % e2);
                                reset();
                            }
                        }

                        //ラベル
                        if (IMP.IsEqualTo("N"))
                        {
                            //ラベル定義
                            if (Command.IsEqualTo("SS")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            //サブルーチン呼び出し
                            if (Command.IsEqualTo("ST"))
                            {
                                //階層チェック
                                if(++RoutineNowDepth > RoutineMaxDepth)
                                {
                                    return new SpellburstRuntimeError(ErrorType.SubRoutineLevelTooDeep);
                                }
                                mode = ReadMode.InputLabel;
                                LabelTemp = ProgramCounter;
                            }
                            //無条件ジャンプ
                            if (Command.IsEqualTo("SN")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            //スタックトップがゼロならジャンプ
                            if (Command.IsEqualTo("TS")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            //スタックトップが負ならジャンプ
                            if (Command.IsEqualTo("TT")) { mode = ReadMode.InputLabel; LabelTemp = ProgramCounter; }
                            //サブルーチン終了
                            if (Command.IsEqualTo("TN"))
                            {
                                //階層チェック
                                if(--RoutineNowDepth < 0)
                                {
                                    return new SpellburstRuntimeError(ErrorType.ReturnInNonSubroutine);
                                }
                                ProgramCounter = CallFrom.Pop();

                                reset();
                            }
                            //プログラム終了
                            if (Command.IsEqualTo("NN")) { mode = ReadMode.Finish; }
                        }
                        //入出力
                        if (IMP.IsEqualTo("TN"))
                        {
                            //スタックトップの文字を出力
                            if (Command.IsEqualTo("SS"))
                            {
                                var e = IntegerStack.Peek();
                                Console.Write(Convert.ToChar(e));

                                reset();
                            }
                            //スタックトップの数値を出力
                            if (Command.IsEqualTo("ST"))
                            {
                                var e = IntegerStack.Peek();
                                Console.Write(e);

                                reset();
                            }
                            //文字を読み込みアドレスに格納
                            if (Command.IsEqualTo("TS"))
                            {
                                Heap = Console.Read();

                                reset();
                            }
                            //数値を読み込みアドレスに格納
                            if (Command.IsEqualTo("TN"))
                            {
                                Heap = int.Parse(Console.ReadLine());

                                reset();
                            }
                        }
                        break;
                    case ReadMode.InputInteger:
                        if (first.Equals(SpellCode.NewLine))
                        {
                            //スタックに数値をpushする(preprocessなのでしない)
                            IntegerStack.Push(Number.Result);

                            reset();
                        }

                        Number.AddNumber(first);
                        break;
                    case ReadMode.InputLabel:
                        if (first.Equals(SpellCode.NewLine))
                        {
                            //ラベル定義
                            if (Command.IsEqualTo("SS"))
                            {
                                //何もしない
                            }
                            //サブルーチン呼び出し
                            if (Command.IsEqualTo("ST"))
                            {
                                var row = LabelDict[Label.Result] - 1;
                                CallFrom.Push(ProgramCounter);
                                ProgramCounter = row;
                            }
                            //無条件ジャンプ
                            if (Command.IsEqualTo("SN"))
                            {
                                ProgramCounter = LabelDict[Label.Result] - 1;
                            }
                            //ゼロならジャンプ
                            if (Command.IsEqualTo("TS"))
                            {
                                if(IntegerStack.Peek() == 0)
                                {
                                    ProgramCounter = LabelDict[Label.Result] - 1;
                                }
                            }
                            //負ならジャンプ
                            if (Command.IsEqualTo("TT"))
                            {
                                if (IntegerStack.Peek() < 0)
                                {
                                    ProgramCounter = LabelDict[Label.Result] - 1;
                                }
                            }
                            reset();
                        }

                        Label.Add(first);
                        break;
                    case ReadMode.Finish:
                        Codes.Clear();
                        break;
                }
                ProgramCounter++;
            }

            return new SpellburstRuntimeError(ErrorType.Success);
        }

        private void Calc(Func<int, int, int> cfunc)
        {
            var e1 = IntegerStack.Pop();
            var e2 = IntegerStack.Pop();
            var e = cfunc(e1, e2);
            IntegerStack.Push(e);
        }

        private bool CheckStackEmpty()
        {
            if(IntegerStack.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
