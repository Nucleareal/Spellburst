using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    class SpellburstError
    {
        private ErrorType Type { set; get; }

        public SpellburstError(ErrorType type)
        {
            this.Type = type;
        }

        protected virtual string ErrorMessage()
        {
            return "ノーコンテスト";
        } 

        public virtual void Throw()
        {
            if (SpellburstOption.SoftWarn)
                SoftWarn();
            else
                Console.Write(ErrorMessage());
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void SoftWarn()
        {
            var s = "?";
            switch(Type)
            {
                case ErrorType.CommandNotFound:
                    s = "不正なコマンドです。";
                    break;
                case ErrorType.FileNotFound:
                    s = "ファイルが見つからねーぞオイ";
                    break;
                case ErrorType.FWord:
                    s = "盤面なんて取ってる暇があったら顔面を殴れ";
                    break;
                case ErrorType.InvalidLabelJump:
                    s = "きさらぎ駅";
                    break;
                case ErrorType.LabelIsAlreadyDefined:
                    s = "ラベルは既に定義されています。";
                    break;
                case ErrorType.ReturnInNonSubroutine:
                    s = "帰るってなんだよここがお前の家だよ";
                    break;
                case ErrorType.StackIsEmpty:
                    s = "お前の頭みてーなスタックしてんな";
                    break;
                case ErrorType.SubRoutineLevelTooDeep:
                    s = "サブルーチンが深すぎる";
                    break;
                case ErrorType.TooManyNewLine:
                    s = "リノセウスに轢き殺されました。";
                    break;
            }
            Console.WriteLine($"エラー内容: {s}");
        }

        public virtual bool IsCritical()
        {
            return Type != ErrorType.Success;
        }
    }
}
