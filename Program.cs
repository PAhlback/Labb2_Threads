using Labb2_Threads.Models;

namespace Labb2_Threads
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Race.RunRace();
        }
    }
}