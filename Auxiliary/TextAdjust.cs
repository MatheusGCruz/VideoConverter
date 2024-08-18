using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoConverter.Auxiliary
{
    internal class TextAdjust
    {
        public static string InputName(string Input)
        {
            Input = Input.Replace(".mkv", "");
            Input = Input.Replace(" ", "");
            return RegexAdjust(Input);
        }

        public static string OutputName(string Output)
        {
            Output = Output.Replace("-out.mp4", "");
            return RegexAdjust(Output);
        }

        private static string RegexAdjust(string nameString)
        {
            Regex yourRegex = new Regex(@"\[.*?\]");
            return yourRegex.Replace(nameString, "");
        }
    }
}
