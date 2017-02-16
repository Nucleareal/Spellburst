using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellburst
{
    public enum SpellCode
    {
        None,
        Space,
        Tab,
        NewLine,
    }

    public enum ReadMode
    {
        None,
        WaitIMP,
        WaitCommand,
        InputInteger,
        InputLabel,
        Finish,
    }

    public enum ErrorType
    {
        None,
        Success,
        TooManyNewLine,
        FWord,
        FileNotFound,
        CommandNotFound,
        LabelIsAlreadyDefined,
        InvalidLabelJump,
        StackIsEmpty,
        SubRoutineLevelTooDeep,
        ReturnInNonSubroutine,
    }
}
