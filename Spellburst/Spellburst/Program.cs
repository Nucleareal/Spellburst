using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Spellburst
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var fileName = GetFileName(args);
            if(fileName == null)
            {
                new SpellburstError(ErrorType.FileNotFound).Throw();
            }
            SpellburstOption.CauseOption(args);

            using (StreamReader r = new StreamReader(fileName, Encoding.GetEncoding("UTF-8")))
            {
                var code = r.ReadToEnd();

                var preProcessor = new PreProcessor(code);

                var preProcessError = preProcessor.PreProcess();
                if(preProcessError.IsCritical())
                {
                    preProcessError.Throw();
                }

                //Console.WriteLine("PreProcess Complete");

                code = preProcessor.Code;

                var interpreter = new Interpreter();
                var runtimeError = interpreter.Run();
                if(runtimeError.IsCritical())
                {
                    runtimeError.Throw();
                }

                //Console.WriteLine("Process Complete");
            }

            Console.ReadKey();
        }

        private static string GetFileName(string[] args)
        {
            if (args.Length == 0)
            {
                OpenFileDialog diag = new OpenFileDialog();

                diag.FileName = "main.spellburst";
                diag.Filter = "Spellburstファイル(*.spellburst;*.sbt)|*.spellburst;*.sbt";
                diag.Title = "デッキを選べ";
                
                if(diag.ShowDialog() == DialogResult.OK)
                {
                    return diag.FileName;
                }
            }
            else
            {
                foreach(var s in args)
                {
                    if(s.StartsWith("-") || s.StartsWith("/"))
                    {
                        continue;
                    }
                    return s;
                }
            }
            return null;
        }
    }
}
