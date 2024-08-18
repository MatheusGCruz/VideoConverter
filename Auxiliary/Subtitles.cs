using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConverter.Auxiliary
{
    internal class Subtitles
    {
        public static string subtitles(string language, string sub) 
        {
            Console.WriteLine(language + ": " + sub);

            string returnInt = "0";
            switch (language)
            {
                case "eng":
                    Console.WriteLine("Sub: eng");
                    if (sub == "Ember") { returnInt = "0"; }
                    if (sub == "Erai-raws") { returnInt = "0"; }
                    break;

                case "por":
                    Console.WriteLine("Sub: eng");
                    if (sub == "EA") { returnInt = "0"; }
                    if (sub == "Erai-raws") { returnInt = "1"; }
                    break;

                default: 
                    break;
            }

            Console.WriteLine("Return int: "+returnInt);
            return returnInt;
        }
    }
}
