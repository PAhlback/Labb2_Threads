using Labb2_Threads.Models;

namespace Labb2_Threads
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await TextOuts.PrintWelcomeScreen();

            Race race = new Race();

            await Race.RunRace();
        }
    }
}