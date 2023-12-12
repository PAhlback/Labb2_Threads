using Labb2_Threads.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Labb2_Threads
{
    internal class Race
    {
        public static CancellationTokenSource Cts = new CancellationTokenSource();
        public static ConcurrentDictionary<int, Car> Cars = new ConcurrentDictionary<int, Car>();
        public static double FinishLineDistance { get; set; } = 10000;
        public static bool RaceIsRunning { get; set; } = false;
        public static Car Winner { get; set; }
        

        public Race()
        {
            Console.Write($"Name your car: ");
            string carName = Console.ReadLine();
            Car newCar = new Car(carName);
            Cars.AddOrUpdate(newCar.CarId, newCar, (k, v) => newCar);

            Console.WriteLine("Your opponents name is: Death Wagon");
            newCar = new Car("Death Wagon");
            Cars.AddOrUpdate(newCar.CarId, newCar, (k, v) => newCar);

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public static async Task RunRace()
        {
            await TextOuts.PrintWelcomeScreen();
            CancellationToken ct = Cts.Token;

            Race race = new Race();
            await TextOuts.PrintWelcomeScreen();

            await Instructions();
            
            Console.Clear();
            await TextOuts.PrintRaceStarted();

            RaceIsRunning = true;

            Task car1 = Task.Run(() => Cars[1].DistanceMeter(ct));
            Task car2 = Task.Run(() => Cars[2].DistanceMeter(ct));

            //Start method waiting for user inputs
            Task status = Task.Run(() => RaceStatus(ct));

            Task.WaitAll(car1, car2);
            
            Winner = Cars.Values.FirstOrDefault(c => c.DistanceTraveled > 10000);
            Console.Clear();

            if (Winner != null)
            {
                await TextOuts.PrintWinnerScreen(Winner.Name.ToString());
                Task.WaitAny(status);
            } 
            else 
            {
                await Console.Out.WriteLineAsync("Race ended early - no winners here!");
                await Console.Out.WriteLineAsync("Press enter to end");
                await Console.In.ReadLineAsync();
            }
        }

        static async Task<bool> RaceStatus(CancellationToken ct)
        {
            string input = string.Empty;
            while (!ct.IsCancellationRequested)
            {
                if (!ct.IsCancellationRequested)
                {
                    input = await Console.In.ReadLineAsync();
                }
                if (input.ToLower() == "status")
                {
                    await Console.Out.WriteLineAsync($"{Cars[1].Name}, {Cars[1].DistanceTraveled}m");
                    await Console.Out.WriteLineAsync($"{Cars[2].Name}, {Cars[2].DistanceTraveled}m");
                }
                if (input.ToLower() == "cancel")
                {
                    Cts.Cancel();
                    await Console.Out.WriteLineAsync("Race cancelled. Please wait...");
                }
            }
            return true;
        }

        static async Task Instructions()
        {
            Console.WriteLine("During the game you can type \"status\" at any time to view distance traveled by competing cars.");
            Console.WriteLine("Type \"cancel\" to cancel the race early.");
            Console.WriteLine("The first car to reach 10km wins!");
            Console.WriteLine("Press enter to start race!");
            Console.ReadLine();
        }
    }
}
