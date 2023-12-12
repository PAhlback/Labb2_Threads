using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Threads
{
    internal class TextOuts
    {
        public static async Task PrintWelcomeScreen()
        {
            await Console.Out.WriteLineAsync("         (        )      )     *           )  (    (     \r\n         )\\ )  ( /(   ( /(   (  `       ( /(  )\\ ) )\\ )  \r\n (   (  (()/(  )\\())  )\\())  )\\))(      )\\())(()/((()/(  \r\n )\\  )\\  /(_))((_)\\  ((_)\\  ((_)()\\    ((_)\\  /(_))/(_)) \r\n((_)((_)(_))    ((_)   ((_) (_()((_)   __((_)(_)) (_))   \r\n\\ \\ / / | _ \\  / _ \\  / _ \\ |  \\/  |   \\ \\/ /|_ _||_ _|  \r\n \\ V /  |   / | (_) || (_) || |\\/| |    >  <  | |  | |   \r\n  \\_/   |_|_\\  \\___/  \\___/ |_|  |_|   /_/\\_\\|___||___|  \r\n                                                         ");
        }

        public static async Task PrintRaceStarted()
        {
            await Console.Out.WriteLineAsync(
                "╦═╗╔═╗╔═╗╔═╗  ╔═╗╔╦╗╔═╗╦═╗╔╦╗╔═╗╔╦╗\r\n╠╦╝╠═╣║  ║╣   ╚═╗ ║ ╠═╣╠╦╝ ║ ║╣  ║║\r\n╩╚═╩ ╩╚═╝╚═╝  ╚═╝ ╩ ╩ ╩╩╚═ ╩ ╚═╝═╩╝\r\n\r\n"
                );
        }

        public static async Task PrintWinnerScreen(string name)
        {
            await Console.Out.WriteLineAsync(
                "             (         )        )             (     \r\n (  (        )\\ )   ( /(     ( /(             )\\ )  \r\n )\\))(   '  (()/(   )\\())    )\\())    (      (()/(  \r\n((_)()\\ )    /(_)) ((_)\\    ((_)\\     )\\      /(_)) \r\n_(())\\_)()  (_))    _((_)    _((_)   ((_)    (_))   \r\n\\ \\((_)/ /  |_ _|  | \\| |   | \\| |   | __|   | _ \\  \r\n \\ \\/\\/ /    | |   | .` |   | .` |   | _|    |   /  \r\n  \\_/\\_/    |___|  |_|\\_|   |_|\\_|   |___|   |_|_\\  \r\n                                                    "
                );

            int math = 52 / 2 - name.Length/2 - 3;
            Console.SetCursorPosition(math, 10);
            await Console.Out.WriteLineAsync("=== " + $"{name}" + " ===");

            Console.SetCursorPosition(17, 12);
            await Console.Out.WriteLineAsync($"Press enter to end!");
            
        }
    }
}
